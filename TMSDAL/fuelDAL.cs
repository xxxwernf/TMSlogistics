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
    //--邮费
   public class FuelDAL : FuelIDAL
    {
        //连接数据库
        IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=logistics;Integrated Security=True");

        public List<FuelModel> Show()
        {
            string sql = $"select *from fuel";
            return conn.Query<FuelModel>(sql).ToList();
        }
        public int Add(FuelModel s)
        {
            string sql = $"insert into fuel values('{s.plate_number}','{s.cost}','{s.oil_mass}','{s.km}','{s.pay}','{s.broker}','{s.comment}','{s.creation_time}')";
            return conn.Execute(sql, s);
        }

        public int Del(int fuelId)
        {
            string sql = $"delete from fuel where fuelId in ({fuelId})";
            return conn.Execute(sql, fuelId);
        }

        public FuelModel Fantian(int fuelId)
        {
            string sql = $"select *from fuel where fuelId in ({fuelId})";
            return conn.Query<FuelModel>(sql).FirstOrDefault();
        }

       

        public int Update(FuelModel s)
        {
            string sql = $"Update fuel set plate_number='{s.plate_number}',cost='{s.cost}',oil_mass='{s.oil_mass}',km='{s.km}',pay='{s.pay}',broker='{s.broker}',comment='{s.comment}',creation_time='{s.creation_time}'where fuelId in ({s.fuelId})";
            return conn.Execute(sql);
        }
        //显示
    }
}
