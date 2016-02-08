using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using SR.Conn;

namespace SR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MyNotifier notifier = new MyNotifier();
            notifier.Notify("<b>Someone accessed the front page!</b>");

            notifier.NotifyHub("<b>HUB: Someone accessed the front page!</b>");

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

        public ActionResult PersistentConnectionApi()
        {
            return View();
        }

        public ActionResult Groups()
        {
            return View();
        }

        public ActionResult HubBroadCast()
        {
            return View();
        }

        public ActionResult Hubs()
        {
            return View();
        }

        public ActionResult HubMethods()
        {
            return View();
        }

        public ActionResult HubGroups()
        {
            return View();
        }

        public ActionResult NoProxy()
        {
            return View();
        }
    }
}