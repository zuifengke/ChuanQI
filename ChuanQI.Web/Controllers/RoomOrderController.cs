using ChuanQi.Web.DBAccess;
using ChuanQi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuanQI.Web.Controllers
{
    public class RoomOrderController : Controller
    {
        //
        // GET: /RoomOrder/

        public ActionResult Index()
        {
            RoomOrder roomorder=new RoomOrder();
            IList<RoomOrder> lstRoomOrders = RoomOrderDao.Instance.GetRoomOrders(roomorder);

            return View();
        }

    }
}
