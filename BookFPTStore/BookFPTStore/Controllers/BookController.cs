using BookFPTStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookFPTStore.Controllers
{
    public class BookController : Controller
    {
		public readonly FptbookstoreContext _dataContext;
        private object category;

        public BookController(FptbookstoreContext context)
		{
			_dataContext = context;
		}
		

        public IActionResult Details(int Id)
        {
            var book = _dataContext.TbBooks
                           .Include(b => b.Category)
                           .Include(b => b.Author)
                           .FirstOrDefault(b => b.Id == Id);

            if (book == null)
            {
                return NotFound();
            }

            var data = new ViewClient
            {
                Book = book,
                Categories = _dataContext.TbCategories.ToList(),
                Authors = _dataContext.TbAuthors.ToList()
            };

            return View(data);

          
        }
    }
}
