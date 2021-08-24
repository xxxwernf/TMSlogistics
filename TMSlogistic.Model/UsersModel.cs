using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSlogistic.Model
{
    //用户
   public class UsersModel
    {
        public int Usersid { get; set; }
        public string  UsersName		 { get; set; }
        public bool UsersSex		 { get; set; }
        public string  UsersPhone		 { get; set; }
        public string  UsersSchool		 { get; set; }
        public string  UsersMajor		 { get; set; }
        public string  UsersHome		 { get; set; }
        public string  UsersEducation	 { get; set; }
        public string  UsersFace		 { get; set; }
        public string UserEthnic		 { get; set; }
        public string UserNative		 { get; set; }
        public string UsersMarriage	 { get; set; }
        public DateTime UsersDate		 { get; set; }
        public string UsersEmail		 { get; set; }
        public string UserIdentity	 { get; set; }
        public int Departmentid	 { get; set; }
        public int Positionid		 { get; set; }
        public int Categoryid		 { get; set; }
        public string  superior		 { get; set; }
        public DateTime  Userscreate		 { get; set; }
        public DateTime  Usersstart		 { get; set; }
       
    }
}
