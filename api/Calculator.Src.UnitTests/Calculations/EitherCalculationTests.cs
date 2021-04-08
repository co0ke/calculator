namespace Calculator.Src.UnitTests.Calculations
{
    using System.Collections.Generic;
    using Calculator.Src.Calculations;
    using Calculator.Src.DTOs;
    using Calculator.Src.Enums;
    using FluentAssertions;
    using Xunit;

    public class EitherCalculationTests
    {
        [Theory]
        [InlineData(-0.1, 0.5)]
        [InlineData(0.5, -0.1)]
        [InlineData(-0.1, -0.1)]
        public void Validate_InvalidParameters_ReturnsExpectedResult(decimal pa, decimal pb)
        {
            // Arrange
            var calculation = new EitherCalculation(pa, pb);

            // Act
            var result = calculation.Validate();

            // Assert
            var expected = new ValidationResult
            {
                IsValid = false,
                Errors = new List<Error>
                {
                    new Error
                    {
                        ErrorCode = ErrorCode.InvalidParameters,
                        ErrorMessage = "Parameters must be greater than or equal to 0 and less than or equal to 1"
                    }
                }
            };

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Validate_ValidParameters_ReturnsExpectedResult()
        {
            // Arrange
            var pa = 0.7M;
            var pb = 0.8M;
            var calculation = new EitherCalculation(pa, pb);

            // Act
            var result = calculation.Validate();

            // Assert
            var expected = new ValidationResult { IsValid = true };
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Calculate_ReturnsExpectedResult()
        {
            // Arrange
            var pa = 0.7M;
            var pb = 0.8M;
            var calculation = new EitherCalculation(pa, pb);

            // Act
            var result = calculation.Calculate();

            // Assert
            result.Should().Be(0.94M);
        }

        [Fact]
        public void GetInputsForLogMessage_ReturnsExpectedResult()
        {
            // Arrange
            var pa = 0.7M;
            var pb = 0.8M;
            var calculation = new EitherCalculation(pa, pb);

            // Act
            var result = calculation.GetInputsForLogMessage();

            // Assert
            result.Should().Be("0.7 + 0.8 - 0.7 * 0.8");
        }
    }
}