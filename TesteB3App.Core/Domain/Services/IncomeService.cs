using TesteB3App.Core.Domain.Entities;
using TesteB3App.Core.Domain.ObjectValue;
using TesteB3App.Core.Interfaces;

namespace TesteB3App.Core.Domain.Services
{
    public class IncomeService : IIncomeService
    {
        public Task<Income> SimulateMonthlyIncomeAsync(Income income)
        {
            income.SetGrossFinalValue(CalculateCDB(income.ValueApplication, Fees.CDI, Fees.TB, income.QuantityMounth));
            income.SetNetFinalValue(income.GrossFinalValue - CalculateTax(income.ValueApplication, income.GrossFinalValue, income.QuantityMounth));

            return Task.FromResult(income);
        }

        private decimal CalculateCDB(decimal initialValue, decimal cdi, decimal tb, int months)
        {
            decimal actualValue = initialValue;

            for (int i = 0; i < months; i++)
                actualValue *= (1 + (cdi * tb));

            return Math.Round(actualValue, 2);
        }

        private decimal CalculateTax(decimal initialValue, decimal finalValue, int mounthQuantity)
        {
            decimal incomeValue = finalValue - initialValue;
            decimal tax;

            if (mounthQuantity <= 6)
                tax = 0.225m;
            else if (mounthQuantity <= 12)
                tax = 0.20m;
            else if (mounthQuantity <= 24)
                tax = 0.175m;
            else
                tax = 0.15m;

            return Math.Round(incomeValue * tax, 2);
        }
    }
}
