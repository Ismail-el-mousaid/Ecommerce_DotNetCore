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
    [Route("/api/categories")]
    public class CategoryRestAPI : Controller
    {
        public ProductDbContext productDbContext { get; set; }

        public CategoryRestAPI(ProductDbContext context)
        {
            this.productDbContext = context;
        }

        [HttpGet]
        public IEnumerable<Category> listCategory()
        {
            return productDbContext.Categories;
        }

        [HttpGet("{Id}")]
        public Category getCategory(int Id)
        {
            return productDbContext.Categories.FirstOrDefault(p => p.CategoryID == Id);
        }

        //Pour consulter les produits d'une catégorie
        [HttpGet("{Id}/products")]
        public IEnumerable<Product> products(int Id)
        {
            Category category = productDbContext.Categories.Include(c=>c.Products).FirstOrDefault(p => p.CategoryID == Id);
            return category.Products;
        }

        [HttpPost]
        public Category Save([FromBody] Category category)
        {
            productDbContext.Categories.Add(category);
            productDbContext.SaveChanges();
            return category;
        }

        [HttpPut("{Id}")]
        public Category Update([FromBody] Category category, int Id)
        {
            category.CategoryID = Id;
            productDbContext.Categories.Update(category);
            productDbContext.SaveChanges();
            return category;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            Category category = productDbContext.Categories.FirstOrDefault(p => p.CategoryID == Id);
            productDbContext.Remove(category);
            productDbContext.SaveChanges();
        }


    }
}
