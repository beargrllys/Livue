namespace Livue.Shared.Models;

public class DailyExpenseSummary
{
    public string Location { get; set; } = string.Empty;
    public DateTime LastUpdated { get; set; }

    public int TodaySpent { get; set; }
    public int DailyBudget { get; set; }

    public int MonthlySpent { get; set; }
    public int MonthlyBudget { get; set; }

    public List<int> Last7DaysSpent { get; set; } = new();
    public List<string> Last7DaysLabels { get; set; } = new();

    public List<ExpenseItem> RecentExpenses { get; set; } = new();

    public int RemainingToday => Math.Max(DailyBudget - TodaySpent, 0);
    public double DailyProgress => DailyBudget <= 0 ? 0 : Math.Min((double)TodaySpent / DailyBudget, 1.0);
    public double MonthlyProgress => MonthlyBudget <= 0 ? 0 : Math.Min((double)MonthlySpent / MonthlyBudget, 1.0);
    public int MonthlyProgressPercent => (int)Math.Round(MonthlyProgress * 100);
}
