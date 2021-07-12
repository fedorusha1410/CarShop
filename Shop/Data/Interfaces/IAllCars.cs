using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
         public interface IAllCars
    {
        IEnumerable<Car> AllCars { get; }
        
        IEnumerable<Car> getFavCars { get; }

        Car getObjCar(int carId);



    }
}
