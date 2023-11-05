using HourTrackerBackend.Modals;
using HourTrackerBackend.Modals.Database;
using HourTrackerBackend.Modals.Request;

namespace HourTrackerBackend.Helpers
{
    public class MechanicHelper
    {
        private readonly TrackerContext _context;
        private readonly string _username;
        public MechanicHelper(TrackerContext context, string username = null)
        {
            _context = context;
            _username = username;
        }

        public Mechanic AddMechanic(MechanicMessage mechanic)
        {
            var newMechanic = new Mechanic
            {
                Name = mechanic.Name,
                About = mechanic.About,
                Created = System.DateTime.UtcNow,
                Common = new Common()
            };
            _context.Mechanics.Add(newMechanic);
            _context.SaveChanges();
            return newMechanic;
        }
        
        public void RemoveMechanic(int id)
        {
            var mechanic = _context.Mechanics.Find(id);
            _context.Mechanics.Remove(mechanic);
            _context.SaveChanges();
        }

        public Mechanic UpdateMechanic(MechanicMessage mechanic, int id)
        {
            var dbMechanic = _context.Mechanics.Find(id);
            dbMechanic.Name = mechanic.Name;
            dbMechanic.About = mechanic.About;
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