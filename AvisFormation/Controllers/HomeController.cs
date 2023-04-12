using AvisFormation.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AvisFormation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IFormationRepository _repository;
        public HomeController(ILogger<HomeController> logger, IFormationRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var listFormations = _repository.GetFormations(4);
            var vm = new List<DetailFormationViewModel>();
            foreach (var f in listFormations) {
                vm.Add(new DetailFormationViewModel { Formation = f, NoteMoyenne = f.Avis.Select(a => a.Note).DefaultIfEmpty(0).Average() });
            }
            return View(vm);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}