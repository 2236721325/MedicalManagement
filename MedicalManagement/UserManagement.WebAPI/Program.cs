using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using UserManagement.Service;
using UserManagement.Service.ObjectMaps;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagement.WebAPI.Settings;
using MedicalManagement.EntityFramework.Datas;

namespace UserManagement.WebAPI
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
                      .WriteTo.Seq("http://43.142.56.188:5341/",apiKey: "HyaUagfxYAWcE8Te3P9I")
                      .CreateLogger();

            builder.Host.UseSerilog();

            //Autofac 与原生完全兼容 互相不冲突
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule<UserManagementServiceModule>();
            });
            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(UserManagementProfile));
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWT"));//也是依赖注入 注入的时候带有默认值（appsettings读取）
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //配置JWT身份验证方案
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //使用JWT身份验证挑战

            }).AddJwtBearer(option =>
            {
                var jwtSettings = builder.Configuration.GetSection("JWT").Get<JWTSettings>();

                byte[] keyBytes = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
                var secretKey = new SymmetricSecurityKey(keyBytes);
                //验证的配置添加
                option.TokenValidationParameters = new()
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = secretKey
                };

            });

            builder.Services.AddDbContextPool<MyDbContext>(options =>
            {
                var connectionStr = builder.Configuration.GetConnectionString("Default");
                var version = ServerVersion.AutoDetect(connectionStr);
                options.UseLoggerFactory(LoggerFactory.Create(e =>
                {
                    e.ClearProviders();
                }));

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseMySql(connectionStr, version, x => x.MigrationsAssembly("MedicalManagement.EntityFramework"));
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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}