using AvisFormation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormation.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            var vm = new EnvoieEmailViewModel();
            return View(vm);
        }

        public IActionResult SaveMessage(EnvoieEmailViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", viewmodel);
            }

            return View();
        }
    }
}
