using System;
using System.ComponentModel;
using System.Drawing;

namespace ToDoList.Domain.Models
{
    public class Tarefa : INotifyPropertyChanged
    {
        private int _id;
        private string _nome;
        private string _descricao;
        private DateTime _dataInicio;
        private DateTime _dataTermino;

        // separar em um enum
        private Color _corAhPrazo = Color.Blue;
        private Color _corDiaFinal = Color.Green;
        private Color _corAtrasado = Color.Red;

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
                OnPropertyChanged(nameof(DescricaoAbreviada));
            }
        }

        public string DescricaoAbreviada
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Descricao))
                    return string.Empty;

                return Descricao.Length >= 19 ? Descricao.Substring(0, 19) + "..." : Descricao;
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
                OnPropertyChanged(nameof(CorStatus));
                OnPropertyChanged(nameof(MensagemStatus));
            }
        }

        public Color CorStatus
        {
            get
            {
                var hoje = DateTime.Now.Date;

                return hoje <= DataTermino.Date ? _corAhPrazo :
                    hoje == DataTermino.Date ? _corDiaFinal : _corAtrasado;
            }
        }

        public string MensagemStatus =>
            CorStatus == Color.Blue ? "Tarefa está no prazo" :
            CorStatus == Color.Green ? "Data de entrega da tarefa" : "Tarefa atrasada";

        public bool IsValid =>
            !string.IsNullOrWhiteSpace(Nome) && 
            !string.IsNullOrWhiteSpace(Descricao) &&
            !(DataTermino < DataInicio);

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomePropriedade) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
    }
}