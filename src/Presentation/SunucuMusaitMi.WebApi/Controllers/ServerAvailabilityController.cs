using MediatR;
using Microsoft.AspNetCore.Mvc;
using SunucuMusaitMi.Application;
using SunucuMusaitMi.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunucuMusaitMi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerAvailabilityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServerAvailabilityController(IMediator mediator)
        {
            _mediator = mediator;
        }



        // GET: api/ServerAvailability
        [HttpGet]
        public async Task<IEnumerable<ServerViewModel>> Get()
        {
            var result = await _mediator.Send(new GetServerAvailabilityRequest());
            return result.Select(c => new ServerViewModel
            {
                Available = c.Available,
                ConnectedUser = c.ConnectedUser,
                LastUpdate = c.LastUpdate,
                ServerIp = c.ServerIp
            });
        }

        // GET: api/ServerAvailability/10.0.0.5
        [HttpGet("{serverIp}", Name = "Get")]
        public async Task<CheckServerViewModel> Get(string serverIp)
        {
            var result = await _mediator.Send(new GetServerAvailabilityRequest { ServerIp = serverIp });
            if (!result.Any())
            {
                return null;
            }
            var serverInfo = result.First();
            return new CheckServerViewModel
            {
                Available = serverInfo.Available,
                ConnectedUser = serverInfo.ConnectedUser
            };
        }

        // POST: api/ServerAvailability
        [HttpPost]
        public async Task Post([FromBody] UpdateServerAvailabilityRequest request)
        {
            await _mediator.Send(request);
        }
    }
}
