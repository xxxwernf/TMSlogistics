using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IDAL;
using TMSlogistic.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace TMS.DAL
{
    public class UserDAL : UserIDAL
    {
        //连接数据库
        IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=logistics;Integrated Security=True");
      
        public List<UsersModel> Show()
        {
            string sql = $"select *from Users";
            return conn.Query<UsersModel>(sql).ToList();
        }
        public int Add(UsersModel s)
        {
            string sql = $"insert into Users values('{s.UsersName}',{(s.UsersSex?1:0)},'{s.UsersPhone}','{s.UsersSchool}','{s.UsersMajor}','{s.UsersHome}','{s.UsersEducation}','{s.UsersFace}','{s.UserEthnic}','{s.UserNative}','{s.UsersMarriage}','{s.UsersDate}','{s.UsersEmail}','{s.UserIdentity}','{s.Departmentid}','{s.Positionid}','{s.Categoryid}','{s.superior}','{s.Userscreate}','{s.Usersstart}')";
            return conn.Execute(sql, s);
        }

        public int Del(int Usersid)
        {
            string sql = $"delete from Users where Usersid in ({Usersid})";
            return conn.Execute(sql, Usersid);
        }

      

        public UsersModel Fantian(int Usersid)
        {
            string sql = $"select *from Users where Usersid in ({Usersid})";
            return conn.Query<UsersModel>(sql).FirstOrDefault();
        }
        public int Update(UsersModel s)
        {
            string sql = $"Update Users set UsersName='{s.UsersName}',UsersSex='{(s.UsersSex ? 1 : 0)}',UsersPhone='{s.UsersPhone}',UsersSchool='{s.UsersSchool}',UsersMajor='{s.UsersMajor}',UsersHome='{s.UsersHome}',UsersEducation='{s.UsersEducation}',UsersFace='{s.UsersFace}',UserEthnic='{s.UserEthnic}', UserNative='{s.UserNative}',UsersMarriage='{s.UsersMarriage}',UsersDate='{s.UsersDate}',UsersEmail='{s.UsersEmail}',UserIdentity='{s.UserIdentity}',Departmentid='{s.Departmentid}',Positionid='{s.Positionid}',Categoryid='{s.Categoryid}',superior='{s.superior}',Userscreate='{s.Userscreate}',Usersstart='{s.Usersstart}' where Usersid in ({s.Usersid})";
            return conn.Execute(sql);
        }
      
    }
}
