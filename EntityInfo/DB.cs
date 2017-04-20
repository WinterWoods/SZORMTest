using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SZORM;

namespace EntityInfo
{
    public class DB : DbContext
    {
        public DB()
            : base(true)
        {
        }
        /// <summary>
        /// 人员信息
        /// </summary>
        public DbSet<PersionInfo> PersionInfo { get; set; }
        public DbSet<Org> Org { get; set; }

        protected override void UpdataDBExce()
        {
            if (DBVersion == 1)
            {
                SZORM_Upgrade up = new SZORM_Upgrade();
                up.UPTime = DateTime.Now;
                decimal upversion = DBUP.UPVersion2(this);
                up.UPContent = "测试更新";
                UPDBVersion(up);
            }
        }

        protected override void Initialization()
        {
            DB context = this;
            //添加模板记录
            context.Save();
        }
    }
}
