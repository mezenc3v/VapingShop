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
    public class CartController : Controller
    {
        private IElectronicCigarettesRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IElectronicCigarettesRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int electronicCigarettesId, string returnUrl)
        {
            ElectronicCigarettes cigarettes = repository.ElectronicCigarettes
                .FirstOrDefault(c => c.ElectronicCigarettesId == electronicCigarettesId);

            if(cigarettes !=null)
            {
                cart.AddItem(cigarettes,1); 
            }

            return RedirectToAction("Index", new { returnUrl});
        }


        public RedirectToRouteResult RemoveFromCart(Cart cart, int electronicCigarettesId, string returnUrl)
        {
            ElectronicCigarettes cigarettes = repository.ElectronicCigarettes
                .FirstOrDefault(c => c.ElectronicCigarettesId == electronicCigarettesId);

            if (cigarettes != null)
            {
                cart.RemoveLine(cigarettes);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShopingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShopingDetails shopingDetails)
        {
            if(cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Корзина пуста!");
            }

            if(ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shopingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(new ShopingDetails());
            }
        }
    }
}