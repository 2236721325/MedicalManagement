using Autofac;
using Base.Shared;
using MedicalManagement.Domain.Models;
using MedicalManagement.Service.IServices;
using MedicalManagement.Service.Services;
using System.Net.Mime;
using System.Reflection;
using Module = Autofac.Module;

namespace MedicalManagement.Service
{
    public class MedicalManagementServiceModule : Module
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

