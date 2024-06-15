using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteB3App.Core.Domain.Entities;

namespace TesteB3App.Core.Interfaces
{
    public interface IIncomeService
    {
        Task<Income> SimulateMonthlyIncomeAsync(Income income);
    }
}
