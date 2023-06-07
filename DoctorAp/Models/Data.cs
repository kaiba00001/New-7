using Microsoft.AspNetCore.Mvc;

namespace DoctorAp.Models
{
    public class Data : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
