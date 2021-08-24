using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface carriagecontractIDAL
    {
        //显示
        List<carriagecontractModel> Show();
        //删除
        int Del(int id);
        //添加
        int Add(carriagecontractModel s);
        //修改
        int Update(carriagecontractModel s);
        //反填
        carriagecontractModel Fantian(int id);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
