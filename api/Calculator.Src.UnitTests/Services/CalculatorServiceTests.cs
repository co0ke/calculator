namespace Calculator.Src.UnitTests.Services
{
    using System.Collections.Generic;
    using Calculator.Src.Calculations;
    using Calculator.Src.DTOs;
    using Calculator.Src.Enums;
    using Calculator.Src.Services;
    using Calculator.Src.UnitTests.Extensions;
    using FluentAssertions;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class CalculatorServiceTests
    {
        private readonly Mock<ILogger<CalculatorService>> _logger;

        public CalculatorServiceTests()
        {
            _logger = new Mock<ILogger<CalculatorService>>(MockBehavior.Loose);
        }

        [Fact]
        public void Calculate_FailsValidation_ReturnsExpectedResult()
        {
            // Arrange
            var calculatorService = new CalculatorService(_logger.Object);
            var calculation = new Mock<ICalculation<decimal>>(MockBehavior.Strict);

            var validationResult = new ValidationResult
            {
                IsValid = false,
                Errors = new List<Error>
                {
                    new Error
                    {
                        ErrorCode = ErrorCode.InvalidParameters
                    }
                }
            };
            calculation.Setup(x => x.Validate()).Returns(validationResult);

            // Act
            var result = calculatorService.Calculate(calculation.Object);

            // Assert
            var expected = new CalculationResult<decimal> { Validation = validationResult };
            result.Should().BeEquivalentTo(expected);
            calculation.Verify(x => x.Validate(), Times.Once);
            _logger.VerifyNoOtherCalls();
        }

        [Fact]
        public void Calculate_PassesValidation_ReturnsExpectedResult()
        {
            // Arrange
            var calculatorService = new CalculatorService(_logger.Object);
            var calculation = new Mock<ICalculation<decimal>>(MockBehavior.Strict);

            var validationResult = new ValidationResult { IsValid = true };
            calculation.Setup(x => x.Validate()).Returns(validationResult);
            calculation.Setup(x => x.Calculate()).Returns(0.55M);
            calculation.Setup(x => x.GetInputsForLogMessage()).Returns("SomeInputs");

            // Act
            var result = calculatorService.Calculate(calculation.Object);

            // Assert
            var expected = new CalculationResult<decimal>
            {
                Value = 0.55M,
                Validation = validationResult
            };
            result.Should().BeEquivalentTo(expected);
            calculation.Verify(x => x.Validate(), Times.Once);
            calculation.Verify(x => x.Calculate(), Times.Once);
            _logger.VerifyInformationWasCalled("Type: ICalculation`1Proxy | Inputs: SomeInputs | Result: 0.55");
        }
    }
}