using System;
using System.Collections.Generic;
using TMSlogistic.Model;
namespace TMS.IDAL
{
    public interface ClassIDAL
    {
        //显示
        List<ClassModel> Show();
        //删除
        int Del(int Studentid);
        //添加
        int Add(ClassModel s);
        //修改
        int Update(ClassModel s);
        //反填
        ClassModel Fantian(int Studentid);
    }
}
