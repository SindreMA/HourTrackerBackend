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
    public class MechanicController : BaseController
    {
        private readonly MechanicHelper _mechanicHelper;
        public MechanicController(IHttpContextAccessor ctx, MechanicHelper mechanicHelper) : base(ctx)
        {
            _mechanicHelper = mechanicHelper;
        }

        [HttpGet]
        public ActionResult Get() =>
            Ok(_mechanicHelper.GetMechanics());

        [HttpPost]
        public ActionResult Post([FromBody] MechanicMessage mechanic) =>
            Ok(_mechanicHelper.AddMechanic(mechanic));
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            _mechanicHelper.RemoveMechanic(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MechanicMessage mechanic) =>
            Ok(_mechanicHelper.UpdateMechanic(mechanic, id));
    }
}