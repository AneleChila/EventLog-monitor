using System;
using System.Web.Mvc;
using WebClient.Models;
using Zak.Controllers;
using Zak.EventLogReference;
using Zak.Models;

namespace Zak.Controllers
{
    public class HomeController : Controller
    {
        EventLogInterfaceClient  zakClient = new EventLogInterfaceClient();
        
        public ActionResult Index(string Name, DateTime? start, DateTime? end)
        {
            Event[] eventlst = new Event[2];
           
            var lst = zakClient.GetHistory(Name, start, end);                                                //DateTime.Now.AddHours(-1), DateTime.Now);
            int i = 0;
            foreach (var item in lst)
            {
                if (item != null)
                {
                    Array.Resize(ref eventlst, eventlst.Length + 1);
                    Zak.Models.Event myEvent = new Zak.Models.Event();

                    myEvent.Id = item.Id;
                    myEvent.Name = item.Name;
                    myEvent.DateTime = item.DateTime.ToString();
                    String eta = item.ETA.ToString();
                    myEvent.ETA = eta.Substring(eta.IndexOf(" "));
                    myEvent.Status = item.Status;
                    myEvent.EventType = item.EventType;
                    myEvent.isRemoteSession = Convert.ToString(item.isRemoteSession);
                    eventlst[i] = myEvent;
                    i++;
                }
            }
            return View(eventlst);


        }

        [HttpPost]
        public ActionResult FormOne(string name, DateTime? start, DateTime? end)
        {
            string Name = Request["name"].ToString(); //Convert.ToString(name)
            //string Start = Request["start"].ToString();
            //string End = Request["end"].ToString();
            while (start == null);
            DateTime yourStart = Convert.ToDateTime(start);
            DateTime yourEnd = Convert.ToDateTime(end);
            
            return Index(Name,yourStart ,yourEnd );
        }





        /*[HttpGet]
        public ActionResult Report(ReportViewModel model)
        {

            //check for model.Name property value now
            //to do : Return something
            Event[] eventlst = new Event[12];
            DateTime start = model.start;       //new DateTime(2018, 07, 10, 12, 20, 00);
            DateTime end = model.end;           // new DateTime(2018, 07, 10, 14, 40, 00);
            var lst = zakClient.GetHistory("Employee7", start, end);                                                //DateTime.Now.AddHours(-1), DateTime.Now);
            int i = 0;
            foreach (var item in lst)
            {
                Zak.Models.Event myEvent = new Zak.Models.Event();

                myEvent.Id = item.Id;
                myEvent.Name = item.Name;
                myEvent.DateTime = item.DateTime.ToString();
                String eta = item.ETA.ToString();
                myEvent.ETA = eta.Substring(eta.IndexOf(" "));
                myEvent.Status = item.Status;
                myEvent.EventType = item.EventType;
                myEvent.isRemoteSession = item.isRemoteSession;
                eventlst[i] = myEvent;
                i++;
            }
            return View(eventlst);
        }*/

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}