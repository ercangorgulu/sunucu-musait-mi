using Flurl;
using Flurl.Http;
using SunucuMusaitMi.ConsoleRequester.Models;

namespace SunucuMusaitMi.ConsoleRequester
{
    public class ServerAvailabilityManager
    {
        private readonly ServerConfiguration _serverConfiguration;

        public ServerAvailabilityManager(ServerConfiguration serverConfiguration)
        {
            _serverConfiguration = serverConfiguration;
        }

        public void SetAvailability(string serverIp, string connectedUser, bool available)
        {
            _serverConfiguration.ApiUrl
                .AppendPathSegment("ServerAvailability")
                .PostJsonAsync(new UpdateServerAvailabilityRequest
                {
                    Available = available,
                    ConnectedUser = connectedUser,
                    ServerIp = serverIp,
                    Token = _serverConfiguration.AuthToken
                })
                .ReceiveJson<object>()
                .Wait();
        }

        public CheckServerResponse CheckAvailability(string serverIp)
        {
            return _serverConfiguration.ApiUrl
                .AppendPathSegment("ServerAvailability")
                .AppendPathSegment(serverIp)
                .GetAsync()
                .ReceiveJson<CheckServerResponse>()
                .Result;
        }
    }
}
