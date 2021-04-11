using System;
using System.ComponentModel;

namespace ToDoList.Domain.Models
{
    public class Tarefa : INotifyPropertyChanged
    {
        private int _id;
        private string _nome;
        private string _descricao;
        private DateTime _dataInicio;
        private DateTime _dataTermino;
        
        public int ID 
        { 
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Nome 
        { 
            get => _nome;
            set
            {
                _nome = value;
                OnPropertyChanged(nameof(Nome));
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public string Descricao 
        { 
            get => _descricao;
            set
            {
                _descricao = value;
                OnPropertyChanged(nameof(Descricao));
                OnPropertyChanged(nameof(IsValid));
            }
        }
        
        public DateTime DataInicio 
        {
            get => _dataInicio;
            set
            {
                _dataInicio = value;
                OnPropertyChanged(nameof(DataInicio));
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public DateTime DataTermino 
        {
            get => _dataTermino;
            set
            {
                _dataTermino = value;
                OnPropertyChanged(nameof(DataTermino));
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public bool IsValid =>
            !string.IsNullOrWhiteSpace(Nome) && 
            !string.IsNullOrWhiteSpace(Descricao) &&
            !(DataTermino < DataInicio);

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomePropriedade) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
    }
}