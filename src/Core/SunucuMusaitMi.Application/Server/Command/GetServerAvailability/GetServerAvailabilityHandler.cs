using MediatR;
using Microsoft.EntityFrameworkCore;
using SunucuMusaitMi.Domain;
using SunucuMusaitMi.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SunucuMusaitMi.Application
{
    public class GetServerAvailabilityHandler : IRequestHandler<GetServerAvailabilityRequest, List<ServerAvailability>>
    {
        private readonly ApplicationDbContext _context;

        public GetServerAvailabilityHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<ServerAvailability>> Handle(
            GetServerAvailabilityRequest request, CancellationToken cancellationToken)
        {
            var queryable = _context.ServerAvailability.AsQueryable();
            if (request.Available.HasValue)
            {
                queryable = queryable.Where(c => c.Available == request.Available.HasValue);
            }
            if (!string.IsNullOrEmpty(request.ServerIp))
            {
                queryable = queryable.Where(c => c.ServerIp == request.ServerIp);
            }

            return queryable.ToListAsync(cancellationToken);
        }
    }
}