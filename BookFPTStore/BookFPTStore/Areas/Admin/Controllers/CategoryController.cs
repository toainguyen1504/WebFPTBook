using BookFPTStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookFPTStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class CategoryController : Controller
    {

        public readonly FptbookstoreContext _dataContext;

        public CategoryController(FptbookstoreContext context)
        {
            _dataContext = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.TbCategories.OrderByDescending(p => p.Id).ToListAsync());
        }
        /*public IActionResult Index()
        {
            var categories = _dataContext.TbCategories.ToList();
            return View(categories);
        }*/
     

        public IActionResult Create(TbCategory category)
        {
            if (ModelState.IsValid)
            {
                _dataContext.TbCategories.Add(category);
                TempData["success"] = "Add Category Sucessfully!";
                _dataContext.SaveChanges();
                return RedirectToAction("Index"); 
            } 
            return View(category); 
        }

        public async Task<IActionResult> Edit(int Id)
        {
            TbCategory category = await _dataContext.TbCategories.FindAsync(Id);
            return View(category);
        }
        public IActionResult Update(TbCategory category)
        {
            if (ModelState.IsValid)
            {
                _dataContext.TbCategories.Update(category);
                TempData["success"] = "Update Category Sucessfully!";
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            TbCategory category = await _dataContext.TbCategories.FindAsync(Id);
            _dataContext.TbCategories.Remove(category);
            await _dataContext.SaveChangesAsync();
            TempData["success"] = "Delete Successful!";

            return RedirectToAction("Index");
        }

    }
}
