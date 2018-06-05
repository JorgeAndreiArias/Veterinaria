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
        public bool insertarVenta(ObservableCollection<Venta> Lista, Usuario usuario)
        {
            Conexion conn = new Conexion();
            var dt = new DataTable();
            dt.Columns.Add("IdAccesorio", typeof(Int32));
            dt.Columns.Add("Precio", typeof(float));
            dt.Columns.Add("Cantidad", typeof(Int32));
            //DataRow dc = dt.NewRow();

            for (int i = 0; i < Lista.Count; i++)
            {
                DataRow dc = dt.NewRow();
                dc[0] = Lista[i].Accesory.IdAccesorio;
                dc[1] = Lista[i].Accesory.Precio;
                dc[2] = Lista[i].Cantidad;
                dt.Rows.Add(dc);
            }
            SqlCommand cmd = new SqlCommand("sp_InsertVentayVentaDetalle", conn.OpenConn());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            var param1 = cmd.Parameters.AddWithValue("@idUs", usuario.IdUsuario);
            var param2 = cmd.Parameters.AddWithValue("@nCli", Lista[0].NombreCliente);
            var param3 = cmd.Parameters.AddWithValue("@TVD", dt);
            param3.SqlDbType = SqlDbType.Structured;
            param3.TypeName = "dbo.TypeVentaDet";

            cmd.ExecuteNonQuery();
            conn.CloseConn();

            return true;

        }

        public int ShowIdVenta()
        {
            Conexion con = new Conexion();
            Venta an = null;
            int IdVenta = 0;
            string sqlCon = "SELECT MAX(IdVenta) AS IdVenta FROM Venta";
            SqlCommand cmd = new SqlCommand(sqlCon, con.OpenConn());
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                try
                {
                IdVenta = read.GetInt32(read.GetOrdinal("IdVenta"));
                }
                catch (Exception ex)
                {
                    IdVenta = 0;
                }     
            }
            con.CloseConn();
            return IdVenta + 1;
        }
    }
}
