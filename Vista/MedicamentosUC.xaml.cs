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
    /// Lógica de interacción para MedicamentosUC.xaml
    /// </summary>
    public partial class MedicamentosUC : UserControl
    {
        public MedicamentosUC()
        {
            InitializeComponent();
            CargarTipo();
            Show();
        }

        public void CargarTipo()
        {
            string[] categoria = { "Perros o Gatos", "Aves", "Caballos", "Animales Varios", "Abejas - Colmenas" };
            cmbTipo.ItemsSource = categoria;
        }

        public void Show()
        {
            ControladorMedicamento ac = new ControladorMedicamento();
            dtgLista.ItemsSource = ac.ShowAllMedicamentos();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControladorMedicamento ac = new ControladorMedicamento();
            Medicamentos a = new Medicamentos();
            a.Nombre = txtNombre.Text;
            a.Categoria= cmbTipo.Text;
            a.Precio = Double.Parse(txtPrecio.Text);
            ac.InsertSQL(a);
            Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ControladorMedicamento ca = new ControladorMedicamento();
            Medicamentos a = new Medicamentos();
            a.IdMedicamento = Int32.Parse(txtId.Text);
            ca.DeleteSQL(a);
            Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ControladorMedicamento ca = new ControladorMedicamento();
            Medicamentos a = new Medicamentos();
            a.IdMedicamento = Int32.Parse(txtId.Text);
            a.Nombre = txtNombre.Text;
            a.Categoria = cmbTipo.Text;
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
