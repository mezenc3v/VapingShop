using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Models;
namespace WebUI.Controllers
{
    public class ElectronicCigarettesController : Controller
    {
        private IElectronicCigarettesRepository repository;

        public int pageSize = 5;

        public ElectronicCigarettesController(IElectronicCigarettesRepository repo)
        {
            repository = repo;
        }      

        public ViewResult List(int page = 1)
        {

            ElectronicCigarettesViewModel model = new ElectronicCigarettesViewModel
            {
                ElectronicCigarettes = repository.ElectronicCigarettes
                .OrderBy(cigarette => cigarette.ElectronicCigarettesId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.ElectronicCigarettes.Count()
                }

            };

            return View(model);
        }
}
}