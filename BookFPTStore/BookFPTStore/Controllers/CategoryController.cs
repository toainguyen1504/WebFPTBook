using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookFPTStore.Controllers
{
    public class CategoryController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
