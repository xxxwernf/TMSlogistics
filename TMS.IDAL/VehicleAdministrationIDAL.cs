using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    //车辆
    public interface VehicleAdministrationIDAL
    {
        //显示
        List<VehicleAdministrationModell> Show();
        //删除
        int Del(int VehicleAdministrationid);
        //添加
        int Add(VehicleAdministrationModell s);
        //修改
        int Update(VehicleAdministrationModell s);
        //反填
        VehicleAdministrationModell Fantian(int VehicleAdministrationid);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
