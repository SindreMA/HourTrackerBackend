using HourTrackerBackend.Modals.Database;

namespace HourTrackerBackend.Modals.Request;

public class WeekDataMessage
{
    public int SecondsWorked { get; set; }
    public int Year { get; set; }
    public DateTime Date { get; set; }
    public int Weight { get; set; } = 100;
    public WorkType WorkType { get; set; } = WorkType.Standard;
    public string? Note { get; set; }
}
