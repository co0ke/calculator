namespace Calculator.Src.DTOs
{
    using Calculator.Src.Enums;

    public class Error
    {
        public ErrorCode ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}