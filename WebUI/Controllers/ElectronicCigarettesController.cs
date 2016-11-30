using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VapingStore.Abstract;
using VapingStore.Models;

namespace VapingStore.Controllers
{
    public class ElectronicCigarettesController : Controller
    {
        private IElectronicCigarettesRepository repository;

        public int pageSize = 5;

        public ElectronicCigarettesController(IElectronicCigarettesRepository repo)
        {
            repository = repo;
        }      

        public ViewResult List(string category, int page = 1)
        {

            ElectronicCigarettesViewModel model = new ElectronicCigarettesViewModel
            {
                ElectronicCigarettes = repository.ElectronicCigarettes
                .Where(c=> category == null || c.CurrentCategory == category)
                .OrderBy(cigarette => cigarette.ElectronicCigarettesId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                        repository.ElectronicCigarettes.Count() :
                        repository.ElectronicCigarettes.Where( 
                            cigarette => cigarette.CurrentCategory == category
                            ).Count()
                },
                CurrentCategory = category

            };

            return View(model);
        }
}
}