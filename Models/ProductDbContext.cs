using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class ProductDbContext : DbContext
    {
        /*  override protected void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
          {
              dbContextOptionsBuilder.UseSqlServer("server=DESKTOP-B0RRSSN\\SQLEXPRESS01;database=DbEmployeNetCore;Trusted_Connection=true");

          } */
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        /* Pour gérer la persistance */
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}

