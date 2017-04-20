using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityInfo
{
    /// <summary>
    /// 人员信息
    /// </summary>
    public class PersionInfo:Basic
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public PersonSex? Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }
        public bool? IsBegin { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double? Money { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal? SumMoney { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public byte[] Phote { get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public string Org_Key { get; set; }
    }
    public class Org : Basic
    {
        /// <summary>
        /// 班级名称
        /// </summary>
        public string Name { get; set; }
    }
    public enum PersonSex
    {
        Boy = 1,
        Girl =2,
    }
}
