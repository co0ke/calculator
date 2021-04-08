namespace Calculator.Src.Services
{
    using Calculator.Src.Calculations;
    using Calculator.Src.DTOs;
    using Microsoft.Extensions.Logging;

    public class CalculatorService : ICalculatorService
    {
        private readonly ILogger<CalculatorService> _logger;

        public CalculatorService(ILogger<CalculatorService> logger)
        {
            _logger = logger;
        }

        public CalculationResult<decimal> Calculate(ICalculation<decimal> calculation)
        {
            var calculationResult = new CalculationResult<decimal>
            {
                Validation = calculation.Validate()
            };

            if (!calculationResult.Validation.IsValid)
            {
                return calculationResult;
            }

            calculationResult.Value = calculation.Calculate();

            _logger.LogInformation(
                "Type: {Type} | Inputs: {Inputs} | Result: {Result}",
                calculation.GetType().Name,
                calculation.GetInputsForLogMessage(),
                calculationResult.Value);

            return calculationResult;
        }
    }
}