namespace Calculator.Api.Controllers
{
    using Calculator.Src.Calculations;
    using Calculator.Src.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculateController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        [Route("CombinedWith")]
        public ActionResult CombinedWith(decimal pa, decimal pb)
        {
            var calculation = new CombinedWithCalculation(pa, pb);

            var result = _calculatorService.Calculate(calculation);

            return Ok(result);
        }

        [HttpGet]
        [Route("Either")]
        public ActionResult Either(decimal pa, decimal pb)
        {
            var calculation = new EitherCalculation(pa, pb);

            var result = _calculatorService.Calculate(calculation);

            return Ok(result);
        }
    }
}
