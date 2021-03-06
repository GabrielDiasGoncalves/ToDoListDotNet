using Microsoft.Extensions.DependencyInjection;

using System.Configuration;
using System.Windows;

using ToDoList.Domain.Services;
using ToDoList.UI.Factory;
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

        private void ConfigureServices(IServiceCollection services)
        {
            var connectionString = ConfigurationManager.AppSettings["connectionString"];            

            services.AdicionarServicos();
            services.AdicionarFactory();
            
            services.AdicionarViewModels();

            services.AdicionarJanelas();
            services.AdicionarPaginas();

            services.AdicionarRepositorios(connectionString);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();

            var migrationService = _serviceProvider.GetService<MigrationService>();
            var factory = _serviceProvider.GetService<MigrationFactory>();

            var connectionString = ConfigurationManager.AppSettings["connectionString"].ToString();

            var migrations = factory.Criar(connectionString);

            migrationService.ExecutarMigrations(migrations);
        }
    }
}