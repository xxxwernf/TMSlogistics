using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
using Dapper;
using System.Data;
using TMS.IDAL;
using System.Data.SqlClient;
namespace TMS.DAL
{
    //--货主
   public class ShippercontractDAL:ShippercontractIDAL
    {
        //连接数据库
        IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=logistics;Integrated Security=True");

        public List<ShippercontractModel> Show()
        {
            string sql = $"select *from shippercontract";
            return conn.Query<ShippercontractModel>(sql).ToList();
        }
        public int Add(ShippercontractModel s)
        {
            string sql = $"insert into shippercontract values('{s.contracId}','{s.name}','{s.unit}','{s.principal}','{s.path}','{s.fare}','{s.full_fare}','{s.full_money}','{s.agent}','{s.signed_time}','{s.contract_money}','{s.contract_intro}','{s.clause}','{s.contract_text}','{s.creation_time}','{s.state}','{s.approver}')";
            return conn.Execute(sql, s);
        }

        public int Del(int id)
        {
            string sql = $"delete from shippercontract where id in ({id})";
            return conn.Execute(sql, id);
        }

        public ShippercontractModel Fantian(int id)
        {
            string sql = $"select *from shippercontract where id in ({id})";
            return conn.Query<ShippercontractModel>(sql).FirstOrDefault();
        }

      

        public int Update(ShippercontractModel s)
        {
            string sql = $"Update shippercontract set contracId='{s.contracId}',name='{s.name}',unit='{s.unit}',principal='{s.principal}',path='{s.path}',fare='{s.fare}',full_fare='{s.full_fare}',full_money='{s.full_money}',agent='{s.agent}', signed_time='{s.signed_time}',contract_money='{s.contract_money}',contract_intro='{s.contract_intro}',clause='{s.clause}',contract_text='{s.contract_text}',creation_time='{s.creation_time}',state='{s.state}',approver='{s.approver}' where id in ({s.id})";
            return conn.Execute(sql);
        }
        //显示
    }
}
