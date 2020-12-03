namespace SunucuMusaitMi.ConsoleRequester.Models
{
    public class UpdateServerAvailabilityRequest
    {
        public string Token { get; set; }
        public string ServerIp { get; set; }
        public string ConnectedUser { get; set; }
        public bool Available { get; set; }
    }
}
