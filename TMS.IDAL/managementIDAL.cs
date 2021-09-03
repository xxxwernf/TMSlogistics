using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface ManagementIDAL
    {
        //显示
        List<ManagementModel> Show();
        //删除
        int Del(int managementid);
        //添加
        int Add(ManagementModel s);
        //修改
        int Update(ManagementModel s);
        //反填
        ManagementModel Fantian(int managementid);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
