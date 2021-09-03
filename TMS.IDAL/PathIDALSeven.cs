using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface PathIDALSeven
    {
        //显示
        List<PathModel> Show();
        //删除
        int Del(int pathId);
        //添加
        int Add(PathModel s);
        //修改
        int Update(PathModel s);
        //反填
        PathModel Fantian(int pathId);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
