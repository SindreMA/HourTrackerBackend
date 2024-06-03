using HourTrackerBackend.Modals.Database;

namespace HourTrackerBackend.Modals.Request
{
    public class TodoMessage
    {
        public required string Title { get; set; }
        public Status Status { get; set; }
    }
    
}