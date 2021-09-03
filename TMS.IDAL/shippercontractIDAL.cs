using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface ShippercontractIDAL
    {
        //显示
        List<ShippercontractModel> Show();
        //删除
        int Del(int id);
        //添加
        int Add(ShippercontractModel s);
        //修改
        int Update(ShippercontractModel s);
        //反填
        ShippercontractModel Fantian(int id);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
