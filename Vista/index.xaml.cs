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
    /// Lógica de interacción para index.xaml
    /// </summary>
    public partial class index : Window
    {
        internal Usuario usuario = new Usuario();
        public index()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControllerUC cu = new ControllerUC();
            cu.CargarUC(grdUC, new AnimalesUC());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ControllerUC cu = new ControllerUC();
            cu.CargarUC(grdUC, new AccesoriosUC());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ControllerUC cu = new ControllerUC();
            cu.CargarUC(grdUC, new TratamientoUC());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ControllerUC cu = new ControllerUC();
            cu.CargarUC(grdUC, new ServiciosUC());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ControllerUC cu = new ControllerUC();
            cu.CargarUC(grdUC, new MedicamentosUC());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ControllerUC cu = new ControllerUC();
            cu.CargarUC(grdUC, new VentaUC(Int32.Parse(lblId.Content.ToString())));
        }
    }
}
