using ChuanQi.Web.DBAccess;
using ChuanQi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Windy.Common.Libraries;

namespace ChuanQI.Web.Areas.Admin.Controllers
{
    public class BuyAndSaleController : Controller
    {
        //
        // GET: /Admin/BuyAndSale/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        public ActionResult QueryBuyData()
        {
            int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            if (page < 1) return Content("");

            IList<BuyInfo> lstBuyInfos = BuyInfoDao.Instance.GetPageBuyInfos(page, size, null);
            JsonHelper json = new JsonHelper();
            string strJson = string.Empty;
            foreach (var item in lstBuyInfos)
            {
                json.AddItem("ID", item.ID.ToString());
                json.AddItem("Name", item.Name == null ? "" : item.Name);
                json.AddItem("Place", item.Place == null ? "" : item.Place);
                json.AddItem("Price", item.Price.ToString());
                json.AddItem("Product", item.Product.ToString());
                json.AddItem("SubTime", item.SubTime.ToString());
                json.AddItem("Tel", item.Tel == null ? "" : item.Tel.ToString());
                json.ItemOk();
            }
            int totalCount = BuyInfoDao.Instance.GetTotalCount(null);
            json.totlalCount = totalCount;
            if (json.totlalCount > 0)
            {
                strJson = json.ToEasyuiGridJsonString();
            }
            else
            {
                strJson = @"[]";
            }
            // json = "{ \"rows\":[ { \"ID\":\"48\",\"NewsTitle\":\"mr\",\"NewsContent\":\"mrsoft\",\"CreateTime\":\"2013-12-23\",\"CreateUser\":\"ceshi\",\"ModifyTime\":\"2013-12-23\",\"ModifyUser\":\"ceshi\"} ],\"total\":3}";
            return Content(strJson);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        public ActionResult QuerySaleData()
        {
            int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            if (page < 1) return Content("");

            IList<SaleInfo> lstSaleInfos = SaleInfoDao.Instance.GetPageSaleInfos(page, size, null);
            JsonHelper json = new JsonHelper();
            string strJson = string.Empty;
            foreach (var item in lstSaleInfos)
            {
                json.AddItem("ID", item.ID.ToString());
                json.AddItem("Name", item.Name == null ? "" : item.Name);
                json.AddItem("Place", item.Place == null ? "" : item.Place);
                json.AddItem("Price", item.Price.ToString());
                json.AddItem("Product", item.Product.ToString());
                json.AddItem("SubTime", item.SubTime.ToString());
                json.AddItem("Tel", item.Tel == null ? "" : item.Tel.ToString());
                json.ItemOk();
            }
            int totalCount = SaleInfoDao.Instance.GetTotalCount(null);
            json.totlalCount = totalCount;
            if (json.totlalCount > 0)
            {
                strJson = json.ToEasyuiGridJsonString();
            }
            else
            {
                strJson = @"[]";
            }
            // json = "{ \"rows\":[ { \"ID\":\"48\",\"NewsTitle\":\"mr\",\"NewsContent\":\"mrsoft\",\"CreateTime\":\"2013-12-23\",\"CreateUser\":\"ceshi\",\"ModifyTime\":\"2013-12-23\",\"ModifyUser\":\"ceshi\"} ],\"total\":3}";
            return Content(strJson);
        }
        public ActionResult DelSaleData()
        {
            string writeMsg = "删除失败！";

            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {
                bool result = SaleInfoDao.Instance.DeleteSaleInfos(selectID);

                if (result)
                {
                    writeMsg = string.Format("删除成功");
                }
                else
                {
                    writeMsg = "删除失败！";
                }
            }

            return Content(writeMsg);
        }
        
        public ActionResult DelBuyData()
        {
            string writeMsg = "删除失败！";

            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";
            if (selectID != string.Empty && selectID != "0")
            {
                bool result = BuyInfoDao.Instance.DeleteBuyInfos(selectID);

                if (result)
                {
                    writeMsg = string.Format("删除成功");
                }
                else
                {
                    writeMsg = "删除失败！";
                }
            }

            return Content(writeMsg);
        }
    }
}
