using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSlogistic.Model
{
    //合同管理
   public class ManagementModel
    {
        public int managementid { get; set; }
        public string managementSerial	{ get; set; }
        public string managementTitle		{ get; set; }
        public string managementSum		{ get; set; }
        public int managementCondition	{ get; set; }
        public int managementPrice		{ get; set; }
        public string managementResonsible{ get; set; }
        public DateTime  managementTime		{ get; set; }
        public int managementMoney		{ get; set; }
        public string managementExplain	{ get; set; }
        public string managementAlteration{ get; set; }
        public string managementText		{ get; set; }

    }
}
