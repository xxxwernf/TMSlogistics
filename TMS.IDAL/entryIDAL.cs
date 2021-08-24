using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface entryIDAL
    {
        //显示
        List<entryModel> Show();
        //删除
        int Del(int id);
        //添加
        int Add(entryModel s);
        //修改
        int Update(entryModel s);
        //反填
        entryModel Fantian(int id);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
