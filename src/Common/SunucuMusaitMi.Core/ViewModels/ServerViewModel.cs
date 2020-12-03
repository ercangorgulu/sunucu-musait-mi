using System;

namespace SunucuMusaitMi.Core.ViewModels
{
    public class ServerViewModel
    {
        public string ServerIp { get; set; }
        public bool Available { get; set; }
        public string ConnectedUser { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
