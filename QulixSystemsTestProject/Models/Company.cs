using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QulixSystemsTestProject.Models
{
     public class Company
    {

        public int ID { get; set; }
       
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [RegularExpression(@"\d+", ErrorMessage = "Некорректное число")]
        [Display(Name = "Количество сотрудников")]
        public int Size { get; set; }
        
        [Required]
        [Display(Name = "Форма организации")]
        public string Form { get; set; }
    }
}