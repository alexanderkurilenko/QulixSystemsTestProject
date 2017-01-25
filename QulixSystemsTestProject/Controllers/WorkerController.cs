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
            SelectList companies = new SelectList(_rep.List(),"Id","Title");
            var query = _rep.List();
            ViewBag.Companies = companies;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Worker _worker)
        {
            ViewBag.Companies = _rep.List();
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
            var worker = rep.Find(id);
            if (worker != null)
            {
                SelectList companies = new SelectList(_rep.List(), "Id", "Title", worker.CompanyID);
                ViewBag.Companies = companies;
                return View("Add", worker);
            }
            return RedirectToAction("List", "Worker");
        }

        [HttpPost]
        public ActionResult Edit(Worker _worker)
        {
            rep.Update(_worker);
            return RedirectToAction("List", "Worker");
        }
	}
}