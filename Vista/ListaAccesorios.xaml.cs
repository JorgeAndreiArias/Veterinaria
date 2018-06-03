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
using System.Windows.Shapes;
using Veterinaria.Controlador;

namespace Veterinaria.Vista
{
    /// <summary>
    /// Lógica de interacción para ListaAccesorios.xaml
    /// </summary>
    public partial class ListaAccesorios : Window
    {
        public ListaAccesorios()
        {
            InitializeComponent();
            Shown();
        }

        public void Shown()
        {
            ControladorAccesorio a = new ControladorAccesorio();
            dtgLista.ItemsSource = a.ShowAllAccesorios();
        }

        private void dtgLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                object item = dtgLista.SelectedItem;
                string Nombre = (dtgLista.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                string Categoria = (dtgLista.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string Precio = (dtgLista.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                string Id = (dtgLista.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch
            {

            }

            ShowDialog1 s = new ShowDialog1();
            s.Show();
        }
    }
}
