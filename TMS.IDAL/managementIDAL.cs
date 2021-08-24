using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface managementIDAL
    {
        //显示
        List<managementModel> Show();
        //删除
        int Del(int managementid);
        //添加
        int Add(managementModel s);
        //修改
        int Update(managementModel s);
        //反填
        managementModel Fantian(int managementid);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
