using System;
using System.Linq;
using System.Collections.Generic;

using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.BusinessLogic.Mappers;

namespace TEK.SeatPlan.WebApi.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IProjectComponent projectComponent;

        public ProjectController(IProjectComponent projectComponent)
        {
            this.projectComponent = projectComponent;
        }

	    public IEnumerable<Dto.Project> Get()
	    {
	        return this.projectComponent.GetProjects();
	    }

		public Dto.Project Get(int id)
		{
		    return this.projectComponent.GetProject(id);
		}

	    public Dto.Project Post(Dto.Project project)
	    {
	        return this.projectComponent.CreateProject(project);
	    }

		public Dto.Project Put(Dto.Project project)
		{
		    return this.projectComponent.UpdateProject(project);
		}

        public void Delete(int id)
        {
            this.projectComponent.SoftDelete(id);
        }
	}
}