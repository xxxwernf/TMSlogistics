using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;

namespace TMS.IDAL
{
    public interface PayIDAL
    {
        //显示
        List<PayModel> Show();
        //删除
        int Del(int Payid);
        //添加
        int Add(PayModel s);
        //修改
        int Update(PayModel s);
        //反填
        PayModel Fantian(int Payid);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }

}
