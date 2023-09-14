using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfNewArchitecture.Services;
using WpfNewArchitecture.ViewModels;

namespace WpfNewArchitecture.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var navigationService = App.Current.Services.GetRequiredService<INavigationService>();
            navigationService.SetFrame(MainFrame);
            navigationService.Navigate<TasksListViewModel>(); //Init page

            DataContext = App.Current.Services.GetRequiredService<MainViewModel>();
        }
    }
}