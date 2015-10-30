
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChuanQi.Web.Models;

namespace ChuanQi.Web.DBAccess
{
    public class SaleInfoDao:BaseDao
    {


        private static SaleInfoDao m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static SaleInfoDao Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new SaleInfoDao();
                return SaleInfoDao.m_Instance;
            }
        }
        /// <summary>
        /// 获取手术代码
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<SaleInfo> GetSaleInfos(SaleInfo SaleInfo)
        {
            var reValue = SqlMapper.QueryForList<SaleInfo>("GetSaleInfos", SaleInfo);
            logger.Debug("GetSaleInfos:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        /// <summary>
        /// 分页获取预约订房信息
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<SaleInfo> GetPageSaleInfos(int pageIndex,int pageSize,SaleInfo SaleInfo)
        {
            Hashtable hashTable = new Hashtable();
            int start = (pageIndex - 1) * pageSize;
            hashTable.Add("start", start);
            hashTable.Add("pageSize", pageSize);
            var reValue = SqlMapper.QueryForList<SaleInfo>("GetPageSaleInfos", hashTable);
            
            logger.Debug("GetPageSaleInfos:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        public int GetTotalCount(SaleInfo SaleInfo) { 
            int totalCount=0;
            var reValue=SqlMapper.QueryForObject("GetSaleInfoTotalCount",SaleInfo);
            totalCount =int.Parse(reValue.ToString());
            return totalCount;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkPatientModel"></param>
        /// <returns></returns>
        public bool InsertSaleInfo(SaleInfo SaleInfo)
        {
            try
            {
               SqlMapper.Insert("InsertSaleInfo", SaleInfo);
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
