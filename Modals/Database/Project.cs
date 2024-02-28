using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HourTrackerBackend.Modals.Database
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectMecanicLink> Links { get; set; }
        public List<Todo> Todos { get; set; }
        public string About { get; set; }
        public int CommonId { get; set; }
        [ForeignKey("CommonId")]
        public Common Common { get; set; } 
        public DateTime Created { get; set; }
        
        
    }
}
