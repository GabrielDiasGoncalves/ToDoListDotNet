using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using ToDoList.Domain.Models;
using ToDoList.Infra.Repositories;
using ToDoList.UI.ViewModels;

namespace ToDoList.UI.Views.Pages
{
    /// <summary>
    /// Interação lógica para PageAdicionarTarefa.xam
    /// </summary>
    public partial class PageAdicionarTarefa : Page
    {
        private readonly TarefaRepository _repository;

        public PageAdicionarTarefa(TarefaRepository repository, DescricaoTarefaViewModel viewModel)
        {
            DataContext = this;
            _repository = repository;
            ViewModel = viewModel;
            InitializeComponent();
        }

        public MainViewModel ViewModelAnterior { get; private set; }
        public DescricaoTarefaViewModel ViewModel { get; private set; }

        public void SetViewModelAnterior(MainViewModel anterior) =>
            ViewModelAnterior = anterior;

        public void SetTarefaParaEdicao(Tarefa tarefa) =>
            ViewModel.TarefaCadastro = tarefa;

        private void Btn_Cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModelAnterior.PopUpAdicionarTarefa = Visibility.Collapsed;
        }

        private void Btn_Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.TarefaCadastro.IsValid)
            {
                MessageBox.Show("Favor fornecer os campos obrigatórios");
                return;
            }

            _repository.AdicionarTarefa(ViewModel.TarefaCadastro);
        }
    }
}