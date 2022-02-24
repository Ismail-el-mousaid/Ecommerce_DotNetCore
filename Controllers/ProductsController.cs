using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext context;

        public ProductsController(ProductDbContext context)
        {
            this.context = context;
        }

        // GET
        public async Task<ActionResult> Index()
        {
            IQueryable<Product> items = from i in context.Products orderby i.Id select i;
            List<Product> products = await items.ToListAsync();
            return View(products);
        }

        // GET /Products/create
        public IActionResult Create() => View();

        // POST /Products/create
        [HttpPost]
        public async Task<ActionResult> Create(Product item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();
                TempData["Success"] = "The product has been added!";
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET /Products/edit/5
        public async Task<ActionResult> Edit(long Id)
        {
            Product item = await context.Products.FindAsync(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Product item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();
                TempData["Success"] = "The product has been updated!";
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET /Products/delete/5
        public async Task<ActionResult> Delete(long Id)
        {
            Product item = await context.Products.FindAsync(Id);
            if (item == null)
            {
                TempData["Error"] = "The product does not exist!";
            }
            else
            {
                context.Products.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The product has been deleted!";
            }
            return RedirectToAction("Index");
        }

        // GET /Products/edit/5
        public async Task<ActionResult> Details(long Id)
        {
            Product item = await context.Products.FindAsync(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }





    }
}
