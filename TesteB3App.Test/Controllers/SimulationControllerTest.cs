using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TesteB3App.Core.Application.Commands;
using TesteB3App.Core.Domain.Entities;
using TesteB3App.Core.Dtos;
using TesteB3App.Server.Controllers;

namespace TesteB3App.Test.Controllers
{
    [TestClass]
    public class SimulationControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly SimulationController _simulationController;

        public SimulationControllerTest() 
        {
            _mediatorMock = new Mock<IMediator>();
            _simulationController = new SimulationController(_mediatorMock.Object);
        }
        [TestMethod]
        public async Task Simulate_ReturnsOkResult_WithResultFromMediator()
        {
            //Arrange
            var command = new SimulateIncomeCommand { QuantityMounth = 12, ValueApplication = 250 };
            var expectedResponse = new SumulatedIncomeCdbDto { GrossValue = 280.77m, NetValue = 274.62m };
            

            _mediatorMock.Setup(m => m.Send(It.IsAny<SimulateIncomeCommand>(), default))
                .ReturnsAsync(expectedResponse);

            //Act
            var result = await _simulationController.Simulate(command);

            //Asserts
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOfType(okResult.Value, typeof(SumulatedIncomeCdbDto));
            Assert.AreEqual(expectedResponse,okResult.Value);
        }
    }
}
