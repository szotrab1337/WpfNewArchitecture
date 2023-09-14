using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfNewArchitecture.Services;

namespace WpfNewArchitecture.ViewModels
{
    public partial class EditTaskViewModel : ObservableObject
    {
        private readonly ITaskService _taskService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string _text = string.Empty;

        private Models.Task _task = null!;

        public EditTaskViewModel(
            ITaskService taskService,
            INavigationService navigationService)
        {
            _taskService = taskService;
            _navigationService = navigationService;
        }

        public void Initialize(Models.Task task)
        {
            _task = task;
            Text = _task.Text;
        }

        [RelayCommand]
        private void Save()
        {
            _taskService.UpdateText(_task, Text);
            _navigationService.Navigate<TasksListViewModel>();
        }
    }
}
