namespace Calculator.Src.Services
{
    using Calculator.Src.Calculations;
    using Calculator.Src.DTOs;

    public class CalculatorService
    {
        public CalculationResult<decimal> Calculate(ICalculation<decimal> calculation)
        {
            var validationResult = calculation.Validate();
            if (!validationResult.IsValid)
            {
                return new CalculationResult<decimal>
                {
                    Validation = validationResult
                };
            }

            // TODO: log
            

            return new CalculationResult<decimal>
            {
                Result = calculation.Calculate()
            };
        }
    }
}