using HourTrackerBackend.Modals;
using HourTrackerBackend.Modals.Database;
using HourTrackerBackend.Modals.Request;

namespace HourTrackerBackend.Helpers
{
    public class MechanicHelper
    {
        private readonly TrackerContext _context;
        private readonly string? _username;
        public MechanicHelper(TrackerContext context, IHttpContextAccessor ctx)
        {
            _context = context;
            _username = ctx.HttpContext?.User?.Identity?.Name;
        }

        public Mechanic AddMechanic(MechanicMessage mechanic)
        {
            var newMechanic = new Mechanic
            {
                Name = mechanic.Name,
                About = mechanic.About,
                Created = DateTime.UtcNow,
                Type = mechanic.Type,
                Common = new Common()
            };
            _context.Mechanics.Add(newMechanic);
            _context.SaveChanges();
            return newMechanic;
        }
        
        public void RemoveMechanic(int id)
        {
            var mechanic = _context.Mechanics.Find(id);

            if (mechanic == null) throw new Exception("NotFound");

            _context.Mechanics.Remove(mechanic);
            _context.SaveChanges();
        }

        public Mechanic UpdateMechanic(MechanicMessage mechanic, int id)
        {
            var dbMechanic = _context.Mechanics.Find(id);

            if (dbMechanic == null) throw new Exception("NotFound");

            dbMechanic.Name = mechanic.Name;
            dbMechanic.About = mechanic.About;
            dbMechanic.Type = mechanic.Type;
            _context.Mechanics.Update(dbMechanic);
            _context.SaveChanges();
            return dbMechanic;
        }

        internal List<Mechanic> GetMechanics()
        {
            return _context.Mechanics.ToList();
        }
    }
}