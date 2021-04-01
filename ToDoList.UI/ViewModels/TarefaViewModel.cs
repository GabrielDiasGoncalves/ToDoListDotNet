using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using ToDoList.Domain.Models;
using ToDoList.UI.Views.Pages;

namespace ToDoList.UI.ViewModels
{
    public class TarefaViewModel : INotifyPropertyChanged
    {
        private Tarefa _tarefa;
        private Page _pageAddTarefa;

        public TarefaViewModel(PageAdicionarTarefa page)
        {
            Tarefa = new Tarefa();
            _pageAddTarefa = page;
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

        public Page PageAddTarefa 
        {
            get => _pageAddTarefa;
            set
            {
                _pageAddTarefa = value;
                OnPropertyChanged(nameof(PageAddTarefa));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomePropriedade)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }
    }
}