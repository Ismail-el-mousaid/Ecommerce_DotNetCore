using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    //API Rest
    [Route("/api/products")]
    public class ProductRestAPI : Controller
    {
        public ProductDbContext productDbContext { get; set; }

        public ProductRestAPI(ProductDbContext context)
        {
            this.productDbContext = context;
        }

        [HttpGet]
        public IEnumerable<Product> listProducts()
        {
            return productDbContext.Products.Include(p=>p.Category);
        }

        //Pour chercher un produit à travers son name  (/api/products?search="ip")
        [HttpGet("search")]
        public IEnumerable<Product> search(string kw)
        {
            return productDbContext.Products.Include(p => p.Category).Where(p => p.Name.Contains(kw));
        }

        [HttpGet("{Id}")]
        public Product getProduct(int Id)
        {
            return productDbContext.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == Id);
        }

        [HttpPost]
        public Product Save([FromBody] Product product)
        {
            productDbContext.Products.Add(product);
            productDbContext.SaveChanges();
            return product;
        }

        [HttpPut("{Id}")]
        public Product Update([FromBody] Product product, int Id)
        {
            product.Id = Id;
            productDbContext.Products.Update(product);
            productDbContext.SaveChanges();
            return product;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            Product product = productDbContext.Products.FirstOrDefault(p => p.Id == Id);
            productDbContext.Remove(product);
            productDbContext.SaveChanges();
        }


    }
}
