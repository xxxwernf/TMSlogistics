using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSlogistic.Model
{
    //入职
    public class CarriagecontraModel
    {
        public int id { get; set; }
        public string  name            { get; set; }
        public string  sex             { get; set; }
        public int  department      { get; set; }
        public int  post            { get; set; }
        public string  superior        { get; set; }
        public DateTime   entry_time      { get; set; }
        public DateTime   establish_time  { get; set; }
        public string  state           { get; set; }
        public string  audit           { get; set; }
        public string  comment         { get; set; }
    }
}
