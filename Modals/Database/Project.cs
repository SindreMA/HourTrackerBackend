using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HourTrackerBackend.Modals.Database
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ProjectMecanicLink> Links { get; set; } = new List<ProjectMecanicLink>();
        public List<Todo> Todos { get; set; } = new List<Todo>();
        public string About { get; set; } = null!;
        public int CommonId { get; set; }
        [ForeignKey("CommonId")]
        public Common Common { get; set; } = new Common();
        public DateTime Created { get; set; }
        
        
    }
}
