using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IDAL;
using TMS.DAL;
using TMSlogistic.Model;
using Microsoft.Extensions.Logging;
using TMS.Common;
using Microsoft.AspNetCore.Authorization;


//using Microsoft.Extensions.Logging;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        //日志
        /// <summary>
        /// 日志器
        /// </summary>
        private ILogger m_Logger;

        //依赖注入的名字

        private ClassIDAL _classIDAL;
        /// <summary>
        /// 日志器工厂
        /// </summary>
        private ILoggerFactory m_LoggerFactory;
        /// <summary>
        /// JWT(Token)
        /// </summary>
        private Token token;

        //依赖注入的IDAL,idal
        public StudentApiController(ILoggerFactory loggerFactory, ClassIDAL classIDAL, Token _token)
        {
            _classIDAL = classIDAL;

            m_LoggerFactory = loggerFactory;
            // 获取指定名字的日志器
            m_Logger = m_LoggerFactory.CreateLogger("AppLogger");

            token = _token;
        }

        //ClassDAL dal = new ClassDAL();
    
        //显示
        [Route("Show")]
        [HttpGet]
        //[Authorize]
        public IActionResult Show()
        {
            try
            {
                //数据集
                List<ClassModel> classModels = _classIDAL.Show();
                //m_Logger.LogInformation("测试成功");
                return Ok(classModels);
            }
            catch(Exception ex)
            {
                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("显示系统异常");
            }   
        }
        //添加
        [Route("add")]
        [HttpPost]
        //[Authorize]
        public IActionResult Add(ClassModel s)
        {
            try
            {
               var tianjia = _classIDAL.Add(s);
               return Ok(new { message = "添加成功", body = tianjia });
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("添加系统异常");
            }

        }
        
        //删除
        [Route("del")]
        [HttpPost]
        //[Authorize]
        public IActionResult del( int Studentid)
        {
            try
            {
                int shanchu = _classIDAL.Del(Studentid);
                return Ok(new { message = "删除成功", body = shanchu });
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("删除系统异常");
            }
        }
        //反填
        [Route("Fantian")]
        [HttpGet]
        //[Authorize]
        public IActionResult Fantian(int Studentid)
        {
            try
            {
                var fan = _classIDAL.Fantian(Studentid);
                return Ok(fan);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("添加系统异常");
            }
           
        }
        //修改
        [Route("Update")]
        [HttpPost]
        //[Authorize]
        public IActionResult Update(ClassModel s)
        {
            try
            {
                var xiugai = _classIDAL.Update(s);
                return Ok(new { message = "修改成功", body = xiugai });
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("添加系统异常");
            }
          
        }
        //登录
        [Route("Login")]
        [HttpGet]
        public IActionResult login(string LoginName,string LoginMima)
        {
            try
            {
               var  denglu= _classIDAL.login(LoginName,LoginMima);
                m_Logger.LogInformation("测试成功");
                if (denglu != null)
                {
                    return Ok(new { message="登录成功",body= denglu ,token= token .Authenticate()});
                }
                else
                {
                    return Ok(new { message = "登录失败", body = denglu });
                }
                
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("登录系统异常");
            }

        }
    }
}
