using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoList.Domain.Models;

namespace ToDoList.UI.ViewModels
{
    public class DescricaoTarefaViewModel : INotifyPropertyChanged
    {
        private Tarefa _tarefaCadastro;

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomePropriedade) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
    }
}
