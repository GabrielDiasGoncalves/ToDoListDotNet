using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

using ToDoList.Domain.Models;
using ToDoList.UI.Enums;
using ToDoList.UI.Views.Pages;

namespace ToDoList.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PageAdicionarTarefa _pageAddTarefa;
        private Visibility _popUpAdicionarTarefa;
        private Visibility _gridSemTarefaVisibility;
        private Visibility _gridComTarefasVisibility;
        private List<Tarefa> _tarefasCadastradas;

        public MainViewModel(PageAdicionarTarefa page)
        {
            PageAddTarefa = page;
            PageAddTarefa.SetViewModelAnterior(this);
            PopUpAdicionarTarefa = Visibility.Collapsed;
        }

        public PageAdicionarTarefa PageAddTarefa 
        {
            get => _pageAddTarefa;
            set
            {
                _pageAddTarefa = value;
                OnPropertyChanged(nameof(PageAddTarefa));
            }
        }

        public Visibility PopUpAdicionarTarefa 
        { 
            get => _popUpAdicionarTarefa;
            set
            {
                _popUpAdicionarTarefa = value;
                OnPropertyChanged(nameof(PopUpAdicionarTarefa));
            }
        }

        public Visibility GridSemTarefaVisibility 
        { 
            get => _gridSemTarefaVisibility;
            set
            {
                _gridSemTarefaVisibility = value;
                OnPropertyChanged(nameof(GridSemTarefaVisibility));
            }
        }

        public Visibility GridComTarefasVisibility 
        {
            get => _gridComTarefasVisibility;
            set 
            {
                _gridComTarefasVisibility = value;
                OnPropertyChanged(nameof(GridComTarefasVisibility));
            }
        }

        public List<Tarefa> TarefasCadastradas 
        { 
            get => _tarefasCadastradas;
            set 
            {
                if (value == null || value?.Count == 0)
                {
                    GridSemTarefaVisibility = Visibility.Visible;
                    GridComTarefasVisibility = Visibility.Collapsed;
                }
                else
                {
                    GridSemTarefaVisibility = Visibility.Collapsed;
                    GridComTarefasVisibility = Visibility.Visible;
                }

                _tarefasCadastradas = value;

                OnPropertyChanged(nameof(TarefasCadastradas));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void MostrarPopupTarefa(Tarefa tarefa)
        {
            PopUpAdicionarTarefa = Visibility.Visible;
            PageAddTarefa.SetTarefaParaEdicao(tarefa);
            PageAddTarefa.ViewModel.TiposOperacao = string.IsNullOrWhiteSpace(tarefa.Nome) ?
                TiposOperacaoPage.Cadastro : TiposOperacaoPage.Atualizar;
        }

        private void OnPropertyChanged(string nomePropriedade) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
    }
}