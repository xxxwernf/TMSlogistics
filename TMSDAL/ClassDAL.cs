using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TMS.IDAL;
using TMSlogistic.Model;
using Dapper;
using System.Linq;

namespace TMS.DAL
{
    public class ClassDAL : ClassIDAL
    {
        //连接数据库
        IDbConnection conn = new SqlConnection("Data Source=.;Initial Catalog=logistics;Integrated Security=True");
        //显示
        public List<ClassModel> Show()
        {
            string sql = $"select *from Student";
            return conn.Query<ClassModel>(sql).ToList();
        }
        //添加
        public int Add(ClassModel s)
        {
            string sql = $"insert into Student values('{s.Studentname}',{s.Studentage},'{s.Studentdizhi}','{s.StudentTime}')";
            return conn.Execute(sql,s);
        }
        //删除
        public int Del(int Studentid)
        {
            string sql = $"delete from Student where Studentid in ({Studentid})";
            return conn.Execute(sql,Studentid);
        }
        //反填
        public ClassModel Fantian(int Studentid)
        {
            string sql = $"select *from Student where Studentid in ({Studentid})";
            return conn.Query<ClassModel>(sql).FirstOrDefault();
        }
        //修改
        public int Update(ClassModel s)
        {
            string sql = $"Update Student set Studentname='{s.Studentname}',Studentage='{s.Studentage}',Studentdizhi='{s.Studentdizhi}',StudentTime='{s.StudentTime}' where Studentid in ({s.Studentid})";
            return conn.Execute(sql);
        }
    }
}
