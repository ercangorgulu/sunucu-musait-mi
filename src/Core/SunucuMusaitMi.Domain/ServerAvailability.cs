using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunucuMusaitMi.Domain
{
    [Table("ServerAvailability")]
    public class ServerAvailability
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ServerIp { get; set; }
        public bool Available { get; set; } = false;
        public string ConnectedUser { get; set; } = null;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
