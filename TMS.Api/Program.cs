using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using NLog.Web;
using Autofac.Extensions.DependencyInjection;

namespace TMS.Api
{
    public class Program
    {
        //每次运行的时候都的从Main方法开始（主入口），
        public static void Main(string[] args)
        {
           
            //Build托管，Run 请求web或者编译的请求
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                 .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //配置// 注册第三方容器（Autofac）入口
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //这就是一个中间件，传到Startup
                    webBuilder.UseStartup<Startup>();
                });

            // 使用NLog作为日志记录
            builder.ConfigureLogging(logging =>
            {
                // 清除原有的日志器
                logging.ClearProviders();
            }).UseNLog();

            return builder;
        }

    }
}
