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
        //ÿ�����е�ʱ�򶼵Ĵ�Main������ʼ������ڣ���
        public static void Main(string[] args)
        {
           
            //Build�йܣ�Run ����web���߱��������
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                 .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //����// ע�������������Autofac�����
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //�����һ���м��������Startup
                    webBuilder.UseStartup<Startup>();
                });

            // ʹ��NLog��Ϊ��־��¼
            builder.ConfigureLogging(logging =>
            {
                // ���ԭ�е���־��
                logging.ClearProviders();
            }).UseNLog();

            return builder;
        }

    }
}
