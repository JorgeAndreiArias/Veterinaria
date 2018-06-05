using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ServiceModel;
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

namespace Veterinaria
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInicio_Click_1(object sender, RoutedEventArgs e)
        {
            ControladorUsuario u = new ControladorUsuario();
            Usuario user = new Usuario();
            user.Username = txtUserName.Text;
            user.Contrasenia = pwtPassword.Password;
            if (user.Username != "" && user.Contrasenia != "")
            {
                Usuario aux = u.autentUser(user);
                if (aux.IdUsuario != 0)
                {
                    index obj = new index();
                    obj.Show();
                    obj.lblNombre.Content = aux.Nombre;
                    obj.lblId.Content = aux.IdUsuario;
                    if (aux.Perfil == "Administrador")
                    {

                    }
                    else if (aux.Perfil == "Medico")
                    {
                        obj.Animales.Visibility = Visibility.Hidden;
                        obj.Animales.Visibility = Visibility.Collapsed;
                        obj.Accesorios.Visibility = Visibility.Hidden;
                        obj.Accesorios.Visibility = Visibility.Collapsed;
                        obj.Ventas.Visibility = Visibility.Hidden;
                        obj.Ventas.Visibility = Visibility.Collapsed;

                    }
                    else if (aux.Perfil == "Ventas")
                    {
                        obj.Servicios.Visibility = Visibility.Hidden;
                        obj.Servicios.Visibility = Visibility.Collapsed;
                        obj.Medicamentos.Visibility = Visibility.Hidden;
                        obj.Medicamentos.Visibility = Visibility.Collapsed;
                        obj.Tratamientos.Visibility = Visibility.Hidden;
                        obj.Tratamientos.Visibility = Visibility.Collapsed;
                    }
                    this.Close();
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("No puedes dejar el campo vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
