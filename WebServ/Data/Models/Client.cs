using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServ.Data.Models
{
    public class FtpClient
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public string InstanceId { get; set; }
        public DateTime LastPing { get; set; }
        public DateTime FirstPing { get; set; }
        public DateTime? ConnectionClosed { get; set; }

    }
}
