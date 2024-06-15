using MediatR;
using TesteB3App.Core.Dtos;

namespace TesteB3App.Core.Application.Commands
{
    public class SimulateIncomeCommand: IRequest<SumulatedIncomeCdbDto>
    {
        public decimal ValueApplication { get; set; }
        public int QuantityMounth { get; set; }
    }
}
