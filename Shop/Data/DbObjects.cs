using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DbObjects
    {
        public static void Initial(AppBDContent content) {
           
          
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(content => content.Value));
            }
            if (!content.Car.Any())
            {
                content.Car.AddRange(
                    new Car
                    {
                        name = "Tesla",
                        shortDesc = "",
                        longDesc = "",
                        img = "/img/tesla-model-ljpg.jpg",
                        price = 4500,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Электромобиль"]
                    },
                     new Car
                     {
                         name = "Volvo",
                         shortDesc = "",
                         longDesc = "",
                         img = "/img/tesla-model-ljpg.jpg",
                         price = 2500,
                         isFavourite = true,
                         available = true,
                         Category = Categories["Классический автомобиль"]
                     }
                    );
            }
            content.SaveChanges();

        }

     
        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get {
                if (categories == null)
                {
                    var list = new Category[]
                    {
                         new Category{NameCategory="Электромобиль", Desc="Современный транспорт для передвижения"},
                         new Category{NameCategory="Классический автомобиль", Desc="Самый простой транспорт для передвижения"}
                    };
                    categories = new Dictionary<string, Category>();
                    foreach(Category elem in list)
                    {
                        categories.Add(elem.NameCategory, elem);
                    }
                }
                return categories;
            }
        }
    }
}
