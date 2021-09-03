using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSlogistic.Model
{
    //邮费
   public class FuelModel
    {
        public int fuelId { get; set; }
        public string   plate_number   { get; set; }
        public int  cost           { get; set; }
        public int  oil_mass       { get; set; }
        public int  km             { get; set; }
        public int  pay            { get; set; }
        public string   broker         { get; set; }
        public string   comment        { get; set; }
        public DateTime   creation_time  { get; set; }
    }
}
