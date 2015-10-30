using ChuanQi.Web.DBAccess;
using ChuanQi.Web.Models;
using ChuanQI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuanQI.Web.Controllers
{
    public class BuyInfoController : Controller
    {
        private Pagination m_pagination = null;
        //
        // GET: /BuyInfo/

        public ActionResult Index(String id)
        {
            if (this.m_pagination == null)
            {
                this.m_pagination = new Pagination();
            }
            BuyInfo buyInfo = new BuyInfo();
            if (id != null)
                this.m_pagination.PageIndex = int.Parse(id);
            this.m_pagination.TotalCount = BuyInfoDao.Instance.GetTotalCount(buyInfo);
            IList<BuyInfo> lstBuyInfos = BuyInfoDao.Instance.GetPageBuyInfos(this.m_pagination.PageIndex, this.m_pagination.PageSize, buyInfo);
            ViewData["lstBuyInfos"] = lstBuyInfos;
            ViewData["pagination"] = this.m_pagination;
            return View();
        }
        public ActionResult Submit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Submit(FormCollection form)
        {
            BuyInfo buyInfo = new BuyInfo();
            buyInfo.Place = form["Place"];
            buyInfo.Name = form["Name"];
            buyInfo.Tel = form["Tel"];
            float fPrice = 0;
            float.TryParse(form["Price"], out fPrice);
            buyInfo.Price = fPrice;
            buyInfo.Product = form["Product"];
            buyInfo.SubTime = DateTime.Now;
            bool result = BuyInfoDao.Instance.InsertBuyInfo(buyInfo);
            if (result)
                return Redirect("/BuyInfo/Index/1");
            else
                return Redirect("/BuyInfo/Index/1");
        }
        [HttpPost]
        public ActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Error()
        {
            return View();
        }

    }
}
