using HourTrackerBackend.Modals.Database;

namespace HourTrackerBackend.Modals.Request
{
    public class MechanicMessage
    {
        public string Name { get; set; } = null!;
        public string About { get; set; } = null!;
        public MechanicType Type { get; set; }
    }
}