using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;


namespace APPService01.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger("SleepyCore");
        public ActionResult Index()
        {
            Trace.TraceError("Something is definitely wrong here.");
            Trace.TraceWarning("Something could be wrong here.");
            Trace.TraceInformation("Entered {0}.", this.GetType().Name);
            return View();
        }

        public ActionResult About()
        {
            try
            {
                log.Info("Begin - Page_Load() at " + DateTime.Now.ToString("hh.mm.ss.ffffff"));
                log.Info("------------------------------------------------------------------");
                log.Info("Begin - request.GetResponse() at " + DateTime.Now.ToString("hh.mm.ss.ffffff"));
                // System.Net.WebResponse response = request.GetResponse();
                log.Info("End - request.GetResponse() at " + DateTime.Now.ToString("hh.mm.ss.ffffff"));

                log.Info("------------------------------------------------------------------");
                log.Info("End - Page_Load() at " + DateTime.Now.ToString("hh.mm.ss.ffffff"));
            }
            catch (Exception)
            {

                // labelAPI.Text = ex.Message;
                log.Debug("++++++++++++++++++++++++++++");
                log.Error("Exception - \n" + "test");
                log.Debug("++++++++++++++++++++++++++++");
            }

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