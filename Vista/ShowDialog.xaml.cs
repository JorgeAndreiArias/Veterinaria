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
using Veterinaria.Modelo;

namespace Veterinaria.Vista
{
    /// <summary>
    /// Lógica de interacción para ShowDialog1.xaml
    /// </summary>
    public partial class ShowDialog1 : Window
    {
        public ShowDialog1()
        {
            InitializeComponent();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            venta.Cantidad = Int32.Parse(txtNAccesorios.Text);

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
