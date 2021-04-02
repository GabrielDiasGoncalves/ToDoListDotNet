using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using ToDoList.Domain.Models;
using ToDoList.UI.Views.Pages;

namespace ToDoList.UI.ViewModels
{
    public class TarefaViewModel : INotifyPropertyChanged
    {
        private Tarefa _tarefa;
        private PageAdicionarTarefa _pageAddTarefa;
        private Visibility _popUpAdicionarTarefa;
        private Visibility _gridSemTarefaVisibility;
        private Visibility _gridComTarefasVisibility;
        private List<Tarefa> _tarefasCadastradas;

        public TarefaViewModel(PageAdicionarTarefa page)
        {
            Tarefa = new Tarefa();
            PageAddTarefa = page;
            PopUpAdicionarTarefa = Visibility.Collapsed;
            PageAddTarefa.SetViewModel(this);
        }

        public Tarefa Tarefa 
        { 
            get => _tarefa;
            set
            {
                _tarefa = value;
                OnPropertyChanged(nameof(Tarefa));
            }
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

        private void OnPropertyChanged(string nomePropriedade) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
    }
}