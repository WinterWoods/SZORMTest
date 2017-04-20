using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SZORM;

namespace EntityInfo
{
    public class Basic
    {
        [SZColumn(IsKey = true,MaxLength=100)]
        public string Key { get; set; }
        private DateTime? addTime = null;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? AddTime
        {
            get { return addTime; }
            set { addTime = value; }
        }
        private DateTime? editTime = null;
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? EditTime
        {
            get { return editTime; }
            set { editTime = value; }
        }
    }
}
