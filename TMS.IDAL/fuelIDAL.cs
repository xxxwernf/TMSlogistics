using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface FuelIDAL
    {
        //显示
        List<FuelModel> Show();
        //删除
        int Del(int fuelId);
        //添加
        int Add(FuelModel s);
        //修改
        int Update(FuelModel s);
        //反填
        FuelModel Fantian(int fuelId);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
