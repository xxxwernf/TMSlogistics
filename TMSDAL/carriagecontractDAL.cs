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
    //--承运
   public class carriagecontractDAL:carriagecontractIDAL
    {
        //连接数据库
        IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=logistics;Integrated Security=True");

        public List<carriagecontractModel> Show()
        {
            string sql = $"select *from carriagecontract";
            return conn.Query<carriagecontractModel>(sql).ToList();
        }
        public int Add(carriagecontractModel s)
        {
            string sql = $"insert into carriagecontract values('{s.contractId}','{s.Name}','{s.unit}','{s.principal}','{s.path}','{s.price}','{s.full_price}','{s.full_money}','{s.Signing_time}','{s.agent}','{s.creation_time}','{s.state}','{s.approval}','{s.contract_time}','{s.contract_explain}','{s.contract_clause}','{s.contract_text}')";
            return conn.Execute(sql, s);
        }

        public int Del(int id)
        {
            string sql = $"delete from carriagecontract where id in ({id})";
            return conn.Execute(sql, id);
        }

        public carriagecontractModel Fantian(int id)
        {
            string sql = $"select *from carriagecontract where id in ({id})";
            return conn.Query<carriagecontractModel>(sql).FirstOrDefault();
        }

        

        public int Update(carriagecontractModel s)
        {
            string sql = $"Update carriagecontract set contractId='{s.contractId}',Name='{s.Name}',unit='{s.unit}',principal='{s.principal}',path='{s.path}',price='{s.price}',full_price='{s.full_price}',full_money='{s.full_money}',Signing_time='{s.Signing_time}', agent='{s.agent}',creation_time='{s.creation_time}',state='{s.state}',approval='{s.approval}',contract_time='{s.contract_time}',contract_explain='{s.contract_explain}',contract_clause='{s.contract_clause}',contract_text='{s.contract_text}' where id in ({s.id})";
            return conn.Execute(sql);
        }
    }
}
