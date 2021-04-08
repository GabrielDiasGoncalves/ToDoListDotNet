using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
    }
}