using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppBDContent appBDContent;

        public CategoryRepository(AppBDContent appBDContent)
        {
            this.appBDContent = appBDContent;
        }

        public IEnumerable<Category> AllCategories => appBDContent.Category;
    }
}
