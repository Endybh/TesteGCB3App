using System.Text.Json;
using System.Text.Json.Serialization;
using TesteB3App.Core.Validations;

namespace TesteB3App.Core.Domain.Entities
{
    public class Income : Entity
    {
        public decimal GrossFinalValue { get; private set; }
        public decimal NetFinalValue { get; private set; }

        [JsonIgnore]
        public decimal ValueApplication { get; private set; }

        [JsonIgnore]
        public int QuantityMounth { get; private set; }

        public Income(decimal valueApplication, int quantityMounth) 
        { 
            ValueApplication = valueApplication;
            QuantityMounth = quantityMounth;
            Validate(this, new IncomeValidator());
        }

        public void SetNetFinalValue(decimal netFinalValue)
        {
            NetFinalValue = netFinalValue;
        }

        public void SetGrossFinalValue(decimal grossFinalValue)
        {
            GrossFinalValue = grossFinalValue;
        }
    }
}
