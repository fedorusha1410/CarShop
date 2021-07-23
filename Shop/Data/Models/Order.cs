using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина имени не менее 10 символов")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(5)]
        [Required(ErrorMessage = "Длина фамилии не менее 5 символов")]
        public string surname { get; set; }

        [Display(Name = "Введите адрес")]
        [StringLength(5)]
        [Required(ErrorMessage = "Длина адреса не менее 5 символов")]
        public string adress { get; set; }

        [Display(Name = "Введите телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(7)]
        [Required(ErrorMessage = "Длина номера телефона не менее 7 символов")]
        public string phone { get; set; }

        [Display(Name = "Введите емаил")]
        [DataType(DataType.EmailAddress)]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина имени не менее 10 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }




    }
}
