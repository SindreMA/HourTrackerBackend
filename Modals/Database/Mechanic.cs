using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HourTrackerBackend.Modals.Database
{
    public enum MechanicType
    {
        FullMechanic,
        HalfMechanic,
        QuarterMechanic        
    }
    public class Mechanic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MechanicType Type { get; set; }
        public List<Project> Projects { get; set; }
        public DateTime Created { get; set; }
        public string About { get; set; }
        public int CommonId { get; set; }
        [ForeignKey("CommonId")]
        public Common Common { get; set; } 
    }
}
