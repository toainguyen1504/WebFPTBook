using BookFPTStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookFPTStore.Controllers
{
    public class HomeController : Controller
    {
		public readonly FptbookstoreContext _dataContext;

		public HomeController(FptbookstoreContext context)
		{
			_dataContext = context;
		}
		public IActionResult Index()
        {
		
			var data = new ViewClient
            {
                Books = _dataContext.TbBooks.ToList(),
                Categories = _dataContext.TbCategories.ToList(),
				Authors = _dataContext.TbAuthors.ToList()
			};

			return View(data);
		}

		/*public IActionResult AuthorView()
		{
			var authors = _dataContext.TbAuthors.ToList();
			return View(authors);
		}*/


		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

	}
}