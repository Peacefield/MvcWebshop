using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebshop.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error/NotFound
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }

        // GET: Error/InternalServer
        public ActionResult InternalServer()
        {
            Response.StatusCode = 500;
            return View("InternalServer");
        }
    }
}