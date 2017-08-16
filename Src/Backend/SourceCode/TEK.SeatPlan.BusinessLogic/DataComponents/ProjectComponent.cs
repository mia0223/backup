using System;
using System.Collections.Generic;
using System.Linq;

using TEK.SeatPlan.Dto;
using TEK.SeatPlan.Common;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.BusinessLogic.Mappers;
using TEK.SeatPlan.ResourceAccess.Contract;

namespace TEK.SeatPlan.BusinessLogic
{
    public class ProjectComponent : DataComponentBase, IProjectComponent
    {
        private readonly IRepository<Entity.Project> projectRepository;
        private readonly IRepository<Entity.Employee> employeeRepository;
        private readonly IColorPickingComponent colorPicking;


        public ProjectComponent(IRepository<Entity.Project> projectRepository, 
            IRepository<Entity.Employee> employeeRepository,
            IColorPickingComponent colorPicking) : base()
        {
            this.projectRepository = projectRepository;
            this.employeeRepository = employeeRepository;
            this.colorPicking = colorPicking;
        }

        public Project GetProject(int id)
        {
            Requires.ArgumentNotNull(id, "project Id");
            base.Logger.InfoFormat("Get project call for id: {0}", id);

			return projectRepository.Get(x => x.Id == id, null)?.ToDto();
        }

        public IEnumerable<Project> GetProjects()
        {
            base.Logger.Info("Get all project called - find in repo");

			return projectRepository.Find(x => x.Active, y => y.OrderBy(z => z.Description.ToUpper()))?.ToDto();
        }

        public Project CreateProject(Project project)
        {
            Requires.ArgumentNotNull(project, "project");

            var projectColorPair = colorPicking.GetNextAvailableColorForProject();

            if (string.IsNullOrEmpty(project.ForegroundColor))
            {
                project.ForegroundColor = projectColorPair.ForegroundColor;
            }

			if (string.IsNullOrEmpty(project.BackgroundColor))
			{
				project.BackgroundColor = projectColorPair.BackgroundColor;
			}

			var projectCreated = this.projectRepository.Add(project.ToEntity(null));
			this.projectRepository.SaveChanges();
			base.Logger.InfoFormat("Project created with Name: {0}", project.Name);

			return projectCreated?.ToDto();
		}

        public Project UpdateProject(Project project)
        {
            Requires.ArgumentNotNull(project, "project");
            var currentProjectFromDb = this.projectRepository.Get(x => x.Id == project.Id);

            if (currentProjectFromDb == null)
            {
                base.Logger.ErrorFormat("Project [{0}] not found", project.Name);
                throw new InvalidOperationException($"Project [{project.Name}] not found");
            }

            var modifiedProject = project.ToEntity(currentProjectFromDb);
            
            var projectUpdated = this.projectRepository.Update(modifiedProject).ToDto();
			this.projectRepository.SaveChanges();
			base.Logger.InfoFormat("Project Name: {0}, ID: {1} has been updated", project.Name, project.Id);

			return projectUpdated;
        }

        public void SoftDelete(int id)
        {
            Requires.ArgumentNotNull(id, "id");

            var currentProjectFromDb = this.projectRepository.Get(x => x.Id == id);
            if (currentProjectFromDb == null)
            {
                base.Logger.ErrorFormat("Project id [{0}] not found", id);
                throw new InvalidOperationException($"Project id [{id}] not found");
            }
            currentProjectFromDb.Active = false;

            SetTeamMembersOnBench(currentProjectFromDb);

            this.projectRepository.Update(currentProjectFromDb);
            this.projectRepository.SaveChanges();
            base.Logger.InfoFormat("Project [{0}] has been deleted", currentProjectFromDb.Name);
        }

        private void SetTeamMembersOnBench(Entity.Project project)
        {
            var teamMembers = this.employeeRepository.Find(e => e.Project.Id == project.Id, null).ToList();

			if (!teamMembers.Any()) return;

            var benchProject = this.projectRepository.Find(p => p.Name == "BNH", null).FirstOrDefault();

            if (benchProject == null)
            {
                base.Logger.Error("Project BNH not found");
                throw new InvalidOperationException(
                    $"An error occured when trying to assign Bench to team members of the deleted project - BNH not found");
            }

            foreach (var employeeOnThisProject in teamMembers)
            {
                employeeOnThisProject.Project = benchProject;
                employeeRepository.Update(employeeOnThisProject);
            }

            this.employeeRepository.SaveChanges();
            base.Logger.InfoFormat("Updated {0} employees, set to Bench because of project [{1}] deletion", teamMembers.Count, project.Name);
        }
    }
}