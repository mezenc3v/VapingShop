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
        private IShopingDetailsRepository detailsRepository;
        private IOrderProcessor orderProcessor;


        public CartController(IElectronicCigarettesRepository repo, IOrderProcessor processor, IShopingDetailsRepository details)
        {
            repository = repo;
            detailsRepository = details;
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


        /// <summary>
        /// Сохраняет данные о покупке
        /// </summary>
        /// <param name="cart">данные корзины</param>
        /// <param name="shopingDetails">данные о покупателе</param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShopingDetails shopingDetails)
        {
            if(cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Корзина пуста!");
            }

            if(ModelState.IsValid)
            {
                
                detailsRepository.AddShopingDetails(shopingDetails);

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