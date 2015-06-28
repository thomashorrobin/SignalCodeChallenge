using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SentenceSpliter;

namespace SignalCodeChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Results(string text)
        {
            return View(new Models.TextResult(new Text(text))); // this simply initilises and sends a TextResult to the view
        }

        [HttpPost]
        public ActionResult FromFile(HttpPostedFileBase file)
        {
            string text = "The default sentence"; // this is need to aviod problems, obviously if this was a real project I'd do this properly

            if (file != null && file.ContentLength > 0) // Verify that the user selected a file
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(file.InputStream))
                {
                    text = reader.ReadToEnd(); // this should push the eniter file to the 'text' varible
                    // no need to close the reader as it gets disposed in the using statement anyway
                }
            }
            // redirect back to the index action to show the form once again
            return View("Results", new Models.TextResult(new Text(text)));
        }
    }
}