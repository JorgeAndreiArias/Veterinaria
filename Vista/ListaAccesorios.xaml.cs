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
    /// Lógica de interacción para ListaAccesorios.xaml
    /// </summary>
    public partial class ListaAccesorios : Window
    {
        public ShowDialog1 showDialog1 { get; set; }
        internal VentaUC ventaUC { get; set; }
        internal ControladorVenta controladorVenta { get; set; }

        public ListaAccesorios()
        {
            showDialog1 = new ShowDialog1();
            InitializeComponent();
            Shown(); 
        }

        public void Shown()
        {
            ControladorAccesorio a = new ControladorAccesorio();
            dtgLista1.ItemsSource = a.ShowAllAccesorios();
        }

        private void dtgLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try
            {
                Accesorios an = new Accesorios();
                if (dtgLista1.SelectedItems != null)
                {
                    an = (Accesorios)dtgLista1.SelectedItem;
                    showDialog1.ventaC = this.controladorVenta;
                    showDialog1.uC = this.ventaUC;
                    showDialog1._Accesorios = an;
                    showDialog1.Show();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }            
        }
    }
}
