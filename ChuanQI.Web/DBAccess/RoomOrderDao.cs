
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChuanQi.Web.Models;

namespace ChuanQi.Web.DBAccess
{
    public class RoomOrderDao:BaseDao
    {


        private static RoomOrderDao m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static RoomOrderDao Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new RoomOrderDao();
                return RoomOrderDao.m_Instance;
            }
        }
        /// <summary>
        /// 获取手术代码
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<RoomOrder> GetRoomOrders(RoomOrder RoomOrder)
        {
            var reValue = SqlMapper.QueryForList<RoomOrder>("GetRoomOrders", RoomOrder);
            logger.Debug("GetRoomOrders:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        /// <summary>
        /// 分页获取预约订房信息
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<RoomOrder> GetPageRoomOrders(int pageIndex,int pageSize,RoomOrder RoomOrder)
        {
            Hashtable hashTable = new Hashtable();
            int start = (pageIndex - 1) * pageSize;
            hashTable.Add("start", start);
            hashTable.Add("pageSize", pageSize);
            var reValue = SqlMapper.QueryForList<RoomOrder>("GetPageRoomOrders", hashTable);
            
            logger.Debug("GetPageRoomOrders:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        public int GetTotalCount(RoomOrder roomOrder) { 
            int totalCount=0;
            var reValue=SqlMapper.QueryForObject("GetTotalCount",roomOrder);
            totalCount =int.Parse(reValue.ToString());
            return totalCount;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkPatientModel"></param>
        /// <returns></returns>
        public bool InsertRoomOrder(RoomOrder roomOrder)
        {
            try
            {
               SqlMapper.Insert("InsertRoomOrder", roomOrder);
               return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
    }
}
