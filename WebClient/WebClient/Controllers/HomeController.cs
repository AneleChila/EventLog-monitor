using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.EventLogR;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        EventLogInterfaceClient webClient = new EventLogInterfaceClient();

        public ActionResult Index()
        {
            Models.Status[] statusLst = new Models.Status[11];

            var lst = webClient.GetStatus();
            int i = 0;
            foreach (var item in lst)
            {
                if (item != null) {
                WebClient.Models.Status status = new WebClient.Models.Status();

                // status.Id = item.Id.ToString();
                status.Name = item.Name.ToString();
                String eta = item.ETA.ToString();
                status.ETA = eta.Substring(eta.IndexOf(" "));
                    //status.StatusFlag = item.StatusFlag;
                status.StatusFlag = Convert.ToString(item.StatusFlag);
                statusLst[i] = status;                       // might be assigning a null value               //my mistake --> statusLst[i-1] = item
                i++;
                }
            }
            
            return View(statusLst);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Server.MapPath(Path.Combine(Server.MapPath("~/Content/"), fileName));
                file.SaveAs(path);
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}