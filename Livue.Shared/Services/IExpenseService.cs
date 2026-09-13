using Livue.Shared.Models;

namespace Livue.Shared.Services;

public interface IExpenseService
{
    Task<DailyExpenseSummary> GetTodaySummaryAsync();
}
