using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QulixSystemsTestProject.Models
{
    public enum Position{
       Разработчик,Тестеровщик,Бизнес_Аналитик,Менеджер
    }

    public class Worker
    {
        public int ID { get; set; }
        
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
       
        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
       
        [Required]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }
       
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
       
        [Required]
        [Display(Name = "Должность")]
        public String Position { get; set; }

        [Required]
        public int CompanyID { get; set; }

        public string CompanyTitle { get; set; }

    }
}