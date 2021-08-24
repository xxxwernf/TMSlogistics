using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMS.Common;
using TMS.DAL;
using TMS.IDAL;

namespace TMS.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // 

        //配置应用程序的服务和内容，比如第三方插件和组件，都需要他来调用(相当于里面注册)
        public void ConfigureServices(IServiceCollection services)
        {
            //依赖注入生命周期
            //Transient,
            //1,瞬时生命周期是每次都要从容器请求时被创建(每次都要new一次,每次数据都不一样)
            //2，适合轻量级，无状态的服务
            //Scoped
            //作用域生命周期是在客户端（连接），（每次运行的时候创建一次，不管里面多少个数据都是同一个数据，），在一个请求内，都是唯一
            //Singleton
            //单例生命周期是在它们第一次被请求时创建，并且每个后续的请求讲使用相同的实例（每次的数据请求都是同一个）
            services.AddTransient<ClassIDAL, ClassDAL>();
            services.AddTransient<Token>();
            ////依赖注入配置方式
            //services.AddSingleton<ClassIDAL, ClassDAL>(); 
            ////依赖注入
            //services.AddScoped<ClassIDAL, ClassDAL>();
            //跨域
            services.AddCors(a =>
            {
                a.AddPolicy("cor", b => b.AllowCredentials().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(_ => true));
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TMS.Api", Version = "v1" });

                #region swagger用JWT验证
                //开启权限小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
                    Name = "Authorization",// t默认的参数名称
                    In = ParameterLocation.Header,// t默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion

            });

            #region  GWT在startup.cs中的configureservice方法，添加授权认证
            var jwtConfig = Configuration.GetSection("Jwt");
            //生成密钥
            var symmetricKeyAsBase64 = jwtConfig.GetValue<string>("Secret");
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            //认证参数
            services.AddAuthentication("Bearer")
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,//是否验证签名,不验证的画可以篡改数据，不安全在Configure方法添加认证方法
                    //4、生成Jwt的Token令牌
                    IssuerSigningKey = signingKey,//解密的密钥
                    ValidateIssuer = true,//是否验证发行人，就是验证载荷中的Iss是否对应ValidIssuer参数
                    ValidIssuer = jwtConfig.GetValue<string>("Iss"),//发行人
                    ValidateAudience = true,//是否验证订阅人，就是验证载荷中的Aud是否对应ValidAudience参数
                    ValidAudience = jwtConfig.GetValue<string>("Aud"),//订阅人
                    ValidateLifetime = true,//是否验证过期时间，过期了就拒绝访问
                    ClockSkew = TimeSpan.Zero,//这个是缓冲过期时间，也就是说，即使我们配置了过期时间，这里也要考虑进去，过期时间 + 缓冲，默认好像是7分钟，你可以直接设置为0
                    RequireExpirationTime = true,
                };
            });
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        //管理运行处理池接受各种http请求的管道，
        //Configure 主机Run的时候执行的，只执行一次，执行Main方法（执行完成后，里面的数据就直接存到管道里了，每次运行的时候，就在运行管道）

        
        //管道的源码在IApplicationBuilder
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //中间件所依赖的类，才可以加入到容器
            //中间件所依赖的类，都可以通过服务容器注入
            //// 是否为开发环境
            if (env.IsDevelopment())
            {
                //开发人员异常页面中间件，如果出现异常，他会把这个异常在的页面上显示出来，而且非常详细
                //界面友好
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMS.Api v1"));
            }
            app.UseHttpsRedirection();
            // 路由中间件，识别路由，匹配路由和终结点
            app.UseRouting();
            app.UseAuthentication(); //这个是添加认证的
            app.UseAuthorization(); //这个是方法里自带的授权
            app.UseAuthorization();
            //跨域
            app.UseCors("cor");
            // 终端（终结点 ）中间件
            //终结点，可以视为应用程序提供针对HTTP请求的处理器
            //MVC应用，终结点就对应着控制器中的某个方法
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //联系
            //app.Use(async (context, next) =>

            //    {

            //        await next();
            //        await context.Response.WriteAsync("第二个中间件");
            //   });
            //异步
            //所谓的中间件，其实就是一堆委托，（没有next就是中断，短路）

            //写中间件(终端)
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("this is end zhongjianjie3");
            //});
            //中间件顺序，管道里中间件是有顺序的，就是代码的顺序
            //顺序特别重要，



        }
        //Autofac批量注入
        //通过程序集来依赖注入
        //只要指定程序集路径即可

        //自动注册依赖注入(模块化)
        public void ConfigureContainer(ContainerBuilder build)
        {

            var file = System.IO.Path.Combine(AppContext.BaseDirectory, "TMS.DAL.dll");
            build.RegisterAssemblyTypes(Assembly.LoadFile(file)).AsImplementedInterfaces();

        }
        ////在这里直接向AutoFac注册您自己的东西，不要
        ////调用builder. Populate(),这发生在AutofacServ iceProv iderF actory中
        //bui1der.RegisterAssemblyTypes(typeof(ClassDAL).Assembly)
        //    . Where(x => x.Name.EndsWith("DAL"))
        //    .AsImplementedInterfaces();
        ////bui1der.RegisterAssemblyTypes(typeof().Assemb1y)
        ////    .Where(x =〉x.Name.EndsWith(" Service"))
        ////    .AsImp1ementedInterfaces();
        ///


        //中间件，是处理App请求和管道，服务于整个管道之中的非常重要的过程，
        //可以处理用户异常，拦截异常，给出提示 
        //需要网站处理一些文件，图片，静态，都需要中间件
        //中间件流程，
        // Logging ---->StaticFiles------>MVC  
        //<--Logging -------StaticFiles ______MVC
        //中间件
        //1.可同时被访问和请求
        //2.可以处理请求后，然后将请求传递给下一个中间件
        //3.可以处理请求后，并是管道短路
        //4.可以处理传出响应
        //5.中间件是按照添加的顺序执行的（两个中间件，按顺序执行）

        //数据run use 
        //run:终端中间件，（比如说两个中间件，都有数据，但是只能出来第一个中间件的数据）

        //举个例子
        // app.Run(async(context)=>){
        //
        //  await context.Response.WriteAsync("第一个中间件")
        // }
        // app.Run(async(context)=>){
        //
        //  await context.Response.WriteAsync("第二个中间件")
        // }


        //use: 里面 next,下一行，就可以两个中间件输出出来了

        //举个例子（运行的，管道响应）
        // app.Run(async(context)=>){
        //
        //  await context.Response.WriteAsync("第三个中间件")
        // }
        // app.Use(async(context,next)=>){
        //
        //await next();
        //  await context.Response.WriteAsync("第一个中间件")
        // }
        // app.Use(async(context,next)=>){
        //
        //await next();
        //  await context.Response.WriteAsync("第二个中间件")
        // }


        //中间件Logger
        // 在Public void Configure(,ILogger<Startup>logger)
        // {

        // app.Use(async(context,next)=>){
        //
        //  logger.LogInformation("MW1:传入请求")
        //   await next();
        //   logger.LogInformation("MW1:传出响应")
        // }
        // app.Use(async(context,next)=>){
        //
        //  logger.LogInformation("MW2:传入请求")
        //   await next();
        //   logger.LogInformation("MW2:传出响应")
        // }
        // app.Run(async(context)=>){
        //
        // 上下文，输出，显示
        //   await context.Response.WriteAsync("MW2:传入请求")
        //   
        //   logger.LogInformation("MW3:处理请求，并生成响应")
        // }
        // 

        // }
        //中间件的内部，不是调用use,就是调用run
        //如何制定中间件

        //中间件应用场景
        //1,你编写的Web应用，实际上就是在写中间件，全是中间件
        //2.你写的控制器，也是中间件的一部分
        //3.整个Asp.NET Core应用，都是在管道里运行的，管道里放的都是中间件 


    }
}
