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
    class ControladorAccesorio
    {
        public ObservableCollection<Accesorios> ShowAllAccesorios()
        {
            ObservableCollection<Accesorios> _list = new ObservableCollection<Accesorios>();
            Conexion con = new Conexion();
            Accesorios an = null;
            string sqlCon = "SELECT * FROM Accesorio WHERE Estatus = 1;";
            SqlCommand cmd = new SqlCommand(sqlCon, con.OpenConn());
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                an = new Accesorios();
                an.IdAccesorio = read.GetInt32(read.GetOrdinal("IdAccesorio"));
                an.Nombre = read.GetString(read.GetOrdinal("Nombre"));
                an.Precio = read.GetDouble(read.GetOrdinal("Precio"));
                an.Clasificacion = read.GetString(read.GetOrdinal("Clasificacion"));
                _list.Add(an);
            }
            con.CloseConn();
            return _list;
        }

        public void InsertSQL(Accesorios an)
        {
            Conexion con = new Conexion();
            using (SqlCommand cmd = new SqlCommand("sp_AddAccesorio", con.OpenConn()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@nombre", SqlDbType.VarChar);
                param1.Value = an.Nombre;
                SqlParameter param2 = new SqlParameter("@clas", SqlDbType.VarChar);
                param2.Value = an.Clasificacion;
                SqlParameter param3 = new SqlParameter("@precio", SqlDbType.Float);
                param3.Value = an.Precio;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);

                cmd.ExecuteNonQuery();
            }
            con.CloseConn();
        }

        public void UpdateSQL(Accesorios Accesorio)
        {
            Conexion con = new Conexion();
            SqlCommand comand = new SqlCommand("sp_UpAccesorio", con.OpenConn());
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter param0 = new SqlParameter("@id", SqlDbType.Int);
            param0.Value = Accesorio.IdAccesorio;
            SqlParameter param1 = new SqlParameter("@nombre", SqlDbType.VarChar);
            param1.Value = Accesorio.Nombre;
            SqlParameter param2 = new SqlParameter("@clas", SqlDbType.VarChar);
            param2.Value = Accesorio.Clasificacion;
            SqlParameter param3 = new SqlParameter("@precio", SqlDbType.Float);
            param3.Value = Accesorio.Precio;
            comand.Parameters.Add(param0);
            comand.Parameters.Add(param1);
            comand.Parameters.Add(param2);
            comand.Parameters.Add(param3);
            comand.ExecuteNonQuery();
            con.CloseConn();
        }

        public void DeleteSQL(Accesorios Accesorio)
        {
            Conexion con = new Conexion();
            SqlCommand comand = new SqlCommand("sp_DTAccesorio", con.OpenConn());
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter param0 = new SqlParameter("@id", SqlDbType.Int);
            param0.Value = Accesorio.IdAccesorio;
            comand.Parameters.Add(param0);
            comand.ExecuteNonQuery();
            con.CloseConn();
        }
    }
}
