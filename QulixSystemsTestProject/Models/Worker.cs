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
        public string Name { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string SurName { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
       
        public String Position { get; set; }
        public int CompanyID { get; set; }
        public string CompanyTitle { get; set; }

    }
}