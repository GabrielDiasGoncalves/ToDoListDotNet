using Microsoft.Extensions.DependencyInjection;

using ToDoList.Domain.Services;
using ToDoList.Infra.Repositories;
using ToDoList.UI.Factory;
using ToDoList.UI.ViewModels;
using ToDoList.UI.Views;
using ToDoList.UI.Views.Pages;

namespace ToDoList.UI
{
    public static class Bootstraper
    {
        public static void AdicionarRepositorios(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(new TarefaRepository(connectionString));
        }

        public static void AdicionarJanelas(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
        }

        public static void AdicionarPaginas(this IServiceCollection services)
        {
            services.AddSingleton<PageAdicionarTarefa>();
        }

        public static void AdicionarFactory(this IServiceCollection services)
        {
            services.AddSingleton<MigrationFactory>();
        }

        public static void AdicionarViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<DescricaoTarefaViewModel>();
        }

        public static void AdicionarServicos(this IServiceCollection services)
        {
            services.AddSingleton<MigrationService>();
        }
    }
}