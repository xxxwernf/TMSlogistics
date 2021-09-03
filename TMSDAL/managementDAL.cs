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
    public class ManagementDAL : ManagementIDAL
    {
        //连接数据库
        IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=logistics;Integrated Security=True");
        //显示
        public List<ManagementModel> Show()
        {
            string sql = $"select *from management";
            return conn.Query<ManagementModel>(sql).ToList();
        }
        public int Add(ManagementModel s)
        {
            string sql = $"insert into management values('{s.managementSerial}','{s.managementTitle}','{s.managementSum}','{s.managementCondition}','{s.managementPrice}','{s.managementResonsible}','{s.managementTime}','{s.managementMoney}','{s.managementExplain}','{s.managementAlteration}','{s.managementText}')";
            return conn.Execute(sql, s);
        }

        public int Del(int managementid)
        {
            string sql = $"delete from management where managementid in ({managementid})";
            return conn.Execute(sql, managementid);
        }

        public ManagementModel Fantian(int managementid)
        {
            string sql = $"select *from management where managementid in ({managementid})";
            return conn.Query<ManagementModel>(sql).FirstOrDefault();
        }

     

        public int Update(ManagementModel s)
        {
            string sql = $"Update management set managementSerial='{s.managementSerial}',managementTitle='{s.managementTitle}',managementSum='{s.managementSum}',managementCondition='{s.managementCondition}',managementPrice='{s.managementPrice}',managementResonsible='{s.managementResonsible}',managementTime='{s.managementTime}',managementMoney='{s.managementMoney}',managementExplain='{s.managementExplain}', managementAlteration='{s.managementAlteration}',managementText='{s.managementText}' where managementid in ({s.managementid})";
            return conn.Execute(sql);
        }
    }
}
