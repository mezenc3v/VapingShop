using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VapingStore.Abstract;
using VapingStore.Entities;

namespace VapingStore.Controllers
{
    public class AdminController : Controller
    {
        IElectronicCigarettesRepository repository;

        public AdminController(IElectronicCigarettesRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.ElectronicCigarettes);
        }

        public ViewResult Edit(int electronicCigarettesId)
        {
            ElectronicCigarettes cigarettes = repository.ElectronicCigarettes.FirstOrDefault(
                c => c.ElectronicCigarettesId == electronicCigarettesId);

            return View(cigarettes);
        }
        [HttpPost]
        public ActionResult Edit(ElectronicCigarettes electronicCigarettes)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCigarettes(electronicCigarettes);
                TempData["message"] = string.Format("Изменения информации о товаре \"{0}\" сохранены.", electronicCigarettes.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(electronicCigarettes);
            }
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(ElectronicCigarettes electronicCigarettes)
        {
            if (ModelState.IsValid)
            {
                repository.DelCigarettes(electronicCigarettes);
                TempData["message"] = string.Format("Товар \"{0}\" удален.", electronicCigarettes.Name);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Create(ElectronicCigarettes electronicCigarettes)
        {
            if (ModelState.IsValid)
            {
                repository.AddCigarettes(electronicCigarettes);
                TempData["message"] = string.Format("Товар \"{0}\" добавлен.", electronicCigarettes.Name);
                return RedirectToAction("Index");
            }

            return View(electronicCigarettes);
        }
    }
}