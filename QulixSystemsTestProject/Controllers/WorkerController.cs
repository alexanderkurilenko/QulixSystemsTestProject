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
        //
        // GET: /Worker/
        WorkerRepository rep = new WorkerRepository();
        CompanyRepository _rep = new CompanyRepository();
        
        public ActionResult Add()
        {
            var query = _rep.List();
            ViewBag.Companies = query;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Worker _worker)
        {
            rep.Add(_worker);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult List()
        {
            var query = rep.List();
            return View(query);
        }
	}
}