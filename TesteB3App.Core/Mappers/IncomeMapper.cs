using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteB3App.Core.Domain.Entities;
using TesteB3App.Core.Dtos;

namespace TesteB3App.Core.Mappers
{
    public static class IncomeMapper
    {
        public static SumulatedIncomeCdbDto MapToDto(this Income entity)
        {
            return new SumulatedIncomeCdbDto
            {
                GrossValue = entity.GrossFinalValue,
                NetValue = entity.NetFinalValue
            };
        }
    }
}
