using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

using ToDoList.Domain.Models;
using ToDoList.Infra.Repositories;
using ToDoList.UI.ViewModels;

namespace ToDoList.UI.Views
{
    /// <summary>
    /// Lógica interna para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TarefaRepository _repository;

        public MainWindow(MainViewModel viewModel, TarefaRepository repository)
        {
            ViewModel = viewModel;
            _repository = repository;

            ViewModel.TarefasCadastradas = _repository.RecuperarTodos();
            DataContext = this;
            InitializeComponent();
        }

        public MainViewModel ViewModel { get; private set; }

        public void AdicionarTarefa(object sender, RoutedEventArgs e)
        {
            ViewModel.MostrarPopupTarefa(new Tarefa());
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            var resultado = MessageBox.Show("Deseja sair?", "Sair", MessageBoxButton.YesNo, MessageBoxImage.Information);

            e.Cancel = resultado == MessageBoxResult.No;
        }

        private void ItemSelecionado_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var tarefaEscolhida = (sender as Border)?.DataContext as Tarefa;

            ViewModel.MostrarPopupTarefa(tarefaEscolhida);
        }

        private void Tarefa_MouseMove(object sender, MouseEventArgs e)
        {
            var popup = GetPopup(sender);

            popup.IsOpen = true;
        }

        private void Tarefa_MouseLeave(object sender, MouseEventArgs e)
        {
            var popup = GetPopup(sender);

            popup.IsOpen = false;
        }

        private Popup GetPopup(object sender)
        {
            var grid = ((sender as Border)?.Child as Grid)?.Children?.OfType<UIElement>();

            return grid.FirstOrDefault(x => x is Popup) as Popup;
        }
    }
}