using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    //员工
    public interface UserIDAL
    {
        //显示
        List<UsersModel> Show();
        //删除
        int Del(int Usersid);
        //添加
        int Add(UsersModel s);
        //修改
        int Update(UsersModel s);
        //反填
        UsersModel Fantian(int Usersid);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
