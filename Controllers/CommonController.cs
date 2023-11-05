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
    public class CommonController : BaseController
    {
        private readonly CommonHelper _commonHelper;
        public CommonController(IHttpContextAccessor ctx) : base(ctx)
        {
            _commonHelper = new CommonHelper(__context, __username);
        }

        [HttpGet("{id}/comments")]
        public ActionResult Get(int id) => 
            Ok(_commonHelper.GetComments(id));

        [HttpPost("{id}/comments")]
        public ActionResult Post(int id, [FromBody] CommentMessage comment) =>
            Ok(_commonHelper.AddComment(id, comment));

        [HttpDelete("comments/{id}")]
        public ActionResult Delete(int id) {
            _commonHelper.RemoveComment(id);
            return Ok();
        }
    }
}