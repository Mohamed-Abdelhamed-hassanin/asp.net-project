using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using aspDotNetApp.Domain;

namespace aspDotNetApp.Data
{
    public class UniDbContext : DbContext
    {
        public DbSet<Universties> Universties { set; get; }
        public DbSet<Students> Students { set; get; }
        public UniDbContext(DbContextOptions<UniDbContext> options):base(options){
            
        }
    }
}
