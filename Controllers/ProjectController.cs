using HourTrackerBackend.Helpers;
using HourTrackerBackend.Modals;
using HourTrackerBackend.Modals.Database;
using HourTrackerBackend.Modals.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HourTrackerBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : BaseController
    {
        private readonly ProjectHelper _projectHelper;
        public ProjectController(IHttpContextAccessor ctx) : base(ctx)
        {
            _projectHelper = new ProjectHelper(__context, __username);
        }

        [HttpGet]
        public ActionResult Get() =>
            Ok(_projectHelper.GetProjects());

        [HttpPost]
        public ActionResult Post([FromBody] ProjectMessage project) =>
            Ok(_projectHelper.AddProject(project));

        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProjectMessage project) =>
            Ok(_projectHelper.UpdateProject(project, id));

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            _projectHelper.RemoveProject(id);
            return Ok();
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