using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class AppBDContent : DbContext
    {
        public AppBDContent(DbContextOptions<AppBDContent> options) : base(options) { }

        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem{ get; set; }


    }
}
