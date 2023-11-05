using Microsoft.AspNetCore.Identity;

namespace HourTrackerBackend.Modals.Database
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
    }
}
