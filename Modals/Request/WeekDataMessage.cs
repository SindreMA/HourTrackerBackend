namespace HourTrackerBackend.Modals.Request;

public class WeekDataMessage
{
    public int SecondsWorked { get; set; }
    public int Year { get; set; }
    public DateTime Date { get; set; }
}