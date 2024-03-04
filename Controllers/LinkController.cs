using HourTrackerBackend.Helpers;
using HourTrackerBackend.Modals.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HourTrackerBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("links")]
    public class LinkController : BaseController
    {
        private readonly LinkHelper _linkHelper;
        public LinkController(IHttpContextAccessor ctx) : base(ctx)
        {
            _linkHelper = new LinkHelper(__context);
        }

        [HttpPost("{projectId}/{mechanicId}")]
        public ActionResult Post(int projectId, int mechanicId) {
            _linkHelper.AddLink(projectId, mechanicId);
            return Ok();
        }

        [HttpDelete("{projectId}/{mechanicId}")]
        public ActionResult Delete(int projectId, int mechanicId) {
            _linkHelper.RemoveLink(projectId);
            return Ok();
        }

        [HttpPost("{id}/week")]
        public ActionResult AddWeekData(int id, [FromBody] WeekDataMessage weekData) {
            _linkHelper.AddWeekData(id, weekData);
            return Ok();
        }

        [HttpPut("{id}/week")]
        public ActionResult UpdateWeekData(int id, int week, [FromBody] WeekDataMessage weekData) {
            _linkHelper.EditWeekData(id, weekData);
            return Ok();
        }
    }
}