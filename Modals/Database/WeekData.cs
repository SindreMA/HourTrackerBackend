namespace HourTrackerBackend.Modals.Database;

public enum WorkType
{
    Standard       = 0, // Normal work within original scope
    ChangeOrder    = 1, // Approved extra work — billable to customer
    OutOfScope     = 2, // Performed but not yet approved/billed
    CustomerCredit = 3  // Customer performed labor — reduces project burden
}

public class WeekData
{
    public int Id { get; set; }
    public int WeekNumber { get; set; }
    public int Year { get; set; }
    public int SecondsWorked { get; set; }
    public int Weight { get; set; } = 100;
    public WorkType WorkType { get; set; } = WorkType.Standard;
    public string? Note { get; set; }

    public DateTime Created { get; set; }
}
