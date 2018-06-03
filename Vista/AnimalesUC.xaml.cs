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
    /// Lógica de interacción para AnimalesUC.xaml
    /// </summary>
    public partial class AnimalesUC : UserControl
    {
        public AnimalesUC()
        {
            InitializeComponent();
            CargarTipo();
            CargarAnimales();
        }
        public void CargarTipo()
        {
            string[] categoria = { "Felino", "Canino", "Roedor", "Ave" };
            cmbTipo.ItemsSource = categoria;
        }

        public void CargarAnimales()
        {
            ControladorAnimal _ca = new ControladorAnimal();
            dtgLista.ItemsSource = _ca.ShowAllAnimals();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControladorAnimal ca = new ControladorAnimal();
            Animal a = new Animal();
            a.Nombre = txtNombre.Text;
            a.Tipo = cmbTipo.Text;
            a.Precio = Double.Parse(txtPrecio.Text);
            ca.InsertSQL(a);
            CargarAnimales();
            Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ControladorAnimal ca = new ControladorAnimal();
            Animal a = new Animal();
            a.IdAnimal = Int32.Parse(txtId.Text);
            a.Nombre = txtNombre.Text;
            a.Tipo = cmbTipo.Text;
            a.Precio = Double.Parse(txtPrecio.Text);
            ca.UpdateSQL(a);
            CargarAnimales();
            Clear();
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

        public void Clear() {
            txtId.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            cmbTipo.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ControladorAnimal ca = new ControladorAnimal();
            Animal a = new Animal();
            a.IdAnimal = Int32.Parse(txtId.Text);
            ca.DeleteSQL(a);
            CargarAnimales();
            Clear();
        }
    }
}
