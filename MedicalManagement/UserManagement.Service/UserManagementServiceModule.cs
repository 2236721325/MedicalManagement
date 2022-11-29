using Autofac;
using Base.Shared;
using MedicalManagement.Domain.Models;
using System.Net.Mime;
using System.Reflection;
using Module = Autofac.Module;

namespace UserManagement.Service
{
    public class UserManagementServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var baseType = typeof(IDependency);
            var assembly = Assembly.GetExecutingAssembly();//当前程序集；MedicalManagement.Service

            builder.RegisterAssemblyTypes(assembly)
                            .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                            .AsImplementedInterfaces();

        }
    }
}

