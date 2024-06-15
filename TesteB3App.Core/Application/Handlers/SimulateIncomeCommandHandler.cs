using FluentValidation.Results;
using MediatR;
using TesteB3App.Core.Application.Commands;
using TesteB3App.Core.Domain.Entities;
using TesteB3App.Core.Dtos;
using TesteB3App.Core.Interfaces;
using TesteB3App.Core.Mappers;
using TesteB3App.Core.Notification;

namespace TesteB3App.Core.Application.Handlers
{
    public class SimulateIncomeCommandHandler : IRequestHandler<SimulateIncomeCommand, SumulatedIncomeCdbDto>
    {
        private readonly IIncomeService _incomeService;
        private readonly NotificationContext _notificationContext;

        public SimulateIncomeCommandHandler(IIncomeService incomeService, NotificationContext notificationContext)
        {
            _incomeService = incomeService;
            _notificationContext = notificationContext;
        }
        public async Task<SumulatedIncomeCdbDto> Handle(SimulateIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = new Income(request.ValueApplication, request.QuantityMounth);

            if(income.Invalid)
            {
                _notificationContext.AddNotifications(income.ValidationResult ?? new ValidationResult());
                return new SumulatedIncomeCdbDto();

            }
            var simulatedIncome = await _incomeService.SimulateMonthlyIncomeAsync(income);
            return simulatedIncome.MapToDto();
        }
    }
}
