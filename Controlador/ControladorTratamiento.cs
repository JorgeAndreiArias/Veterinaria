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
    class ControladorTratamiento
    {
        public ObservableCollection<Tratamiento> ShowAllTratamientos()
        {
            ObservableCollection<Tratamiento> _list = new ObservableCollection<Tratamiento>();
            Conexion con = new Conexion();
            Tratamiento an = null;
            string sqlCon = "SELECT * FROM Tratamiento WHERE Estatus = 1;";
            SqlCommand cmd = new SqlCommand(sqlCon, con.OpenConn());
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                an = new Tratamiento();
                an.IdTratamiento = read.GetInt32(read.GetOrdinal("IdTratamiento"));
                an.Nombre = read.GetString(read.GetOrdinal("Nombre"));
                an.Precio = read.GetDouble(read.GetOrdinal("Precio"));
                an.Tipo = read.GetString(read.GetOrdinal("Tipo"));
                _list.Add(an);
            }
            con.CloseConn();
            return _list;
        }

        public void InsertSQL(Tratamiento an)
        {
            Conexion con = new Conexion();
            using (SqlCommand cmd = new SqlCommand("sp_AddTratameinto", con.OpenConn()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@nombre", SqlDbType.VarChar);
                param1.Value = an.Nombre;
                SqlParameter param2 = new SqlParameter("@tipo", SqlDbType.VarChar);
                param2.Value = an.Tipo;
                SqlParameter param3 = new SqlParameter("@precio", SqlDbType.Float);
                param3.Value = an.Precio;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);

                cmd.ExecuteNonQuery();
            }
            con.CloseConn();
        }

        public void UpdateSQL(Tratamiento Tratamiento)
        {
            Conexion con = new Conexion();
            SqlCommand comand = new SqlCommand("sp_UpTratamiento", con.OpenConn());
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter param0 = new SqlParameter("@id", SqlDbType.Int);
            param0.Value = Tratamiento.IdTratamiento;
            SqlParameter param1 = new SqlParameter("@nombre", SqlDbType.VarChar);
            param1.Value = Tratamiento.Nombre;
            SqlParameter param2 = new SqlParameter("@tipo", SqlDbType.VarChar);
            param2.Value = Tratamiento.Tipo;
            SqlParameter param3 = new SqlParameter("@precio", SqlDbType.Float);
            param3.Value = Tratamiento.Precio;
            comand.Parameters.Add(param0);
            comand.Parameters.Add(param1);
            comand.Parameters.Add(param2);
            comand.Parameters.Add(param3);
            comand.ExecuteNonQuery();
            con.CloseConn();
        }

        public void DeleteSQL(Tratamiento Tratamiento)
        {
            Conexion con = new Conexion();
            SqlCommand comand = new SqlCommand("sp_DTTratamiento", con.OpenConn());
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter param0 = new SqlParameter("@id", SqlDbType.Int);
            param0.Value = Tratamiento.IdTratamiento;
            comand.Parameters.Add(param0);
            comand.ExecuteNonQuery();
            con.CloseConn();
        }
    }
}
