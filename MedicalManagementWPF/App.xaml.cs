using MedicalManagementWPF.Views;
using Prism.Ioc;
using System.Net.Http;
using System.Windows;

namespace MedicalManagementWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<LoginWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<HttpClient>
        }
    }
}
