using Microsoft.AspNetCore.Mvc;

namespace BookFPTStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
