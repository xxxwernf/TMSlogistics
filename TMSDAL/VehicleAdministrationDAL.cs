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
    //车辆
    public class VehicleAdministrationDAL : VehicleAdministrationIDAL
    {
        //连接数据库
        IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=logistics;Integrated Security=True");

        //显示
        public List<VehicleAdministrationModell> Show()
        {
            string sql = $"select *from VehicleAdministration";
            return conn.Query<VehicleAdministrationModell>(sql).ToList();
        }
        public int Add(VehicleAdministrationModell s)
        {
          string sql = $"insert into VehicleAdministration values('{s.VehicleAdministrationModel}','{s.VehicleAdministrationLicense}','{s.VehicleAdministrationName}','{s.VehicleAdministrationCompany}','{s.VehicleAdministrationType}','{s.VehicleAdministrationColor}','{s.VehicleAdministrationDate}','{s.VehicleAdministrationRun}','{s.VehicleAdministrationEndtime}','{s.VehicleAdministrationYearDate}','{s.VehicleAdministrationMaintain}')";
            return conn.Execute(sql, s);
        }

        public int Del(int VehicleAdministrationid)
        {
            string sql = $"delete from VehicleAdministration where VehicleAdministrationid in ({VehicleAdministrationid})";
            return conn.Execute(sql, VehicleAdministrationid);
        }

        public VehicleAdministrationModell Fantian(int VehicleAdministrationid)
        {
            string sql = $"select *from VehicleAdministration where VehicleAdministrationid in ({VehicleAdministrationid})";
            return conn.Query<VehicleAdministrationModell>(sql).FirstOrDefault();
        }

      

        public int Update(VehicleAdministrationModell s)
        {
            string sql = $"Update VehicleAdministration set VehicleAdministrationModel='{s.VehicleAdministrationModel}',VehicleAdministrationLicense='{s.VehicleAdministrationLicense}',VehicleAdministrationName='{s.VehicleAdministrationName}',VehicleAdministrationCompany='{s.VehicleAdministrationCompany}',VehicleAdministrationType='{s.VehicleAdministrationType}',VehicleAdministrationColor='{s.VehicleAdministrationColor}',VehicleAdministrationDate='{s.VehicleAdministrationDate}',VehicleAdministrationRun='{s.VehicleAdministrationRun}',VehicleAdministrationEndtime='{s.VehicleAdministrationEndtime}',VehicleAdministrationYearDate='{s.VehicleAdministrationYearDate}',VehicleAdministrationMaintain='{s.VehicleAdministrationMaintain}' where VehicleAdministrationid in ({s.VehicleAdministrationid})";
            return conn.Execute(sql);
        }
    }
}
