using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebServ.Data.Models;

namespace WebServ.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<FtpClient> FtpClients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
    }
}
