﻿using AvisFormation.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormation.Controllers
{
    public class FormationController : Controller
    {
        IFormationRepository _repository;
        public FormationController(IFormationRepository repository) {
            this._repository = repository;
        }
        public IActionResult Index()
        {
            var vm = new ToutesLesFormationsViewModel();
            vm.Message = "ceci est un message du controleur";
            vm.Nombre = 10;
            return View(vm);
        }

        public IActionResult ToutesLesFormations()
        {
            var listFormations = _repository.GetAllFormations();
            return View(listFormations);
        }

        public IActionResult DetailsFormation(string idFormation)
        {
            int iIdFormation = -1;
            if(!Int32.TryParse(idFormation, out iIdFormation))
            {
                return RedirectToAction("ToutesLesFormations");
            }
            
            var formation = _repository.GetFormationById(iIdFormation);
            if(formation == null)
            {
                return RedirectToAction("ToutesLesFormations");
            }

            var vm = new DetailFormationViewModel();
            vm.Formation = formation;
            if(formation.Avis != null && formation.Avis.Count >0) {
                vm.NoteMoyenne = formation.Avis.Select(a=>a.Note).ToList().Average();
            }
            
            return View(vm);
        }

    }
}
