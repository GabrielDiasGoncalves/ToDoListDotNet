using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Models;

namespace ToDoList.UI.ViewModels
{
    public class TarefaViewModel : INotifyPropertyChanged
    {
        private Tarefa _tarefa;

        public TarefaViewModel()
        {
            Tarefa = new Tarefa();
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomePropriedade)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }
    }
}