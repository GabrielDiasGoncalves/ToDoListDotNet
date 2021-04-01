using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Windows;

using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Services;
using ToDoList.Infra.Migrations;
using ToDoList.UI.Views;

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
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MigrationService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();

            var migrationService = _serviceProvider.GetService<MigrationService>();

            var connectionString = "Data Source=db_todo.db; Version=3;";

            var migrations = new List<IMigration>()
            {
                new CriarBanco(),
                new CriarTabelaTarefa(connectionString)
            };

            migrationService.ExecutarMigrations(migrations);
        }
    }
}