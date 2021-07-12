using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Category
    {
        public int id { get; set; }

        public string NameCategory { get; set; }
        
        public string Desc { get; set; }

        public List<Car> cars { get; set; }

       
       
    }
}
