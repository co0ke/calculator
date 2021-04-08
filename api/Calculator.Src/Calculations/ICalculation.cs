namespace Calculator.Src.Calculations
{
    using Calculator.Src.DTOs;

    public interface ICalculation<T>
    {
        ValidationResult Validate();

        T Calculate();

        string GetInputsForLogMessage();
    }
}