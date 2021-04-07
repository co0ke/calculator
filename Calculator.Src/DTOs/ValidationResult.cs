namespace Calculator.Src.DTOs
{
    using System.Collections.Generic;

    public class ValidationResult
    {
        public bool IsValid { get; set; }

        public IList<Error> Errors { get; set; } = new List<Error>();
    }
}