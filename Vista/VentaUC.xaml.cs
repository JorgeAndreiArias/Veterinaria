using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        internal ObservableCollection<Venta> List = new ObservableCollection<Venta>();
        internal index index { get; set; }
        internal ControladorVenta controlador { get; set; }
        internal Usuario usuario { get; set; }
        internal Double Cost = 0;
        internal int idU;

        public VentaUC()
        {
            controlador = new ControladorVenta();
            InitializeComponent();
            LimpiarTodo();
        }

        public VentaUC(int id)
        {
            this.idU = id;
            controlador = new ControladorVenta();
            InitializeComponent();
            LimpiarTodo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult;
            dialogResult = MessageBox.Show("Esta seguro que desea realizar la venta?", "Yu Chure?",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (dialogResult == MessageBoxResult.Yes)
            {
                usuario = new Usuario();
                List[0].NombreCliente = txtNombreCliente.Text;
                usuario.IdUsuario = idU;
                if (controlador.insertarVenta(List, usuario))
                {
                    MessageBox.Show("Venta Realizada", "Transacción Realizada", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarTodo();
                }
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int i = List.Count;
            int index = dtgLista.SelectedIndex;
            for (int j = 0; j < i; j++)
            {
                if (j == index)
                {
                    double cos = List[index].Cantidad * List[index].Accesory.Precio;
                    List.RemoveAt(index);
                    GetCostoMenos(cos);
                }
            }
            
        }

        private void dtgLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ListaAccesorios listaAccesorios = new ListaAccesorios();
            listaAccesorios.controladorVenta = this.controlador;
            listaAccesorios.ventaUC = this;
            listaAccesorios.Show();
        }

        public void GetCostoMas(double Costo)
        {
            Cost = Costo + Cost; 
            txtTotalNeto.Text = Cost.ToString();
        }

        public void GetCostoMenos(double Costo)
        {
            Cost = Double.Parse(txtTotalNeto.Text) - Costo;
            txtTotalNeto.Text = Cost.ToString();
        }

        public void LimpiarTodo()
        {
            lblDate.Content = string.Format("{0:dd/MM/yyyy}", DateTime.Now); // 09 30 2013
            ControladorVenta CV = new ControladorVenta();
            lblCodigo.Content = CV.ShowIdVenta();
            txtTotalNeto.Clear();
            txtNombreCliente.Clear();
            List.Clear();
        }

    }
}
