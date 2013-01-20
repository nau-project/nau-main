using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBaseLibrary;

namespace NauMain.Controllers
{
    public class InitController : Controller
    {
        //
        // GET: /Init/

        public ActionResult Index()
        {
            DataContext context = new DataContext();
            
            IDalInitializer initializer = new DalInitializer();
            initializer.Initialize();
            return Content("Success");
        }

    }
}
