using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace graph.Controllers
{
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult Index()
        {
            ViewBag.Message = "Your Graph page.";

            return View();
        }
    }
}