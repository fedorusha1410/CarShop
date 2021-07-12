using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Controllers
{
    public class CarsController :Controller
    {
        private readonly IAllCars _allCars;
        
        private readonly ICarsCategory _allCatgories;

        public CarsController(IAllCars IallCars, ICarsCategory IcarsCategory)
        {
            _allCars = IallCars;
            _allCatgories = IcarsCategory;
        }
        public ViewResult List()
        {
            ViewBag.Title = "Страница с автомобилями";
            CarsListViewModel obj = new CarsListViewModel();
            obj.allCars = _allCars.AllCars;
            obj.currentCategory = "Автомобили";
            return View(obj); 
        }

    }
}
