using HourTrackerBackend.Modals.Database;

namespace HourTrackerBackend.Modals.Request
{
    public class MechanicMessage
    {
        public string Name { get; set; }
        public string About { get; set; }
        public MechanicType Type { get; set; }
    }
}