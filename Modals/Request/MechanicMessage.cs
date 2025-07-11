using HourTrackerBackend.Modals.Database;

namespace HourTrackerBackend.Modals.Request
{
    public class MechanicMessage
    {
        public string Name { get; set; } = null!;
        public string About { get; set; } = null!;
        public int DefaultWeight { get; set; } = 1;
        public MechanicType Type { get; set; }
    }
}