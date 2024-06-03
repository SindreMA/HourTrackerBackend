using Microsoft.AspNetCore.Identity;

namespace HourTrackerBackend.Modals.Database
{
    public class Common
    {
        public int Id { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
