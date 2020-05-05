using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//Add-Migration Initial
//Update-Database
namespace Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        private string _connectioString;
    
        public ApplicationDbContext()
        {
            _connectioString = "Data Source= .\\;Initial Catalog=SportsStore;Persist Security Info=True;User ID=ayoobfar_ali;Password=119801;MultipleActiveResultSets=true";
        }
        public ApplicationDbContext(string s) {
            _connectioString = s;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectioString,
                x => x.MigrationsHistoryTable("__MigrationsHistory", "ad"));
        }
        public DbSet<Product> Products { get; set; }
    }
}
