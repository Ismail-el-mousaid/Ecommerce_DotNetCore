using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductDbContext context;

        public CategoryController(ProductDbContext context)
        {
            this.context = context;
        }

        // GET
        public async Task<ActionResult> Index()
        {
            IQueryable<Category> items = from i in context.Categories orderby i.CategoryID select i;
            List<Category> categories = await items.ToListAsync();
            return View(categories);
        }

        // GET /Category/create
        public IActionResult Create() => View();

        // POST /Category/create
        [HttpPost]
        public async Task<ActionResult> Create(Category item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();
                TempData["Success"] = "The category has been added!";
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET /Category/edit/5
        public async Task<ActionResult> Edit(int Id)
        {
            Category item = await context.Categories.FindAsync(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Category item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();
                TempData["Success"] = "The Category has been updated!";
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET /Products/delete/5
        public async Task<ActionResult> Delete(int Id)
        {
            Category item = await context.Categories.FindAsync(Id);
            if (item == null)
            {
                TempData["Error"] = "The Category does not exist!";
            }
            else
            {
                context.Categories.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Category has been deleted!";
            }
            return RedirectToAction("Index");
        }


        


    }
}
