using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfNewArchitecture.Extensions;
using WpfNewArchitecture.Services;
using WpfNewArchitecture.Wpf.Views;

namespace WpfNewArchitecture.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            InitializeComponent();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddApplication();
            services.AddSingleton<INavigationService, Services.NavigationService>();

            return services.BuildServiceProvider();
        }
    }
}
