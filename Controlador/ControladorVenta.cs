using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.ConnDB;
using Veterinaria.Modelo;

namespace Veterinaria.Controlador
{
    class ControladorVenta
    {
        public void InsertSQL(Venta venta, Usuario User, Accesorios acc)
        {
            Conexion con = new Conexion();
            using (SqlCommand cmd = new SqlCommand("sp_AddAccesorio", con.OpenConn()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@idAcc", SqlDbType.Int);
                param1.Value = acc.IdAccesorio;
                SqlParameter param2 = new SqlParameter("@idUs", SqlDbType.Int);
                param2.Value = User.IdUsuario;
                SqlParameter param3 = new SqlParameter("@nCli", SqlDbType.VarChar);
                param3.Value = venta.NombreCliente;
                SqlParameter param4 = new SqlParameter("@cant", SqlDbType.Int);
                param3.Value = venta.Cantidad;
                SqlParameter param5 = new SqlParameter("@precio", SqlDbType.Float);
                param3.Value = venta.Precio;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);

                cmd.ExecuteNonQuery();
            }
            con.CloseConn();
        }

        public ObservableCollection<Accesorios> GetAllDates()
        {
            ObservableCollection<Accesorios> _list = new ObservableCollection<Accesorios>();

            return _list;
        }
    }
}
