using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSlogistic.Model
{
    //货主
   public class shippercontractModel
    {
        public string id { get; set; }
        public string  contracId      { get; set; }
        public string  name           { get; set; }
        public string  unit           { get; set; }
        public string  principal      { get; set; }
        public string  path           { get; set; }
        public string  fare           { get; set; }
        public string  full_fare      { get; set; }
        public string  full_money     { get; set; }
        public string  agent          { get; set; }
        public DateTime  signed_time    { get; set; }
        public string  contract_money { get; set; }
        public string  contract_intro { get; set; }
        public string  clause         { get; set; }
        public string  contract_text  { get; set; }
        public DateTime  creation_time  { get; set; }
        public string  state          { get; set; }
        public string  approver       { get; set; }
    
    }
}
