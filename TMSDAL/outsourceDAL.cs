using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
using TMS.IDAL;
using Dapper;
using System.Data;
using System.Data.SqlClient;
namespace TMS.DAL
{
    //--外协
   public class OutsourceDAL: OutsourceIDAL
    {
        //连接数据库
        IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=logistics;Integrated Security=True");

        public List<OutsourceModel> Show()
        {
            string sql = $"select *from outsource";
            return conn.Query<OutsourceModel>(sql).ToList();
        }
        public int Add(OutsourceModel s)
        {
            string sql = $"insert into outsource values('{s.unit_Name}','{s.email}','{s.fixed_line}','{s.phone}','{s.site}','{s.creation_time}')";
            return conn.Execute(sql, s);
        }

        public int Del(int outsourceId)
        {
            string sql = $"delete from outsource where outsourceId in ({outsourceId})";
            return conn.Execute(sql, outsourceId);
        }

        public OutsourceModel Fantian(int outsourceId)
        {
            string sql = $"select *from outsource where outsourceId in ({outsourceId})";
            return conn.Query<OutsourceModel>(sql).FirstOrDefault();
        }

       

        public int Update(OutsourceModel s)
        {
            string sql = $"Update outsource set unit_Name='{s.unit_Name}',email='{s.email}',fixed_line='{s.fixed_line}',phone='{s.phone}',site='{s.site}',creation_time='{s.creation_time}'where outsourceId in ({s.outsourceId})";
            return conn.Execute(sql);
        }
        //显示
    }
}
