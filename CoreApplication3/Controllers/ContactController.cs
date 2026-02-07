using Microsoft.AspNetCore.Mvc;

namespace CoreApplication3.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
