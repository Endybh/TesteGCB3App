using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteB3App.Core.Application.Commands;
using TesteB3App.Core.Domain.Entities;

namespace TesteB3App.Core.Validations
{
    public class IncomeValidator : AbstractValidator<Income>
    {
        public IncomeValidator() 
        {
            RuleFor(p => p.QuantityMounth).GreaterThan(1)
                .WithMessage("Month quantity must be greater than 1");

            RuleFor(p => p.ValueApplication).GreaterThan(0)
                .WithMessage("Application value must be greater than 0");
        }        
    }
}
