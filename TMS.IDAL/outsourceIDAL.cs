using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface OutsourceIDAL
    {
        //显示
        List<OutsourceModel> Show();
        //删除
        int Del(int outsourceId);
        //添加
        int Add(OutsourceModel s);
        //修改
        int Update(OutsourceModel s);
        //反填
        OutsourceModel Fantian(int outsourceId);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
