using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
using Dapper;
using TMS.IDAL;
using System.Data;
using System.Data.SqlClient;
namespace TMS.DAL
{
    //--入职
   public class ApproverDAL:EntryIDAL
    {
        //连接数据库
        IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=logistics;Integrated Security=True");

        public List<EntryModel> Show()
        {
            string sql = $"select *from entry";
            return conn.Query<EntryModel>(sql).ToList();
        }

        public int Add(EntryModel s)
        {
            string sql = $"insert into entry values('{s.name}','{s.sex}','{s.department}','{s.post}','{s.superior}','{s.entry_time}','{s.establish_time}','{s.state}','{s.audit}','{s.comment}')";
            return conn.Execute(sql, s);
        }

        public int Del(int id)
        {
            string sql = $"delete from entry where id in ({id})";
            return conn.Execute(sql, id); 
        }

        public EntryModel Fantian(int id)
        {
            string sql = $"select *from entry where id in ({id})";
            return conn.Query<EntryModel>(sql).FirstOrDefault();
        }

      
        public int Update(EntryModel s)
        {
            string sql = $"Update entry set name='{s.name}',sex='{s.sex}',department='{s.department}',post='{s.post}',superior='{s.superior}',entry_time='{s.entry_time}',establish_time='{s.establish_time}',state='{s.state}',audit='{s.audit}', comment='{s.comment}' where id in ({s.id})";
            return conn.Execute(sql);
        }
        //显示
    }
}
