using System.ComponentModel;
using System.Windows;

using ToDoList.Domain.Models;
using ToDoList.UI.Enums;

namespace ToDoList.UI.ViewModels
{
    public class DescricaoTarefaViewModel : INotifyPropertyChanged
    {
        private Tarefa _tarefaCadastro;
        private string _tituloPage;
        private TiposOperacaoPage _tiposOperacao;
        private Visibility _botaoCadastroVisibility;
        private Visibility _botaoAlterarVisibility;

        public DescricaoTarefaViewModel()
        {
            TarefaCadastro = new Tarefa();
        }

        public Tarefa TarefaCadastro 
        {
            get => _tarefaCadastro;
            set
            {
                _tarefaCadastro = value;
                OnPropertyChanged(nameof(TarefaCadastro));
            }
        }

        public string TituloPage 
        { 
            get => _tituloPage;
            private set 
            {
                _tituloPage = value;
                OnPropertyChanged(nameof(TituloPage));
            }
        }

        public TiposOperacaoPage TiposOperacao 
        { 
            get => _tiposOperacao;
            set
            {
                _tiposOperacao = value;

                var ehCadastro = _tiposOperacao == TiposOperacaoPage.Cadastro;

                TituloPage = ehCadastro ? "Adicionar Tarefa" : "Atualizar Tarefa";
                
                BotaoCadastroVisibility = ehCadastro ?
                    Visibility.Visible : Visibility.Collapsed;

                BotaoAlterarVisibility = !ehCadastro ?
                    Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility BotaoCadastroVisibility 
        { 
            get => _botaoCadastroVisibility;
            private set
            {
                _botaoCadastroVisibility = value;
                OnPropertyChanged(nameof(BotaoCadastroVisibility));
            }
        }

        public Visibility BotaoAlterarVisibility 
        { 
            get => _botaoAlterarVisibility;
            private set
            {
                _botaoAlterarVisibility = value;
                OnPropertyChanged(nameof(BotaoAlterarVisibility));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomePropriedade) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
    }
}