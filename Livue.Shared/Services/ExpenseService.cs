using Livue.Shared.Models;

namespace Livue.Shared.Services;

/// <summary>
/// Provides sample expense data for the dashboard.
/// Replace with a real data source (API, local database, etc.) as needed.
/// </summary>
public class ExpenseService : IExpenseService
{
    public Task<DailyExpenseSummary> GetTodaySummaryAsync()
    {
        var summary = new DailyExpenseSummary
        {
            Location = "경기도 안양시",
            LastUpdated = DateTime.Now,
            TodaySpent = 48_200,
            DailyBudget = 70_000,
            MonthlySpent = 1_142_000,
            MonthlyBudget = 2_000_000,
            Last7DaysLabels = new List<string> { "월", "화", "수", "목", "금", "토", "오늘" },
            Last7DaysSpent = new List<int> { 32000, 45000, 12000, 38000, 61000, 40000, 48200 },
            RecentExpenses = new List<ExpenseItem>
            {
                new() { Category = "배달 · 저녁", Amount = 22_000, Time = new TimeOnly(19, 52) },
                new() { Category = "편의점", Amount = 8_700, Time = new TimeOnly(16, 10) },
                new() { Category = "카페", Amount = 10_000, Time = new TimeOnly(13, 24) },
                new() { Category = "지하철", Amount = 7_500, Time = new TimeOnly(9, 5) },
            }
        };

        return Task.FromResult(summary);
    }
}
