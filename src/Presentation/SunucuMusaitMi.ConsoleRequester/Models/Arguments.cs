using CommandLine;

namespace SunucuMusaitMi.ConsoleRequester.Models
{
    public class Arguments
    {
        [Option('h', "host", Required = true, HelpText = "Ip address of the server")]
        public string ServerIp { get; set; }

        [Option('a', "available", Required = false, HelpText = "Value to set server's availability")]
        public bool Available { get; set; }

        [Option('n', "name", Required = true, HelpText = "User name to set info")]
        public string ConnectedUser { get; set; }
    }
}