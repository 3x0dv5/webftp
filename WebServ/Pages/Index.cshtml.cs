using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebServ.Data;
using WebServ.Data.Models;

namespace WebServ.Pages
{
    public class IndexModel : PageModel
    {
        public ApplicationDbContext DbContext { get; }
        private readonly ILogger<IndexModel> _logger;

        public List<FtpClient> FtpClients { get; set;  } = new List<FtpClient>();

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            _logger = logger;
        }

        public void OnGet()
        {
            FtpClients = DbContext.FtpClients.Where(m => m.ConnectionClosed == null).ToList();
        }
    }
}
