using System;
using System.Collections.Generic;
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
using ToDoList.Infra.Repositories;
using ToDoList.UI.ViewModels;
using ToDoList.UI.Views.Pages;

namespace ToDoList.UI.Views
{
    /// <summary>
    /// Lógica interna para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TarefaRepository _repository;

        public MainWindow(TarefaViewModel viewModel, TarefaRepository repository)
        {
            ViewModel = viewModel;
            _repository = repository;
            DataContext = this;
            InitializeComponent();
        }

        public TarefaViewModel ViewModel { get; private set; }

        public void AdicionarTarefa(object sender, RoutedEventArgs e)
        {
            ViewModel.PopUpAdicionarTarefa = Visibility.Visible;
        }
    }
}
