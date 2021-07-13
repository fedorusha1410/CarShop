using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppBDContent appBDContent;

        public ShopCart(AppBDContent appBDContent)
        {
            this.appBDContent = appBDContent;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItem { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppBDContent>();
            string shopCartId = session.GetString("CardId") ?? Guid.NewGuid().ToString();
            session.SetString("CardId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };

        }

        public void AddToCar(Car car) {
           appBDContent.ShopCartItem.Add(new ShopCartItem { 
            ShopCartId=ShopCartId,
            car=car,
            price =car.price
            });

            appBDContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return appBDContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
            
        }
    }
}
