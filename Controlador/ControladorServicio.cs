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
    class ControladorServicio
    {
        public ObservableCollection<Servicios> ShowAllServicios()
        {
            ObservableCollection<Servicios> _list = new ObservableCollection<Servicios>();
            Conexion con = new Conexion();
            Servicios an = null;
            string sqlCon = "SELECT * FROM Servicios WHERE Estatus = 1;";
            SqlCommand cmd = new SqlCommand(sqlCon, con.OpenConn());
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                an = new Servicios();
                an.IdServicio = read.GetInt32(read.GetOrdinal("IdServicio"));
                an.Nombre = read.GetString(read.GetOrdinal("Nombre"));
                an.Precio = read.GetDouble(read.GetOrdinal("Precio"));
                _list.Add(an);
            }
            con.CloseConn();
            return _list;
        }

        public void InsertSQL(Servicios an)
        {
            Conexion con = new Conexion();
            using (SqlCommand cmd = new SqlCommand("sp_AddServicio", con.OpenConn()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@nombre", SqlDbType.VarChar);
                param1.Value = an.Nombre;
                SqlParameter param3 = new SqlParameter("@precio", SqlDbType.Float);
                param3.Value = an.Precio;


                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param3);

                cmd.ExecuteNonQuery();
            }
            con.CloseConn();
        }

        public void UpdateSQL(Servicios Servicio)
        {
            Conexion con = new Conexion();
            SqlCommand comand = new SqlCommand("sp_UpServicio", con.OpenConn());
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter param0 = new SqlParameter("@id", SqlDbType.Int);
            param0.Value = Servicio.IdServicio;
            SqlParameter param1 = new SqlParameter("@nombre", SqlDbType.VarChar);
            param1.Value = Servicio.Nombre;
            SqlParameter param3 = new SqlParameter("@precio", SqlDbType.Float);
            param3.Value = Servicio.Precio;
            comand.Parameters.Add(param0);
            comand.Parameters.Add(param1);
            comand.Parameters.Add(param3);
            comand.ExecuteNonQuery();
            con.CloseConn();
        }

        public void DeleteSQL(Servicios Servicio)
        {
            Conexion con = new Conexion();
            SqlCommand comand = new SqlCommand("sp_DTServicio", con.OpenConn());
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter param0 = new SqlParameter("@id", SqlDbType.Int);
            param0.Value = Servicio.IdServicio;
            comand.Parameters.Add(param0);
            comand.ExecuteNonQuery();
            con.CloseConn();
        }
    }
}
