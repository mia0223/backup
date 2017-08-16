using System.Collections.Generic;
using TEK.SeatPlan.Dto;

namespace TEK.SeatPlan.BusinessLogic.Contract
{
    public interface IProjectComponent
    {
        Dto.Project GetProject(int id);

        IEnumerable<Dto.Project> GetProjects();

        Dto.Project CreateProject(Dto.Project project);

        Dto.Project UpdateProject(Dto.Project project);

        void SoftDelete(int id);
    }
}