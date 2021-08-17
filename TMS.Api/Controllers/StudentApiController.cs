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
        /// <summary>
        /// 日志器工厂
        /// </summary>
        private ILoggerFactory m_LoggerFactory;

        public StudentApiController(ILoggerFactory loggerFactory)
        {
            m_LoggerFactory = loggerFactory;
            // 获取指定名字的日志器
            m_Logger = m_LoggerFactory.CreateLogger("AppLogger");
        }

        ClassDAL dal = new ClassDAL();
    
        //显示
        [Route("Show")]
        [HttpGet]
        public IActionResult Show()
        {
            try
            {
                //数据集
                List<ClassModel> classModels = dal.Show();
                //m_Logger.LogInformation("测试成功");
                return Ok(classModels);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("显示系统异常");
            }   
        }
        //添加
        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromForm] ClassModel s)
        {
            try
            {
                var tianjia = dal.Add(s);
                return Ok(tianjia);
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
        public IActionResult del([FromForm] int Studentid)
        {
            try
            {
                int shanchu = dal.Del(Studentid);
                return Ok(shanchu);
            }
            catch (Exception ex)
            {

                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("删除系统异常");
            }
        }
        //反填
        [Route("Fantian")]
        [HttpPost]
        public IActionResult Fantian([FromForm]int Studentid)
        {
            try
            {
                var fan = dal.Fantian(Studentid);
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
        public IActionResult Update([FromForm] ClassModel s)
        {
            try
            {
                var xiugai = dal.Update(s);
                return Ok(xiugai);
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("添加系统异常");
            }
          
        }
    }
}
