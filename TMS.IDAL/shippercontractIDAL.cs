using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface shippercontractIDAL
    {
        //显示
        List<shippercontractModel> Show();
        //删除
        int Del(int id);
        //添加
        int Add(shippercontractModel s);
        //修改
        int Update(shippercontractModel s);
        //反填
        shippercontractModel Fantian(int id);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
