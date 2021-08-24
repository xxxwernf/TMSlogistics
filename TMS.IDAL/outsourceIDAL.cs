using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface outsourceIDAL
    {
        //显示
        List<outsourceModel> Show();
        //删除
        int Del(int outsourceId);
        //添加
        int Add(outsourceModel s);
        //修改
        int Update(outsourceModel s);
        //反填
        outsourceModel Fantian(int outsourceId);
        ////登录
        //Login login(string LoginName, string LoginMima);
    }
}
