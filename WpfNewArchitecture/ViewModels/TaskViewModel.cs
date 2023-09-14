using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfNewArchitecture.ViewModels
{
    public partial class TaskViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _text;

        [ObservableProperty]
        private bool _isCompleted;

        public TaskViewModel(
            Models.Task task,
            IRelayCommand<TaskViewModel>? complete = null)
        {
            Task = task;
            CompleteCommand = complete;

            Text = task.Text;
            IsCompleted = task.IsCompleted;
        }

        public Models.Task Task { get; }

        public IRelayCommand<TaskViewModel>? CompleteCommand { get; }

        partial void OnIsCompletedChanged(bool value)
        {
            CompleteCommand?.Execute(this);
        }
    }
}
