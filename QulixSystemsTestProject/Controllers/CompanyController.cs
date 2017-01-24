using QulixSystemsTestProject.Models.Repositories;
using QulixSystemsTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QulixSystemsTestProject.Controllers
{
    public class CompanyController : Controller
    {
        IRepository<Company> rep;

        public CompanyController()
        {
            rep=new CompanyRepository();
        }
           
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Company _company)
        {
            if (ModelState.IsValid)
            {
                rep.Add(_company);
                return RedirectToAction("List", "Company");
            }
            return View(_company);
           
        }

        public ActionResult List()
        {
            var query=rep.List();
            return View(query);
        }

        public ActionResult Delete(int id)
        {
            rep.Delete(id);
            return RedirectToAction("List", "Company");
        }

        public ActionResult Edit(int id)
        {
            return View("Add", rep.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Company _company)
        {
            rep.Update(_company);
            return RedirectToAction("List", "Company");
        }
	}

}