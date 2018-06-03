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
    class ControladorAnimal
    {
        public ObservableCollection<Animal> ShowAllAnimals()
        {
            ObservableCollection<Animal> _list = new ObservableCollection<Animal>();
            Conexion con = new Conexion();
            Animal an = null;
            string sqlCon = "SELECT * FROM Animal WHERE Estatus = 1;";
            SqlCommand cmd = new SqlCommand(sqlCon, con.OpenConn());
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                an = new Animal();
                an.IdAnimal = read.GetInt32(read.GetOrdinal("Id"));
                an.Nombre = read.GetString(read.GetOrdinal("Nombre"));
                an.Precio = read.GetDouble(read.GetOrdinal("Precio"));
                an.Tipo = read.GetString(read.GetOrdinal("Tipo"));
                _list.Add(an);
            }
            con.CloseConn();
            return _list;
        }

        public void InsertSQL(Animal an)
        {
            Conexion con = new Conexion();
            using (SqlCommand cmd = new SqlCommand("sp_agregar", con.OpenConn()))
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

        public void UpdateSQL(Animal animal)
        {
            Conexion con = new Conexion();
            SqlCommand comand = new SqlCommand("sp_UpAnimal", con.OpenConn());
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter param0 = new SqlParameter("@id", SqlDbType.Int);
            param0.Value = animal.IdAnimal;
            SqlParameter param1 = new SqlParameter("@nombre", SqlDbType.VarChar);
            param1.Value = animal.Nombre;
            SqlParameter param2 = new SqlParameter("@tipo", SqlDbType.VarChar);
            param2.Value = animal.Tipo;
            SqlParameter param3 = new SqlParameter("@precio", SqlDbType.Float);
            param3.Value = animal.Precio;
            comand.Parameters.Add(param0);
            comand.Parameters.Add(param1);
            comand.Parameters.Add(param2);
            comand.Parameters.Add(param3);
            comand.ExecuteNonQuery();
            con.CloseConn();
        }
        
        public void DeleteSQL(Animal animal)
        {
            Conexion con = new Conexion();
            SqlCommand comand = new SqlCommand("sp_DTAnimal", con.OpenConn());
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter param0 = new SqlParameter("@id", SqlDbType.Int);
            param0.Value = animal.IdAnimal;
            comand.Parameters.Add(param0);
            comand.ExecuteNonQuery();
            con.CloseConn();
        }
    }
}
