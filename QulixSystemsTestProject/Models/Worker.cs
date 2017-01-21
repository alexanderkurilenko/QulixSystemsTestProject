using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QulixSystemsTestProject.Models
{
    public enum Position{
        Developer,QA,Business_Analyst,Manager
    }

    public class Worker
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public DateTime Date { get; set; }
        public Position Pos { get; set; }
        public int CompanyID { get; set; }

    }
}