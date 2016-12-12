using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VapingStore.Abstract;
using VapingStore.Entities;
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

        /// <summary>
        /// Возвращает список товаров по производителю
        /// </summary>
        /// <param name="produser">производитель</param>
        /// <param name="page">номер страницы</param>
        /// <returns>возвращает страницу с товарами</returns>
        public ActionResult List(string produser, int page = 1)
        {

            ElectronicCigarettesViewModel model = new ElectronicCigarettesViewModel
            {
                ElectronicCigarettes = repository.ElectronicCigarettes
                .Where(c => produser == null || c.Produser == produser)
                .OrderBy(cigarette => cigarette.ElectronicCigarettesId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = produser == null ?
                        repository.ElectronicCigarettes.Count() :
                        repository.ElectronicCigarettes.Where(
                            cigarette => cigarette.Produser == produser
                            ).Count()
                },
                Produser = produser

            };

            if(model.ElectronicCigarettes.Any())
            {
                return View(model);
            }
            else
            {
                return Redirect("/EmptyRequest.html");
            }


        }
        public ViewResult ElectronicCigarettes(int ElectronicCigarettesId)
        {
            ElectronicCigarettes cigarettes = repository
            .ElectronicCigarettes
            .FirstOrDefault(c => c.ElectronicCigarettesId == ElectronicCigarettesId);

            return View(cigarettes);

        }
    }
}