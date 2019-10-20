using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServ.Data;
using WebServ.Data.Models;

namespace WebServ.Controllers
{
    public class FtpClientController : BaseController
    {
        public FtpClientController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        [HttpPost("register-client")]
        public IActionResult RegisterClient(Shared.FtpClientModel model)
        {
            var now = DateTime.UtcNow;

            var ftpClient = new FtpClient
            {
                MachineName = model.MachineName, 
                InstanceId = model.InstanceId, 
                FirstPing = now
            };

            DbContext.FtpClients.Add(ftpClient);
            DbContext.SaveChanges();
            return Ok();
        }
    }
}