using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using MedicalManagement.Service.ObjectMaps;
using MedicalManagement.Service;
using MedicalManagement.EntityFramework.Datas;

namespace MedicalManagement.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
#if DEBUG //调试状态下添加控制台 实际运行环境下不要用Console记录日志
                      .WriteTo.Console()
#endif
                      .WriteTo.Seq("http://43.142.56.188:5341/", apiKey: "HyaUagfxYAWcE8Te3P9I")
                      .CreateLogger();

            builder.Host.UseSerilog();

            //Autofac 与原生完全兼容 互相不冲突
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule<MedicalManagementServiceModule>();
            });
            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(MedicalManagementProfile));
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });


            builder.Services.AddDbContextPool<MyDbContext>(options =>
            {
                var connectionStr = builder.Configuration.GetConnectionString("Default");
                var version = ServerVersion.AutoDetect(connectionStr);
                //options.UseLoggerFactory(LoggerFactory.Create(e =>
                //{
                //    e.ClearProviders();
                //}));

                options.UseMySql(connectionStr, version, x => x.MigrationsAssembly("MedicalManagement.EntityFramework"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging();
                
            });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseSerilogRequestLogging(); // <-- Add this line

            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
    
