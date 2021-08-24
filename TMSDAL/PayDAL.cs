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
    public class PayDAL : PayIDAL
    {
        //连接数据库
        IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=logistics;Integrated Security=True");

        public List<PayModel> Show()
        {
            string sql = $"select *from Pay";
            return conn.Query<PayModel>(sql).ToList();

        }
        public int Add(PayModel s)
        {
            string sql = $"insert into Pay values('{s.PayTitle}','{s.PayPrice}','{s.PayWay}','{s.PayObject}','{s.PayAccount}','{s.PayBank}','{s.PayTime}','{s.PayAbove}','{s.PayRemark}','{s.PayBill}')";
            return conn.Execute(sql, s);
        }

        public int Del(int Payid)
        {
            string sql = $"delete from Pay where Payid in ({Payid})";
            return conn.Execute(sql, Payid);
        }

        public PayModel Fantian(int Payid)
        {
            string sql = $"select *from Pay where Payid in ({Payid})";
            return conn.Query<PayModel>(sql).FirstOrDefault();
        }

      

        public int Update(PayModel s)
        {
            string sql = $"Update Pay set PayTitle='{s.PayTitle}',PayPrice='{s.PayPrice}',PayWay='{s.PayWay}',PayObject='{s.PayObject}',PayAccount='{s.PayAccount}',PayBank='{s.PayBank}',PayTime='{s.PayTime}',PayAbove='{s.PayAbove}',PayRemark='{s.PayRemark}', PayBill='{s.PayBill}' where Payid in ({s.Payid})";
            return conn.Execute(sql);
        }
    }
}
