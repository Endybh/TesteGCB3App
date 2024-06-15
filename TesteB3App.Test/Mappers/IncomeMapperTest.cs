using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteB3App.Core.Domain.Entities;
using TesteB3App.Core.Mappers;

namespace TesteB3App.Test.Mappers
{
    [TestClass]
    public class IncomeMapperTest
    {
        [TestMethod]
        public void MapToDto_MapsPropertiesCorrectly()
        {
            // Arrange
            var income = new Income(950.0m, 12);            
            income.SetGrossFinalValue(1000.0m);
            income.SetNetFinalValue(800.0m);

            // Act
            var result = IncomeMapper.MapToDto(income);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(income.GrossFinalValue, result.GrossValue);
            Assert.AreEqual(income.NetFinalValue, result.NetValue);
        }
    }
}
