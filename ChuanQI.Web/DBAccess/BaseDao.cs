using IBatisNet.Common.Logging;
using IBatisNet.DataMapper;
using System.Reflection;

namespace ChuanQi.Web.DBAccess
{
    public class BaseDao
    {
        protected readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private ISqlMapper _sqlMapper;

        public ISqlMapper SqlMapper
        {
            get { return _sqlMapper ?? (_sqlMapper = Mapper.Instance()); }
            set { _sqlMapper = value; }
        }


        private ISqlMapper _nurDocSqlMapper;

        /// <summary>
        /// 第二个数据源的sqlmapper
        /// 跟SqlMapper使用方式相同
        /// 如：NurDocSqlMapper.QueryForList<Model>("GetAllAntibioticDrugCodes", criteria);
        /// </summary>
        public ISqlMapper NurDocSqlMapper
        {
            get { return _nurDocSqlMapper ?? (_nurDocSqlMapper = NurDocMapper.Instance()); }
            set { _nurDocSqlMapper = value; }
        }
    }
}
