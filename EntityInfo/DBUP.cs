using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityInfo
{
    public class DBUP
    {
        public static decimal UPVersion2(DB context)
        {
            return 2;
        }
        public static decimal UPVersion3(DB context)
        {
            return 3;
        }
    }
}
