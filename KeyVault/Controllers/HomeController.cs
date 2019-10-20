using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Azure.KeyVault;
using System.Web.Configuration;
using System.Threading.Tasks;

namespace KeyVault.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
          
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(Utils.GetToken));
            var sec = await kv.GetSecretAsync(WebConfigurationManager.AppSettings["SecretUri"]);
            var val = await kv.GetKeyAsync(WebConfigurationManager.AppSettings["MyFirstKey"]);
            return View();
        }

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