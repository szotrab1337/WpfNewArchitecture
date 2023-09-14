using Microsoft.Extensions.DependencyInjection;
using WpfNewArchitecture.Repositories;
using WpfNewArchitecture.Services;
using WpfNewArchitecture.ViewModels;

namespace WpfNewArchitecture.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddSingleton<ITaskService, TaskService>();
            services.AddSingleton<MainViewModel>();
            services.AddTransient<TasksListViewModel>();
            services.AddTransient<EditTaskViewModel>();
        }
    }
}
