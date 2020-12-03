using CommandLine;
using Microsoft.Extensions.Configuration;
using SunucuMusaitMi.ConsoleRequester.Models;
using System;
using System.Runtime.InteropServices;

namespace SunucuMusaitMi.ConsoleRequester
{
    internal partial class Program
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Arguments>(args)
                   .WithParsed(o =>
                   {
                       Run(o);
                   });
        }

        private static void Run(Arguments args)
        {
            var configuration = GetConfiguration();
            var serverConfiguration = configuration.GetSection("ServerConfiguration")
                .Get<ServerConfiguration>();

            var serverAvailabilityManager = new ServerAvailabilityManager(serverConfiguration);

            if (!args.Available)
            {
                var checkResponse = serverAvailabilityManager.CheckAvailability(args.ServerIp);
                if (!checkResponse.Available)
                {
                    var messageConfiguration = configuration.GetSection("MessageConfiguration")
                        .Get<MessageConfiguration>();

                    MessageBox((IntPtr)0,
                        string.Format(messageConfiguration.Message, checkResponse.ConnectedUser),
                        messageConfiguration.Title, 0);
                }
            }
            serverAvailabilityManager.SetAvailability(args.ServerIp, args.ConnectedUser, args.Available);
        }

        private static IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddYamlFile("appsettings.yml");
            return configurationBuilder.Build();
        }
    }
}