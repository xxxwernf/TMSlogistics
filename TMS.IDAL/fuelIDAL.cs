using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface fuelIDAL
    {
        //显示
        List<fuelModel> Show();
        //删除
        int Del(int fuelId);
        //添加
        int Add(fuelModel s);
        //修改
        int Update(fuelModel s);
        //反填
        fuelModel Fantian(int fuelId);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
