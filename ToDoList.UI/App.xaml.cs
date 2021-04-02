using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;

using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Services;
using ToDoList.Infra.Migrations;
using ToDoList.Infra.Repositories;
using ToDoList.UI.ViewModels;
using ToDoList.UI.Views;
using ToDoList.UI.Views.Pages;

namespace ToDoList.UI
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            var connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MigrationService>();
            services.AddSingleton<PageAdicionarTarefa>();
            services.AddSingleton<TarefaViewModel>();
            services.AddSingleton(new TarefaRepository(connectionString));
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();

            var migrationService = _serviceProvider.GetService<MigrationService>();

            var connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();

            var migrations = new List<IMigration>()
            {
                new CriarBanco(),
                new CriarTabelaTarefa(connectionString)
            };

            migrationService.ExecutarMigrations(migrations);
        }
    }
}