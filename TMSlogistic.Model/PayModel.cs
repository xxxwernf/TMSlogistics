using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSlogistic.Model
{
   public class PayModel
    {
        //付款管理
    
        public int Payid { get; set; }
        public string  PayTitle	 { get; set; }
        public string PayPrice	 { get; set; }
        public string  PayWay		 { get; set; }
        public string  PayObject	 { get; set; }
        public string  PayAccount	 { get; set; }
        public string  PayBank	 { get; set; }
        public string  PayTime	 { get; set; }
        public string  PayAbove	 { get; set; }
        public string  PayRemark	 { get; set; }
        public string PayBill { get; set; }
    }         
        

}
