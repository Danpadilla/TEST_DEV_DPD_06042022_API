using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokaWeb.API.Models;

namespace TokaWeb.API.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("Server=cqkjiencpjux.us-west-1.rds.amazonaws.com;Database=;User ID=;Password=");
            }
        }
        public DbSet<PersonasFisicas> Tb_PersonasFisicas { get; set; }
    }
}
