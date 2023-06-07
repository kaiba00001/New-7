using Microsoft.AspNetCore.Mvc;

namespace DoctorAp.Controllers
{
    public class ContactsController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }
    }
}
