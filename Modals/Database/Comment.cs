using Microsoft.AspNetCore.Identity;

namespace HourTrackerBackend.Modals.Database
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public User User { get; set; } = null!;
        public DateTime Created { get; set; }
    }
}
