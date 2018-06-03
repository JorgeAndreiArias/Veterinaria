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
    /// Lógica de interacción para AccesoriosUC.xaml
    /// </summary>
    public partial class AccesoriosUC : UserControl
    {
        public AccesoriosUC()
        {
            InitializeComponent();
            CargarTipo();
            Show();
        }

        public void CargarTipo()
        {
            string[] categoria = { "Juguetes y Gadgets", "Camas y Casas", "Ropa", "Higiene y Salud" };
            cmbTipo.ItemsSource = categoria;
        }

        public void Show() {
            ControladorAccesorio a = new ControladorAccesorio();
            dtgLista.ItemsSource = a.ShowAllAccesorios();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControladorAccesorio ca = new ControladorAccesorio();
            Accesorios a = new Accesorios();
            a.Nombre = txtNombre.Text;
            a.Clasificacion = cmbTipo.Text;
            a.Precio = Double.Parse(txtPrecio.Text);
            ca.InsertSQL(a);
            Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ControladorAccesorio ca = new ControladorAccesorio();
            Accesorios a = new Accesorios();
            a.IdAccesorio = Int32.Parse(txtId.Text);
            ca.DeleteSQL(a);
            Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            ControladorAccesorio ca = new ControladorAccesorio();
            Accesorios a = new Accesorios();
            a.IdAccesorio = Int32.Parse(txtId.Text);
            a.Nombre = txtNombre.Text;
            a.Clasificacion = cmbTipo.Text;
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
                cmbTipo.Text = (dtgLista.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                txtPrecio.Text = (dtgLista.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                txtId.Text = (dtgLista.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch
            {

            }
        }
    }
}
