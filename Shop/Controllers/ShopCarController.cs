using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModel;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Controllers
{
    public class ShopCarController : Controller
    {
        private readonly IAllCars _carRep;

        private readonly ShopCart _shopCar;

        public ShopCarController(IAllCars carRepository, ShopCart shopCart) {

            this._carRep = carRepository;
            this._shopCar = shopCart;
            
        }

        public ViewResult Index()
        {
            var items = _shopCar.getShopItems();
            _shopCar.listShopItem = items;
            var obj = new ShopCartViewModel
            {
                shopCart = _shopCar
            };

            return View(model: obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.AllCars.FirstOrDefault(i=>i.id==id);
            if (item != null)
            {
                _shopCar.AddToCar(item);
            }
            return RedirectToAction("Index");
            


        }

    }
}
