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

        //����Ӧ�ó���ķ�������ݣ������������������������Ҫ��������(�൱������ע��)
        public void ConfigureServices(IServiceCollection services)
        {
            //����ע����������
            //Transient,
            //1,˲ʱ����������ÿ�ζ�Ҫ����������ʱ������(ÿ�ζ�Ҫnewһ��,ÿ�����ݶ���һ��)
            //2���ʺ�����������״̬�ķ���
            //Scoped
            //�����������������ڿͻ��ˣ����ӣ�����ÿ�����е�ʱ�򴴽�һ�Σ�����������ٸ����ݶ���ͬһ�����ݣ�������һ�������ڣ�����Ψһ
            //Singleton
            //�������������������ǵ�һ�α�����ʱ����������ÿ������������ʹ����ͬ��ʵ����ÿ�ε�����������ͬһ����
            services.AddTransient<ClassIDAL, ClassDAL>();
            services.AddTransient<Token>();
            ////����ע�����÷�ʽ
            //services.AddSingleton<ClassIDAL, ClassDAL>(); 
            ////����ע��
            //services.AddScoped<ClassIDAL, ClassDAL>();
            //����
            services.AddCors(a =>
            {
                a.AddPolicy("cor", b => b.AllowCredentials().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(_ => true));
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TMS.Api", Version = "v1" });

                #region swagger��JWT��֤
                //����Ȩ��С��
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //��header�����token�����ݵ���̨
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���)ֱ���������������Bearer {token}(ע������֮����һ���ո�) \"",
                    Name = "Authorization",// tĬ�ϵĲ�������
                    In = ParameterLocation.Header,// tĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion

            });

            #region  GWT��startup.cs�е�configureservice�����������Ȩ��֤
            var jwtConfig = Configuration.GetSection("Jwt");
            //������Կ
            var symmetricKeyAsBase64 = jwtConfig.GetValue<string>("Secret");
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            //��֤����
            services.AddAuthentication("Bearer")
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,//�Ƿ���֤ǩ��,����֤�Ļ����Դ۸����ݣ�����ȫ��Configure���������֤����
                    //4������Jwt��Token����
                    IssuerSigningKey = signingKey,//���ܵ���Կ
                    ValidateIssuer = true,//�Ƿ���֤�����ˣ�������֤�غ��е�Iss�Ƿ��ӦValidIssuer����
                    ValidIssuer = jwtConfig.GetValue<string>("Iss"),//������
                    ValidateAudience = true,//�Ƿ���֤�����ˣ�������֤�غ��е�Aud�Ƿ��ӦValidAudience����
                    ValidAudience = jwtConfig.GetValue<string>("Aud"),//������
                    ValidateLifetime = true,//�Ƿ���֤����ʱ�䣬�����˾;ܾ�����
                    ClockSkew = TimeSpan.Zero,//����ǻ������ʱ�䣬Ҳ����˵����ʹ���������˹���ʱ�䣬����ҲҪ���ǽ�ȥ������ʱ�� + ���壬Ĭ�Ϻ�����7���ӣ������ֱ������Ϊ0
                    RequireExpirationTime = true,
                };
            });
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        //�������д���ؽ��ܸ���http����Ĺܵ���
        //Configure ����Run��ʱ��ִ�еģ�ִֻ��һ�Σ�ִ��Main������ִ����ɺ���������ݾ�ֱ�Ӵ浽�ܵ����ˣ�ÿ�����е�ʱ�򣬾������йܵ���

        
        //�ܵ���Դ����IApplicationBuilder
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //�м�����������࣬�ſ��Լ��뵽����
            //�м�����������࣬������ͨ����������ע��
            //// �Ƿ�Ϊ��������
            if (env.IsDevelopment())
            {
                //������Ա�쳣ҳ���м������������쳣�����������쳣�ڵ�ҳ������ʾ���������ҷǳ���ϸ
                //�����Ѻ�
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMS.Api v1"));
            }
            app.UseHttpsRedirection();
            // ·���м����ʶ��·�ɣ�ƥ��·�ɺ��ս��
            app.UseRouting();
            app.UseAuthentication(); //����������֤��
            app.UseAuthorization(); //����Ƿ������Դ�����Ȩ
            app.UseAuthorization();
            //����
            app.UseCors("cor");
            // �նˣ��ս�� ���м��
            //�ս�㣬������ΪӦ�ó����ṩ���HTTP����Ĵ�����
            //MVCӦ�ã��ս��Ͷ�Ӧ�ſ������е�ĳ������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //��ϵ
            //app.Use(async (context, next) =>

            //    {

            //        await next();
            //        await context.Response.WriteAsync("�ڶ����м��");
            //   });
            //�첽
            //��ν���м������ʵ����һ��ί�У���û��next�����жϣ���·��

            //д�м��(�ն�)
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("this is end zhongjianjie3");
            //});
            //�м��˳�򣬹ܵ����м������˳��ģ����Ǵ����˳��
            //˳���ر���Ҫ��



        }
        //Autofac����ע��
        //ͨ������������ע��
        //ֻҪָ������·������

        //�Զ�ע������ע��(ģ�黯)
        public void ConfigureContainer(ContainerBuilder build)
        {

            var file = System.IO.Path.Combine(AppContext.BaseDirectory, "TMS.DAL.dll");
            build.RegisterAssemblyTypes(Assembly.LoadFile(file)).AsImplementedInterfaces();

        }
        ////������ֱ����AutoFacע�����Լ��Ķ�������Ҫ
        ////����builder. Populate(),�ⷢ����AutofacServ iceProv iderF actory��
        //bui1der.RegisterAssemblyTypes(typeof(ClassDAL).Assembly)
        //    . Where(x => x.Name.EndsWith("DAL"))
        //    .AsImplementedInterfaces();
        ////bui1der.RegisterAssemblyTypes(typeof().Assemb1y)
        ////    .Where(x =��x.Name.EndsWith(" Service"))
        ////    .AsImp1ementedInterfaces();
        ///


        //�м�����Ǵ���App����͹ܵ��������������ܵ�֮�еķǳ���Ҫ�Ĺ��̣�
        //���Դ����û��쳣�������쳣��������ʾ 
        //��Ҫ��վ����һЩ�ļ���ͼƬ����̬������Ҫ�м��
        //�м�����̣�
        // Logging ---->StaticFiles------>MVC  
        //<--Logging -------StaticFiles ______MVC
        //�м��
        //1.��ͬʱ�����ʺ�����
        //2.���Դ��������Ȼ�����󴫵ݸ���һ���м��
        //3.���Դ�������󣬲��ǹܵ���·
        //4.���Դ�������Ӧ
        //5.�м���ǰ�����ӵ�˳��ִ�еģ������м������˳��ִ�У�

        //����run use 
        //run:�ն��м����������˵�����м�����������ݣ�����ֻ�ܳ�����һ���м�������ݣ�

        //�ٸ�����
        // app.Run(async(context)=>){
        //
        //  await context.Response.WriteAsync("��һ���м��")
        // }
        // app.Run(async(context)=>){
        //
        //  await context.Response.WriteAsync("�ڶ����м��")
        // }


        //use: ���� next,��һ�У��Ϳ��������м�����������

        //�ٸ����ӣ����еģ��ܵ���Ӧ��
        // app.Run(async(context)=>){
        //
        //  await context.Response.WriteAsync("�������м��")
        // }
        // app.Use(async(context,next)=>){
        //
        //await next();
        //  await context.Response.WriteAsync("��һ���м��")
        // }
        // app.Use(async(context,next)=>){
        //
        //await next();
        //  await context.Response.WriteAsync("�ڶ����м��")
        // }


        //�м��Logger
        // ��Public void Configure(,ILogger<Startup>logger)
        // {

        // app.Use(async(context,next)=>){
        //
        //  logger.LogInformation("MW1:��������")
        //   await next();
        //   logger.LogInformation("MW1:������Ӧ")
        // }
        // app.Use(async(context,next)=>){
        //
        //  logger.LogInformation("MW2:��������")
        //   await next();
        //   logger.LogInformation("MW2:������Ӧ")
        // }
        // app.Run(async(context)=>){
        //
        // �����ģ��������ʾ
        //   await context.Response.WriteAsync("MW2:��������")
        //   
        //   logger.LogInformation("MW3:�������󣬲�������Ӧ")
        // }
        // 

        // }
        //�м�����ڲ������ǵ���use,���ǵ���run
        //����ƶ��м��

        //�м��Ӧ�ó���
        //1,���д��WebӦ�ã�ʵ���Ͼ�����д�м����ȫ���м��
        //2.��д�Ŀ�������Ҳ���м����һ����
        //3.����Asp.NET CoreӦ�ã������ڹܵ������еģ��ܵ���ŵĶ����м�� 


    }
}
