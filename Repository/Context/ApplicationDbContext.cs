using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

//Add-Migration Initial
//Update-Database
namespace Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        string _connectionString = "Data Source= .\\;Initial Catalog=SportsStore;Persist Security Info=True;User ID=ayoobfar_ali;Password=119801;MultipleActiveResultSets=true";
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {        }
        public ApplicationDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString,
                x => x.MigrationsHistoryTable("__MigrationsHistory", "ad"));
        }
        public DbSet<Product> Products { get; set; }
    }
}
