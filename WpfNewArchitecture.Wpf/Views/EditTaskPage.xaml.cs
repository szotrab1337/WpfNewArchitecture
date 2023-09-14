using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using WpfNewArchitecture.ViewModels;

namespace WpfNewArchitecture.Wpf.Views
{
    /// <summary>
    /// Interaction logic for EditTaskPage.xaml
    /// </summary>
    public partial class EditTaskPage : Page
    {
        public EditTaskPage(Models.Task task)
        {
            InitializeComponent();

            _task = task;
            DataContext = App.Current.Services.GetRequiredService<EditTaskViewModel>();
        }

        public EditTaskViewModel ViewModel => (EditTaskViewModel)DataContext;

        private readonly Models.Task _task;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Initialize(_task);
        }
    }
}
