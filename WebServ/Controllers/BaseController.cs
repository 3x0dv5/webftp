using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServ.Data;

namespace WebServ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        public ApplicationDbContext DbContext { get; }

        public BaseController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
