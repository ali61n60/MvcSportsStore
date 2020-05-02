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
