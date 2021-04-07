namespace Calculator.Src.Services
{
    using Calculator.Src.Calculations;
    using Calculator.Src.DTOs;

    public interface ICalculatorService
    {
        CalculationResult<decimal> Calculate(ICalculation<decimal> calculation);
    }
}