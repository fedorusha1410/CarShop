using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {

        private readonly IAllOrders Allorders;

        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.Allorders = allOrders;
        }

        public IActionResult Checkout()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listShopItem = shopCart.getShopItems();
            if (shopCart.listShopItem.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары!");
            }
            if (ModelState.IsValid)
            {
                Allorders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан!";
             return View();
        }
    }
}
