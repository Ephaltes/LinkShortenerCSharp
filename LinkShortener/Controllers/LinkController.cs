using System;
using System.Threading.Tasks;
using LinkShortener.Api;
using LinkShortener.Application.Command;
using LinkShortener.Application.Interface;
using LinkShortener.Application.Query;
using LinkShortener.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinkShortener.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LinkController(ILogger<LinkController> logger, IMediator mediator, IRepository db)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{sluge}")]
        public async Task<IActionResult> GetLink(string sluge)
        {
            var query = new GetLinkQuery(sluge);
            var result = await  _mediator.Send(query);
            return result.ToResponse();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateLink([FromBody]CreateLinkCommand command)
        {

                var result = await _mediator.Send(command);
                return result.ToResponse();
        }
    }
}