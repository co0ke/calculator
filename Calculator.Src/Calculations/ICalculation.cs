namespace Calculator.Src.Calculations
{
    using Calculator.Src.DTOs;

    public interface ICalculation<T>
    {
        string GetLogMessage();

        ValidationResult Validate();

        T Calculate();
    }
}