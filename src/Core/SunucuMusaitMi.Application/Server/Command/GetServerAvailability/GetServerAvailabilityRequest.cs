using MediatR;
using SunucuMusaitMi.Domain;
using System.Collections.Generic;

namespace SunucuMusaitMi.Application
{
    public class GetServerAvailabilityRequest : IRequest<List<ServerAvailability>>
    {
        public bool? Available { get; set; }
        public string ServerIp { get; set; }
    }
}
