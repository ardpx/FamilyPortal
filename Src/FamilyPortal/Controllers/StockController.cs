using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyPortal.Controllers
{
    public class StockController : Controller
    {
        //
        // GET: /Stock/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddTrade()
        {
            return View();
        }

        public ActionResult _AddTrade()
        {
            return PartialView("_AddTrade");
        }

        [ActionName("TradeDay")]
        public ActionResult ShowTradeDay()
        {
            return View("ShowTradeDay");
        }

		[ActionName("TradePair")]
		public ActionResult ShowTradePair()
		{
			return View("ShowTradePair");
		}

    }
}
