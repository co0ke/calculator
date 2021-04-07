using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calculator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {
        private readonly ILogger<CalculateController> _logger;

        public CalculateController(ILogger<CalculateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("CombinedBy")]
        public ActionResult CombinedBy(decimal pa, decimal pb)
        {
            var response = new
            {
                Pa = pa,
                Pb = pb,
                Errors = new string[0]
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("Either")]
        public ActionResult Either(decimal pa, decimal pb)
        {
            var response = new
            {
                Pa = pa,
                Pb = pb,
                Errors = new string[0]
            };

            return Ok(response);
        }
    }
}
