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
#if DEBUG //����״̬����ӿ���̨ ʵ�����л����²�Ҫ��Console��¼��־
                      .WriteTo.Console()
#endif
                      .WriteTo.Seq("http://43.142.56.188:5341/",apiKey: "HyaUagfxYAWcE8Te3P9I")
                      .CreateLogger();

            builder.Host.UseSerilog();

            //Autofac ��ԭ����ȫ���� ���಻��ͻ
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

            builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWT"));//Ҳ������ע�� ע���ʱ�����Ĭ��ֵ��appsettings��ȡ��
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //����JWT�����֤����
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //ʹ��JWT�����֤��ս

            }).AddJwtBearer(option =>
            {
                var jwtSettings = builder.Configuration.GetSection("JWT").Get<JWTSettings>();

                byte[] keyBytes = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
                var secretKey = new SymmetricSecurityKey(keyBytes);
                //��֤���������
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