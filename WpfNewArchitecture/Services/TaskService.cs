using WpfNewArchitecture.Repositories;

namespace WpfNewArchitecture.Services
{
    public interface ITaskService
    {
        event EventHandler<Models.Task>? TaskCompletionChanged;
        event EventHandler<Models.Task>? TaskDeleted;

        void Delete(Models.Task task);
        List<Models.Task> GetTasks();
        void UpdateCompletion(Models.Task task, bool isCompleted);
        void UpdateText(Models.Task task, string text);
    }

    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public event EventHandler<Models.Task>? TaskCompletionChanged;
        public event EventHandler<Models.Task>? TaskDeleted;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<Models.Task> GetTasks()
        {
            return _taskRepository.GetTasks();
        }

        public void UpdateCompletion(Models.Task task, bool isCompleted)
        {
            task.IsCompleted = isCompleted;

            _taskRepository.UpdateTask(task);
            TaskCompletionChanged?.Invoke(this, task);
        }

        public void UpdateText(Models.Task task, string text)
        {
            task.Text = text;

            _taskRepository.UpdateTask(task);
        }

        public void Delete(Models.Task task)
        {
            _taskRepository.Delete(task);

            TaskDeleted?.Invoke(this, task);
        }
    }
}
