using Microsoft.AspNetCore.Mvc;

namespace BookFPTStore.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
