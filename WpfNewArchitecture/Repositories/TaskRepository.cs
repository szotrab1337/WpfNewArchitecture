namespace WpfNewArchitecture.Repositories
{
    public interface ITaskRepository
    {
        void Delete(Models.Task task);
        List<Models.Task> GetTasks();
        void UpdateTask(Models.Task task);
    }

    public class TaskRepository : ITaskRepository
    {
        private readonly List<Models.Task> _tasks;

        public TaskRepository()
        {
            _tasks = new List<Models.Task>
            {
                new Models.Task
                {
                    Id = 1,
                    Text = "Zadanie 1"
                },
                new Models.Task
                {
                    Id = 2,
                    Text = "Zadanie 2"
                },
                new Models.Task
                {
                    Id = 3,
                    Text = "Zadanie 3"
                }
            };
        }

        public List<Models.Task> GetTasks()
        {
            return _tasks;
        }

        //logika update w bazie danych
        public void UpdateTask(Models.Task task)
        {
            var oldTask = _tasks.Find(x => x.Id == task.Id);

            if (oldTask is null)
            {
                return;
            }

            oldTask.Text = task.Text;
            oldTask.IsCompleted = task.IsCompleted;
        }

        public void Delete(Models.Task task)
        {
            var taskToDelete = _tasks.Find(x => x.Id == task.Id);

            if (taskToDelete is null)
            {
                return;
            }

            _tasks.Remove(taskToDelete);
        }
    }
}
