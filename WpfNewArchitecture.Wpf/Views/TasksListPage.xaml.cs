using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using WpfNewArchitecture.ViewModels;

namespace WpfNewArchitecture.Wpf.Views
{
    /// <summary>
    /// Interaction logic for TasksListPage.xaml
    /// </summary>
    public partial class TasksListPage : Page
    {
        public TasksListPage()
        {
            InitializeComponent();

            DataContext = App.Current.Services.GetRequiredService<TasksListViewModel>();
        }
    }
}
