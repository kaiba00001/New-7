using Microsoft.AspNetCore.Mvc;

namespace DoctorAp.Controllers
{
    public class StuffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Nav()
        {
            return View();
        }
    }
}
