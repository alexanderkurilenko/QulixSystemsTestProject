using QulixSystemsTestProject.Models.Repositories;
using QulixSystemsTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QulixSystemsTestProject.Controllers
{
    public class WorkerController : Controller
    {
        
        IRepository<Worker> rep; 
        IRepository<Company>_rep ;

        public WorkerController(){
            rep= new WorkerRepository();
            _rep = new CompanyRepository(); 
        }
        
        public ActionResult Add()
        {
            var query = _rep.List();
            ViewBag.Companies = query;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Worker _worker)
        {
            if (ModelState.IsValid)
            {
                rep.Add(_worker);
                return RedirectToAction("List", "Worker");
            }
            return View(_worker);
           
        }

        public ActionResult List()
        {
            ViewBag.Companies = _rep.List();
            var query = rep.List();
            return View(query);
        }
        
        public ActionResult Delete(int id)
        {
            rep.Delete(id);
            return RedirectToAction("List", "Worker");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Companies = _rep.List();
            return View("Add", rep.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Worker _worker)
        {
            rep.Update(_worker);
            return RedirectToAction("List", "Worker");
        }
	}
}