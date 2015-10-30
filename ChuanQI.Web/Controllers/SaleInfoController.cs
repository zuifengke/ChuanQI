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
    public class SaleInfoController : Controller
    {
        private Pagination m_pagination = null;
        //
        // GET: /SaleInfo/
        
        public ActionResult Index(String id)
        {
            if (this.m_pagination == null)
            {
                this.m_pagination = new Pagination();
            }
            SaleInfo SaleInfo = new SaleInfo();
            if (id != null)
                this.m_pagination.PageIndex = int.Parse(id);
            this.m_pagination.TotalCount = SaleInfoDao.Instance.GetTotalCount(SaleInfo);
            IList<SaleInfo> lstSaleInfos = SaleInfoDao.Instance.GetPageSaleInfos(this.m_pagination.PageIndex, this.m_pagination.PageSize, SaleInfo);
            ViewData["lstSaleInfos"] = lstSaleInfos;
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
            SaleInfo SaleInfo = new SaleInfo();
            SaleInfo.Place = form["Place"];
            SaleInfo.Name = form["Name"];
            SaleInfo.Tel = form["Tel"];
            float fPrice = 0;
            float.TryParse(form["Price"], out fPrice);
            SaleInfo.Price = fPrice;
            SaleInfo.Product = form["Product"];
            SaleInfo.SubTime = DateTime.Now;
            bool result = SaleInfoDao.Instance.InsertSaleInfo(SaleInfo);
            if (result)
                return Redirect("/SaleInfo/Index/1");
            else
                return Redirect("/SaleInfo/Index/1");
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
