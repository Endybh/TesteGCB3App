using TesteB3App.Core.Interfaces;
using TesteB3App.Core.Domain.Entities;
using TesteB3App.Core.Domain.Services;

namespace TesteB3App.Test.Domain.Services
{
    [TestClass]
    public class IncomeServiceTest
    {
        private readonly IIncomeService _incomeService;

        public IncomeServiceTest()
        {
            _incomeService = new IncomeService();
        }
        [TestMethod]
        public async Task SimulateMonthlyIncome_Success()
        {
            //Arrange
            Income income = new Income(250.75m, 24);

            //Act
            var result = await _incomeService.SimulateMonthlyIncomeAsync(income);

            //Asserts
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.GrossFinalValue);
            Assert.AreNotEqual(0, result.NetFinalValue);
            Assert.IsTrue(result.GrossFinalValue > income.ValueApplication);
            Assert.IsTrue(result.NetFinalValue > income.ValueApplication && result.NetFinalValue < result.GrossFinalValue);
        }
    }
}