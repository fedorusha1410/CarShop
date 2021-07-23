using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppBDContent appBDContent;

        private readonly ShopCart shopCart;

        public OrdersRepository(AppBDContent appBDContent, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.appBDContent = appBDContent;
        }

        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appBDContent.Order.Add(order);

            var items = shopCart.listShopItem;
            
            foreach(var el in items)
            {
                var orderDet = new OrderDetail()
                {
                    carID = el.car.id,
                    orderID = order.id,
                    price = el.car.price
                };
                appBDContent.OrderDetail.Add(orderDet);

            }
            appBDContent.SaveChanges();
        }
    }
}
