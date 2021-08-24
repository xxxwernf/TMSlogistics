using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface pathIDAL
    {
        //显示
        List<pathModel> Show();
        //删除
        int Del(int pathId);
        //添加
        int Add(pathModel s);
        //修改
        int Update(pathModel s);
        //反填
        pathModel Fantian(int pathId);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
