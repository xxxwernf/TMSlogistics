using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSlogistic.Model
{
    //车辆
   public class VehicleAdministrationModell
    {
        public int VehicleAdministrationid { get; set; }
        public string VehicleAdministrationModel { get; set; }
        public string VehicleAdministrationLicense	 { get; set; }
        public string VehicleAdministrationName		 { get; set; }
        public string VehicleAdministrationCompany	 { get; set; }
        public string VehicleAdministrationType		 { get; set; }
        public string VehicleAdministrationColor		 { get; set; }
        public DateTime VehicleAdministrationDate		 { get; set; }
        public string VehicleAdministrationRun		 { get; set; }
        public DateTime VehicleAdministrationEndtime	 { get; set; }
        public DateTime  VehicleAdministrationYearDate	 { get; set; }
        public string VehicleAdministrationMaintain	 { get; set; }
    }
}
