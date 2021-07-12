using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> AllCars {
            get
            {
                return new List<Car> { new Car { name = "Tesla", shortDesc = "", longDesc = "", 
                    img = "/img/tesla-model-ljpg.jpg", price = 4500, isFavourite = true, available=true, Category=_categoryCars.AllCategories.First()}
                };

            }
        }
        public IEnumerable<Car> getFavCars { get ; set; }

        public Car getObjCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
