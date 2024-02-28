namespace HourTrackerBackend.Modals.Database;

public class WeekData
{
    public int Id { get; set; }
    public int WeekNumber { get; set; }
    public int Year { get; set; }
    public int SecondsWorked { get; set; }
    
    public DateTime Created { get; set; }
}