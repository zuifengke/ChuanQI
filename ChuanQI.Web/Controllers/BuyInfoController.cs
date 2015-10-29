using ChuanQi.Web.DBAccess;
using ChuanQi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuanQI.Web.Controllers
{
    public class BuyInfoController : Controller
    {
        //
        // GET: /BuyInfo/

        public ActionResult Index()
        {
            BuyInfo BuyInfo=new BuyInfo();
            IList<BuyInfo> lstBuyInfos = BuyInfoDao.Instance.GetBuyInfos(BuyInfo);
            return View();
        }

    }
}
