using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Veterinaria.ConnDB;
using Veterinaria.Modelo;

namespace Veterinaria.Controlador
{
    class ControladorUsuario
    {
        public Usuario autentUser(Usuario _user)
        {
            Conexion conn = new Conexion();
            Usuario an = null;
            string sqlCadena = "sp_autenticar";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlCadena, conn.OpenConn());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", System.Data.SqlDbType.VarChar).Value = _user.Username;
                cmd.Parameters.AddWithValue("@contrasenia", System.Data.SqlDbType.VarChar).Value = _user.Contrasenia;
                cmd.ExecuteNonQuery();
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    an = new Usuario();
                    an.IdUsuario = read.GetInt32(read.GetOrdinal("IdUsuario"));
                    an.Nombre = read.GetString(read.GetOrdinal("Nombre"));
                    an.Perfil = read.GetString(read.GetOrdinal("Perfil"));
                    an.Contrasenia = read.GetString(read.GetOrdinal("contrasenia"));
                    an.Username = read.GetString(read.GetOrdinal("username"));
                }
                else
                {
                    an = new Usuario();
                    an.IdUsuario = 0;
                    MessageBox.Show("Contraseña o Nombre de Usuario Invalida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                conn.CloseConn();
                return an;
            }catch(SqlException SqlEx)
            {
                string MensajeError = "ERROR : " + SqlEx.Message + ". " + "LINEA : " + SqlEx.LineNumber + ".";
                throw new Exception(MensajeError, SqlEx);
            }
        }
    }
}
