using System.Windows.Controls;
using WpfNewArchitecture.Services;
using WpfNewArchitecture.ViewModels;
using WpfNewArchitecture.Wpf.Views;

namespace WpfNewArchitecture.Wpf.Services
{
    public class NavigationService : INavigationService
    {
        private Frame? _frame;

        /// <inheritdoc />
        public void Navigate<T>(object? args = null)
        {
            if (_frame is null)
            {
                return;
            }

            var content = GetPage(typeof(T), args);

            if (content is null)
            {
                return;
            }

            _frame.Navigate(content);
        }

        private static object GetPage(Type type, object? args = null)
        {
            //TODO: how to fix it?
            if (type == typeof(TasksListViewModel))
            {
                return new TasksListPage();
            }

            if(type == typeof(EditTaskViewModel) && args is not null)
            {
                return new EditTaskPage((Models.Task)args);
            }

            throw new InvalidOperationException("Bad navigation request");
        }

        /// <inheritdoc />
        public void SetFrame(object mainFrame)
        {
            _frame = (Frame)mainFrame;
        }
    }
}
