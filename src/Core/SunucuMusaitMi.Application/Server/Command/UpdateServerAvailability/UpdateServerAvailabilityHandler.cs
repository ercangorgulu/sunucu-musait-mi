using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SunucuMusaitMi.Core.Configurations;
using SunucuMusaitMi.Domain;
using SunucuMusaitMi.Persistance;
using System;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace SunucuMusaitMi.Application
{
    public class UpdateServerAvailabilityHandler : IRequestHandler<UpdateServerAvailabilityRequest>
    {
        private readonly IOptions<ApiConfiguration> _apiOptions;
        private readonly ApplicationDbContext _context;

        public UpdateServerAvailabilityHandler(IOptions<ApiConfiguration> apiOptions, ApplicationDbContext context)
        {
            _apiOptions = apiOptions;
            _context = context;
        }

        public async Task<Unit> Handle(UpdateServerAvailabilityRequest request, CancellationToken cancellationToken)
        {
            if (_apiOptions.Value.AuthToken != request.Token)
            {
                throw new AuthenticationException($"Requested token is invalid: {request.Token}");
            }

            var serverAvailability = await _context.ServerAvailability.FirstOrDefaultAsync(
                c => c.ServerIp == request.ServerIp,
                cancellationToken: cancellationToken);

            if (serverAvailability == null)
            {
                serverAvailability = new ServerAvailability
                {
                    ServerIp = request.ServerIp
                };
                await _context.AddAsync(serverAvailability);
            }

            serverAvailability.Available = request.Available;
            serverAvailability.LastUpdate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
