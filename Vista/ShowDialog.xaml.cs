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
using Veterinaria.Modelo;

namespace Veterinaria.Vista
{
    /// <summary>
    /// Lógica de interacción para ShowDialog1.xaml
    /// </summary>
    public partial class ShowDialog1 : Window
    {
        internal ControladorVenta ventaC { get; set; }
        Venta venta { get; set; }
        internal VentaUC uC { get; set; }
        internal ListaAccesorios ListaAcces { get; set; }
        internal Accesorios _Accesorios { get; set; }

    public ShowDialog1()
        {
            venta = new Venta();
            InitializeComponent();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            venta.Accesory = _Accesorios;
            venta.Cantidad = Int32.Parse(txtNAccesorios.Text);
            uC.List.Add(venta);
            uC.dtgLista.ItemsSource = uC.List;
            double costo = venta.Accesory.Precio * venta.Cantidad;
            uC.GetCostoMas(costo);
            this.Close();
        }

        private void txtBoxEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonTest_Click(this, new EventArgs());
             }
        }


    }
}
