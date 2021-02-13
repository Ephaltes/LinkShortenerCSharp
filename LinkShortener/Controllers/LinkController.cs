using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinkShortener.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkController : ControllerBase
    {
        private readonly ILogger<LinkController> _logger;

        public LinkController(ILogger<LinkController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{sluge=}")]
        public string Get(string sluge)
        {
            if (string.IsNullOrWhiteSpace(sluge))
                return "empty";

            return sluge;
        }
    }
}