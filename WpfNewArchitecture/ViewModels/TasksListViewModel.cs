using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WpfNewArchitecture.Services;

namespace WpfNewArchitecture.ViewModels
{
    public partial class TasksListViewModel : ObservableObject
    {
        private readonly ITaskService _taskService;
        private readonly INavigationService _navigationService;
        private readonly IRelayCommand<TaskViewModel> _completeCommand;

        [ObservableProperty]
        private string? _newTask;

        public int QuantityOfCompleted => Tasks.Count(x => x.IsCompleted);

        public TasksListViewModel(
            ITaskService taskService,
            INavigationService navigationService)
        {
            _taskService = taskService;
            _navigationService = navigationService;

            _completeCommand = new RelayCommand<TaskViewModel>(CompleteTask);

            Initialize();
        }

        public ObservableCollection<TaskViewModel> Tasks { get; } = new();

        public void Initialize()
        {
            if (Tasks.Count > 0)
            {
                Tasks.Clear();
            }

            _taskService.TaskCompletionChanged += OnTaskCompletionChanged;
            _taskService.TaskDeleted += OnTaskDeleted;

            foreach (var task in _taskService.GetTasks())
            {
                Tasks.Add(CreateTaskVm(task));
            }
        }

        private void OnTaskCompletionChanged(object? sender, Models.Task e)
        {
            OnPropertyChanged(nameof(QuantityOfCompleted));
        }

        //private void OnTaskTextChanged(object? sender, Models.Task e)
        //{
        //    var task = Tasks.FirstOrDefault(x => x.Task.Id == e.Id);
        //    if (task is not null)
        //    {
        //        task.Text = e.Text;
        //    }
        //}

        private void OnTaskDeleted(object? sender, Models.Task e)
        {
            var task = Tasks.FirstOrDefault(x => x.Task.Id == e.Id);
            if (task is not null)
            {
                Tasks.Remove(task);

                OnPropertyChanged(nameof(QuantityOfCompleted));
            }
        }

        private TaskViewModel CreateTaskVm(Models.Task task)
        {
            return new TaskViewModel(
                    task,
                    _completeCommand);
        }

        private void CompleteTask(TaskViewModel? task)
        {
            if(task is null)
            {
                return;
            }

            _taskService.UpdateCompletion(task.Task, task.IsCompleted);
        }

        [RelayCommand]
        private void EditTask(TaskViewModel? task)
        {
            if(task is null)
            {
                return;
            }

            _navigationService.Navigate<EditTaskViewModel>(task.Task);
        }

        [RelayCommand]
        private void DeleteTask(TaskViewModel? task)
        {
            if(task is null)
            {
                return;
            }

            _taskService.Delete(task.Task);
        }
    }
}
