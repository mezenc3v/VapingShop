using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VapingStore.Abstract;

namespace VapingStore.Controllers
{
    public class NavController : Controller
    {
        private IElectronicCigarettesRepository repository;

        public NavController(IElectronicCigarettesRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string produser = "")
        {
            ViewBag.SelectedCategory = produser;
            IEnumerable<string> categories = repository.ElectronicCigarettes
                .Select(cigarette => cigarette.Produser)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}