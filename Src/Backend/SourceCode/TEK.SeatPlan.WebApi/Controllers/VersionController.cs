using System.Web.Http;

using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Common;

namespace TEK.SeatPlan.WebApi.Controllers
{
    public class VersionController : BaseController
    {
        private readonly IVersionComponent versionComponent;

        public VersionController(IVersionComponent versionComponent)
        {
            Requires.ArgumentNotNull(versionComponent, nameof(versionComponent));
            this.versionComponent = versionComponent;
        }

        [HttpGet]
        public string Get()
        {
            return this.versionComponent.GetVersion();
        }
    }
}