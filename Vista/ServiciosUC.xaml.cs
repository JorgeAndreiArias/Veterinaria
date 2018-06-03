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

namespace Veterinaria.Vista
{
    /// <summary>
    /// Lógica de interacción para ServiciosUC.xaml
    /// </summary>
    public partial class ServiciosUC : UserControl
    {
        public ServiciosUC()
        {
            InitializeComponent();
            Show();
        }

        public void Show()
        {
            ControladorServicio ac = new ControladorServicio();
            dtgLista.ItemsSource = ac.ShowAllServicios();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControladorServicio ca = new ControladorServicio();
            Servicios a = new Servicios();
            a.Nombre = txtNombre.Text;
            a.Precio = Double.Parse(txtPrecio.Text);
            ca.InsertSQL(a);
            Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ControladorServicio ca = new ControladorServicio();
            Servicios a = new Servicios();
            a.IdServicio = Int32.Parse(txtId.Text);
            ca.DeleteSQL(a);
            Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ControladorServicio ca = new ControladorServicio();
            Servicios a = new Servicios();
            a.IdServicio = Int32.Parse(txtId.Text);
            a.Nombre = txtNombre.Text;
            a.Precio = Double.Parse(txtPrecio.Text);
            ca.UpdateSQL(a);
            Show();
        }

        private void dtgLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                object item = dtgLista.SelectedItem;
                txtNombre.Text = (dtgLista.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                txtPrecio.Text = (dtgLista.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                txtId.Text = (dtgLista.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch
            {

            }
        }
    }
}
