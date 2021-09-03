using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface EntryIDAL
    {
        //显示
        List<EntryModel> Show();
        //删除
        int Del(int id);
        //添加
        int Add(EntryModel s);
        //修改
        int Update(EntryModel s);
        //反填
        EntryModel Fantian(int id);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
