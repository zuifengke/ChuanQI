
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChuanQi.Web.Models;

namespace ChuanQi.Web.DBAccess
{
    public class BuyInfoDao:BaseDao
    {


        private static BuyInfoDao m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static BuyInfoDao Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new BuyInfoDao();
                return BuyInfoDao.m_Instance;
            }
        }
        /// <summary>
        /// 获取手术代码
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<BuyInfo> GetBuyInfos(BuyInfo BuyInfo)
        {
            var reValue = SqlMapper.QueryForList<BuyInfo>("GetBuyInfos", BuyInfo);
            logger.Debug("GetBuyInfos:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        /// <summary>
        /// 分页获取预约订房信息
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<BuyInfo> GetPageBuyInfos(int pageIndex,int pageSize,BuyInfo BuyInfo)
        {
            Hashtable hashTable = new Hashtable();
            int start = (pageIndex - 1) * pageSize;
            hashTable.Add("start", start);
            hashTable.Add("pageSize", pageSize);
            hashTable.Add("buyinfo", BuyInfo);
            string sql = IBatisHelper.GetRuntimeSql(this.SqlMapper, "GetPageBuyInfos", hashTable);
            var reValue = SqlMapper.QueryForList<BuyInfo>("GetPageBuyInfos", hashTable);
            
            logger.Debug("GetPageBuyInfos:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        public int GetTotalCount(BuyInfo BuyInfo) { 
            int totalCount=0;
            Hashtable hashTable = new Hashtable();
            hashTable.Add("buyinfo", BuyInfo);
            string sql = IBatisHelper.GetRuntimeSql(this.SqlMapper, "GetBuyInfoTotalCount", hashTable);
            var reValue=SqlMapper.QueryForObject("GetBuyInfoTotalCount", hashTable);
            totalCount =int.Parse(reValue.ToString());
            return totalCount;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkPatientModel"></param>
        /// <returns></returns>
        public bool InsertBuyInfo(BuyInfo BuyInfo)
        {
            try
            {
               SqlMapper.Insert("InsertBuyInfo", BuyInfo);
               return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="checkPatientModel"></param>
        /// <returns></returns>
        public bool DeleteBuyInfos(string ids)
        {
            try
            {
                string sql = IBatisHelper.GetRuntimeSql(this.SqlMapper, "DeleteBuyInfos", ids);
                SqlMapper.Delete("DeleteBuyInfos", ids);
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
