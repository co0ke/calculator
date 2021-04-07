namespace Calculator.Src.DTOs
{
    public class CalculationResult<T>
    {
        public T Value { get; set; }

        public ValidationResult Validation { get; set; } = new ValidationResult();
    }
}