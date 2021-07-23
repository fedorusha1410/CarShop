using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
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

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars=null;
            string carCategory = "";
            if (string.IsNullOrEmpty(_category))
            {
                cars = _allCars.AllCars.OrderBy(i => i.id);

            }
            else
            {
                if(string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.AllCars.Where(i => i.Category.Equals("Электромобиль")).OrderBy(i=>i.id);
                    carCategory = "Электромобиль";
                }
                else
                {
                    cars = _allCars.AllCars.Where(i => i.Category.Equals("Классический автомобиль")).OrderBy(i => i.id);
                    carCategory = "Классический автомобиль";
                }
                
            }
           
            var Carobj = new CarsListViewModel
            {
              allCars=cars,
              currentCategory= carCategory
            };




            ViewBag.Title = "Страница с автомобилями";
            //CarsListViewModel obj = new CarsListViewModel();
           // obj.allCars = _allCars.AllCars;
            //obj.currentCategory = "Автомобили";
            return View(Carobj); 
        }

    }
}
