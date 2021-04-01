﻿using System;
using System.ComponentModel;

namespace ToDoList.Domain.Models
{
    public class Tarefa : INotifyPropertyChanged
    {
        private int _id;
        private string _nome;
        private string _descricao;

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
            }
        }

        public string Descricao 
        { 
            get => _descricao;
            set
            {
                _descricao = value;
                OnPropertyChanged(nameof(Descricao));
            }
        }
        
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomePropriedade)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }
    }
}