using System.ComponentModel.DataAnnotations.Schema;

namespace HourTrackerBackend.Modals.Database;

public class ProjectMecanicLink
{
    public int Id { get; set; }

    [ForeignKey("ProjectId")]
    public Project Project { get; set; }
    public int ProjectId { get; set; }

    [ForeignKey("MechanicId")]
    public Mechanic Mechanic { get; set; }
    public int MechanicId { get; set; }
    
    [ForeignKey("WeekDataId")]
    public List<WeekData> WeekData { get; set; }
    public int WeekDataId { get; set; }
    
    public DateTime Created { get; set; }
}
