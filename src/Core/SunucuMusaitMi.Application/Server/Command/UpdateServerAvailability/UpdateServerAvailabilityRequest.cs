using MediatR;

namespace SunucuMusaitMi.Application
{
    public class UpdateServerAvailabilityRequest : IRequest
    {
        public string Token { get; set; }
        public string ServerIp { get; set; }
        public bool Available { get; set; }
    }
}
