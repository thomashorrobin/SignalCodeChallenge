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

        //[HttpPost]
        //public ActionResult Index(string text)
        //{
        //    return Results(new Text(text));
        //}

        [HttpPost]
        public ActionResult Results(string text)
        {
            return View(new Models.TextResult(new Text(text)));
        }

        [HttpPost]
        public ActionResult FromFile(HttpPostedFileBase file)
        {
            string text = "The default sentence";
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                //// extract only the fielname
                //var fileName = Path.GetFileName(file.FileName);
                //// store the file inside ~/App_Data/uploads folder
                //var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                //file.SaveAs(path);
                using (System.IO.StreamReader reader = new System.IO.StreamReader(file.InputStream))
                {
                    text = reader.ReadToEnd();
                }
            }
            // redirect back to the index action to show the form once again
            return View("Results", new Models.TextResult(new Text(text)));
        }
    }
}