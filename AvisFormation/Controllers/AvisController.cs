using AvisFormation.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormation.Controllers
{
    public class AvisController : Controller
    {
        IFormationRepository _repository;
        IAvisRepository _avisRepository;
        public AvisController(IFormationRepository repository, IAvisRepository avisRepository)
        {
            this._repository = repository;
            this._avisRepository = avisRepository;
        }
        public IActionResult LaisserUnAvis(string idFormation)
        {
            int iIdFormation = -1;
            if (!Int32.TryParse(idFormation, out iIdFormation))
            {
                return RedirectToAction("ToutesLesFormations", "Formation");
            }
            
            var formation = _repository.GetFormationById(iIdFormation);
            if (formation == null)
            {
                return RedirectToAction("ToutesLesFormations", "Formation");
            }

            var vm = new LaisserUnAvisViewModel();
            vm.NomFormation = formation.Nom;
            vm.IdFormation = formation.Id.ToString();
            return View(vm);
        }

        [HttpPost]
        public IActionResult SaveComment(LaisserUnAvisViewModel viewModel)
        {
            //if(!ModelState.IsValid)
            //{
            //   return View("LaisserUnAvis", viewModel);
            //}

            if (String.IsNullOrEmpty(viewModel.Nom) || String.IsNullOrEmpty(viewModel.Note)) {
                return View("LaisserUnAvis", new {idFormation = viewModel.IdFormation});
            }

            
            _avisRepository.SaveAvis(viewModel.Commentaire, viewModel.Nom, viewModel.IdFormation, viewModel.Note);

            return RedirectToAction("DetailsFormation", "Formation", new {idFormation =viewModel.IdFormation});
        }
    }
}
