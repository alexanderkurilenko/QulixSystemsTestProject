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
        WorkerRepository rep;
        public WorkerController(WorkerRepository _rep)
        {
            rep = _rep;
        }
        
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
	}
}