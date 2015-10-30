using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChuanQI.Web.Models
{
    public class Pagination
    {
        //当前页码
        private int _PageIndex = 1;
        public int PageIndex
        {
            get
            {
                return this._PageIndex;
            }
            set
            {
                this._PageIndex = value;
            }
        }
        private int _TotalCount;
        public int TotalCount
        {
            get
            {
                return this._TotalCount;
            }
            set
            {
                this._PageCount = (value + this._PageSize - 1) / this._PageSize;
                this._TotalCount = value;
            }
        }

        private int _PageCount = 0;
        public int PageCount
        {
            get
            {
                if (this._PageSize == 0)
                    return 0;
                return (this._TotalCount + this._PageSize - 1) / this._PageSize;
            }

        }
        private int _NexPageIndex;
        /// <summary>
        /// 下一页
        /// </summary>
        public int NextPageIndex
        {
            get
            {
                return this._NexPageIndex;
            }
            set
            {
                this._NexPageIndex = value;
            }
        }
        private int _PrePageIndex;
        /// <summary>
        /// 上一页
        /// </summary>
        public int PrePageIndex
        {
            get
            {
                return this._PrePageIndex;
            }
            set
            {
                this._PrePageIndex = value;
            }
        }
        //每页记录数
        private int _PageSize = 10;
        public int PageSize
        {
            get
            {
                return this._PageSize;
            }
            set
            {
                this._PageSize = value;
            }
        }

        //数据库查询记录偏移值
        private int _Offset = 0;
        public int Offset
        {
            get
            {
                return this._PageSize * (this._PageIndex - 1);
            }
            set
            {
                this._Offset = value;
            }
        }

        //是否有下一页
        public bool HasNext()
        {
            this._PageCount = (this._TotalCount + this._PageSize - 1) / this._PageSize;
            return _PageIndex < _PageCount;
        }
        //是否有上一页
        public bool HasPre()
        {
            return _PageIndex > 1;
        }
        //页吗显示起始页
        private int _BeginPage;

        public int BeginPage
        {
            get
            {
                if (this._PageIndex - 5 > 1)
                {
                    this._BeginPage = this._PageIndex - 5;
                }
                else
                    this._BeginPage = 1;
                return _BeginPage;
            }

        }
        //页码显示结束页
        private int _EndPage;

        public int EndPage
        {
            get
            {
                if (this._PageCount > this._PageIndex + 5)
                {
                    this._EndPage = this._PageIndex + 5;

                }
                else
                {
                    this._EndPage = this._PageCount;

                }
                return _EndPage;
            }
            set
            {
                this._EndPage = value;
            }
        }

    }
}