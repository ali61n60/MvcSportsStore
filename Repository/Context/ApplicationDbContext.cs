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
        IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()) // Directory where the json files are located
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {        }
        public ApplicationDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration["Data:SportStoreProducts:ConnectionString"],
                x => x.MigrationsHistoryTable("__MigrationsHistory", "ad"));
        }
        public DbSet<Product> Products { get; set; }
    }
}
