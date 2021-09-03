using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface CarriagecontractIDAL
    {
        //显示
        List<CarriagecontractModel> Show();
        //删除
        int Del(int id);
        //添加
        int Add(CarriagecontractModel s);
        //修改
        int Update(CarriagecontractModel s);
        //反填
        CarriagecontractModel Fantian(int id);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
