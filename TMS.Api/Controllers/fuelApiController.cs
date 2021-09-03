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
namespace TMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelApiController : ControllerBase
    {
        //依赖注入的名字

        private FuelIDAL _fuelIDAL;
        //日志
        /// <summary>
        /// 日志器
        /// </summary>
        private ILogger m_Logger;
        /// <summary>
        /// 日志器工厂
        /// </summary>
        private ILoggerFactory m_LoggerFactory;
        public FuelApiController(ILoggerFactory loggerFactory, FuelIDAL fuelIDAL, Token _token)
        {
            _fuelIDAL = fuelIDAL;

            m_LoggerFactory = loggerFactory;
            // 获取指定名字的日志器
            m_Logger = m_LoggerFactory.CreateLogger("AppLogger");

            //token = _token;
        }
        //显示
        [Route("Show")]
        [HttpGet]
        //[Authorize]
        public IActionResult Show()
        {
            try
            {
                //数据集
                List<FuelModel> fuelModels = _fuelIDAL.Show();
                //m_Logger.LogInformation("测试成功");
                return Ok(fuelModels);
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
        //[Authorize]
        public IActionResult Add(FuelModel s)
        {
            try
            {
                var tianjia = _fuelIDAL.Add(s);
                m_Logger.LogInformation("测试成功");
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
        public IActionResult del(int fuelId)
        {
            try
            {
                int shanchu = _fuelIDAL.Del(fuelId);
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
        public IActionResult Fantian(int fuelId)
        {
            try
            {
                var fan = _fuelIDAL.Fantian(fuelId);
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
        public IActionResult Update(FuelModel s)
        {
            try
            {
                var xiugai = _fuelIDAL.Update(s);
                return Ok(new { message = "修改成功", body = xiugai });
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("添加系统异常");
            }

        }
    }
}
