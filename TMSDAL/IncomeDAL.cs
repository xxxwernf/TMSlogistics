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
    //--线路
   public class IncomeDAL:PathIDAL
    {
        //连接数据库
        IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=logistics;Integrated Security=True");

        public List<PathModel> Show()
        {
            string sql = $"select *from path";
            return conn.Query<PathModel>(sql).ToList();
        }
        public int Add(PathModel s)
        {
            string sql = $"insert into path values('{s.path_Name}','{s.origin}','{s.origin_intro}','{s.terminus}','{s.terminus_intro}','{s.isoutsource}','{s.Name}','{s.comment}','{s.creation_time}','{s.state}','{s.phone}','{s.unit}')";
            return conn.Execute(sql, s);
        }

        public int Del(int pathId)
        {
            string sql = $"delete from path where pathId in ({pathId})";
            return conn.Execute(sql, pathId);
        }

        public PathModel Fantian(int pathId)
        {
            string sql = $"select *from path where pathId in ({pathId})";
            return conn.Query<PathModel>(sql).FirstOrDefault();
        }

      

        public int Update(PathModel s)
        {
            string sql = $"Update path set path_Name='{s.path_Name}',origin='{s.origin}',origin_intro='{s.origin_intro}',terminus='{s.terminus}',terminus_intro='{s.terminus_intro}',isoutsource='{s.isoutsource}',Name='{s.Name}',comment='{s.comment}',creation_time='{s.creation_time}', state='{s.state}',phone='{s.phone}',unit='{s.unit}' where pathId in ({s.pathId})";
            return conn.Execute(sql);
        }
        //显示
    }
}
