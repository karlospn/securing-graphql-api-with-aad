using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Client.WebApi.Controllers
{
    [ApiController]
    [Route("/invoke")]
    public class InvokeGraphApiController : ControllerBase
    {

        private readonly ILogger<InvokeGraphApiController> _logger;

        public InvokeGraphApiController(ILogger<InvokeGraphApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
