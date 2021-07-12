using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppBDContent appBDContent;
        
        public CarRepository(AppBDContent appBDContent )
        {
            this.appBDContent = appBDContent;
        }

        public IEnumerable<Car> AllCars => appBDContent.Car.Include(c => c.Category).ToList();

        public IEnumerable<Car> getFavCars => appBDContent.Car.Where(p => p.isFavourite).Include(c => c.Category);

        public Car getObjCar(int carId) => appBDContent.Car.FirstOrDefault(p => p.id == carId);
        
    }
}
