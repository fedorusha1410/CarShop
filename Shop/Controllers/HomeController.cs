using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;

        private readonly ShopCart _shopCar;

        public HomeController(IAllCars carRepository)
        {

            this._carRep = carRepository;
            

        }
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel()
            {
                FavCars = _carRep.getFavCars
            };
            

            return View(homeCars);
        }


    }
}
