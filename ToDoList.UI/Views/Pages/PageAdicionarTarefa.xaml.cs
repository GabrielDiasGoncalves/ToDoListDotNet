using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoList.UI.ViewModels;

namespace ToDoList.UI.Views.Pages
{
    /// <summary>
    /// Interação lógica para PageAdicionarTarefa.xam
    /// </summary>
    public partial class PageAdicionarTarefa : Page
    {
        public PageAdicionarTarefa()
        {
            DataContext = this;
            InitializeComponent();
        }

        public TarefaViewModel ViewModel { get; private set; }

        public void SetViewModel(TarefaViewModel viewModel)
        {
            if (viewModel == null) return;

            ViewModel = viewModel;
        }

        private void Btn_Cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel.PopUpAdicionarTarefa = Visibility.Collapsed;
        }

        private void Btn_Cadastrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
