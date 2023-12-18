using BookFPTStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookFPTStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        public readonly FptbookstoreContext _dataContext;

        public AuthorController(FptbookstoreContext context)
        {
            _dataContext = context;
        }
        public IActionResult Index()
        {
            var authors = _dataContext.TbAuthors.ToList();
            return View(authors);
        }
        public IActionResult Create(TbAuthor author)
        {
            if (ModelState.IsValid)
            {
                _dataContext.TbAuthors.Add(author);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author); 
        }

        public async Task<IActionResult> Delete(int Id)
        {
            TbAuthor author = await _dataContext.TbAuthors.FindAsync(Id);
            _dataContext.TbAuthors.Remove(author);
            await _dataContext.SaveChangesAsync();
            TempData["success"] = "Delete Successful!";

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            TbAuthor author = _dataContext.TbAuthors.Find(id);

            if (author == null)
            {
                return NotFound(); // Handle the case where the author is not found
            }

            return View(author);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
         public IActionResult Edit(int id, [Bind("Id,Name,AddressEmail")] TbAuthor model)
        {
            if (id != model.Id)
            {
                return NotFound(); // Handle the case where the provided id doesn't match the model id
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TbAuthor existingAuthor = _dataContext.TbAuthors.Find(id);

                    if (existingAuthor == null)
                    {
                        return NotFound(); // Handle the case where the author is not found
                    }

                    // Update the fields of the existing author
                    existingAuthor.Name = model.Name;
                    // Update other fields as needed

                    _dataContext.SaveChanges();
                    TempData["success"] = "Edit Successful!";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle concurrency issues if necessary
                    throw;
                }
            }

            return View(model);
        }
    }
}
