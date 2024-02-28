using HourTrackerBackend.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HourTrackerBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LinkController : BaseController
    {
        private readonly ProjectHelper _projectHelper;
        public LinkController(IHttpContextAccessor ctx) : base(ctx)
        {
            _projectHelper = new ProjectHelper(__context, __username);
        }

        [HttpPost("{id}/mechanics/{mechanicId}")]
        public ActionResult Post(int id, int mechanicId) {
            _projectHelper.AddMechanic(id, mechanicId);            
            return Ok();
        }
        
        [HttpDelete("{id}/mechanics/{mechanicId}")]
        public ActionResult Delete(int id, int mechanicId) {
            _projectHelper.RemoveMechanic(id, mechanicId);
            return Ok();
        }
    }
}