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
using Veterinaria.Controlador;
using Veterinaria.Modelo;
using Veterinaria.Vista;

namespace Veterinaria.Vista
{
    /// <summary>
    /// Lógica de interacción para VentaUC.xaml
    /// </summary>
    public partial class VentaUC : UserControl
    {
        public VentaUC()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string i = dtgLista.RowHeight.ToString();
            MessageBox.Show(i);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItem = dtgLista.SelectedItem;
            if (selectedItem != null)
            {
                dtgLista.Items.Remove(selectedItem);
            }
        }

        private void dtgLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ListaAccesorios listaAccesorios = new ListaAccesorios();
            listaAccesorios.Show();
        }
    }
}
