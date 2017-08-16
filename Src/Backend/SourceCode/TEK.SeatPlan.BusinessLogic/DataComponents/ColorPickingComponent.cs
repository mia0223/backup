using System.Collections.Generic;
using System.Linq;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Common;
using TEK.SeatPlan.Entity;
using TEK.SeatPlan.ResourceAccess.Contract;

namespace TEK.SeatPlan.BusinessLogic
{
    public class ColorPickingComponent : DataComponentBase, IColorPickingComponent
    {
        private readonly IRepository<Project> projectRepository;
        private readonly IRandomizer randomizer;
        private readonly List<ProjectColorPair> colorsPairLibrary;


        public ColorPickingComponent(IRepository<Entity.Project> projectRepository, 
            IProjectColorPairComponent projectColorPairComponent,
            IRandomizer randomizer)
        {
            Requires.ArgumentNotNull(projectColorPairComponent, "projectColorPairComponent");
            Requires.ArgumentNotNull(projectRepository, "projectRepository");
            Requires.ArgumentNotNull(randomizer, "randomizer");

            this.projectRepository = projectRepository;
            this.randomizer = randomizer;
            colorsPairLibrary = projectColorPairComponent.Get().ToList();
        }

        public ProjectColorPair GetNextAvailableColorForProject()
        {
            var allProjects = projectRepository.Find(x => x.Active, y => y.OrderBy(z => z.Description.ToUpper()));
            var usedColors = new List<ProjectColorPair>();
            foreach (var project in allProjects)
            {
                usedColors.AddRange(
                    colorsPairLibrary.Where(colorPair =>
                    project.ForegroundColor == colorPair.ForegroundColor
                    && project.BackgroundColor == colorPair.BackgroundColor
                    && project.Active == true));
            }

            var availableColorPairs = colorsPairLibrary.Except(usedColors).ToList();

            Logger.Info("Color for project has been picked from color library.");
            return availableColorPairs.Any() ? GetNextAvailaleColorRamdomly(availableColorPairs) : GetNextAvailaleColorRamdomly(colorsPairLibrary);
        }

        private ProjectColorPair GetNextAvailaleColorRamdomly(List<ProjectColorPair> source)
        {
            return source[randomizer.Next(0, source.Count)];
        }
    }
}
