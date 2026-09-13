namespace Livue.Shared.Models;

public class ExpenseItem
{
    public string Category { get; set; } = string.Empty;
    public string Memo { get; set; } = string.Empty;
    public int Amount { get; set; }
    public TimeOnly Time { get; set; }
}
