namespace Calculator.Src.Calculations
{
    using System.Collections.Generic;
    using Calculator.Src.DTOs;
    using Calculator.Src.Enums;

    public class CombinedWithCalculation : ICalculation<decimal>
    {
        private readonly decimal _pa;
        private readonly decimal _pb;

        // TODO: consider changing these to properties
        public CombinedWithCalculation(decimal pa, decimal pb)
        {
            _pa = pa;
            _pb = pb;
        }

        public ValidationResult Validate()
        {
            bool IsValidParam(decimal param) => param >= 0 && param <= 1;

            if (IsValidParam(_pa) && IsValidParam(_pb))
            {
                return new ValidationResult { IsValid = true };
            }

            return new ValidationResult
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
        }

        public decimal Calculate() => _pa * _pb;

        public string GetInputsForLogMessage() => $"{_pa} * {_pb}";
    }
}