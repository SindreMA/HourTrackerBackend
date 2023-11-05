using Microsoft.AspNetCore.Identity;

namespace HourTrackerBackend.Modals.Database
{
    public enum Status
    {
        NotStarted,
        InProgress,
        Completed
    }

    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
