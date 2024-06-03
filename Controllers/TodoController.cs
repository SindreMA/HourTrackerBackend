using HourTrackerBackend.Helpers;
using HourTrackerBackend.Modals;
using HourTrackerBackend.Modals.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HourTrackerBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TodoController : BaseController
    {
        private readonly TodoHelper _todoHelper;
        public TodoController(IHttpContextAccessor ctx, TodoHelper todoHelper) : base(ctx)
        {
            _todoHelper = todoHelper;
        }

        [HttpGet]
        public ActionResult Get() =>
            Ok(_todoHelper.GetTodos());

        [HttpPost("/project/{id}")]
        public ActionResult Post([FromBody] TodoMessage todo, int id) =>
            Ok(_todoHelper.AddTodoItem(todo, id));

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TodoMessage todo) =>
            Ok(_todoHelper.UpdateTodoItem(todo, id));

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            _todoHelper.RemoveTodoItem(id);
            return Ok();
        }
    }
}