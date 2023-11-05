using HourTrackerBackend.Modals.Database;

namespace HourTrackerBackend.Modals.Request
{
    public class TodoMessage
    {
        public string Title { get; set; }
        public Status Status { get; set; }
    }
    
}