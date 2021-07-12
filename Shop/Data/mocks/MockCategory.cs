using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category> {

                new Category{NameCategory="Электро мобиль", Desc="Современный транспорт для передвижения"},
                new Category{NameCategory="Классический автомобиль", Desc="Самый простой транспорт для передвижения"}
                };
            }
        }



    }
}
