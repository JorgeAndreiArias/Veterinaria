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
    class ControladorMedicamento
    {
        public ObservableCollection<Medicamentos> ShowAllMedicamentos()
        {
            ObservableCollection<Medicamentos> _list = new ObservableCollection<Medicamentos>();
            Conexion con = new Conexion();
            Medicamentos an = null;
            string sqlCon = "SELECT * FROM Medicamento WHERE Estatus = 1;";
            SqlCommand cmd = new SqlCommand(sqlCon, con.OpenConn());
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                an = new Medicamentos();
                an.IdMedicamento = read.GetInt32(read.GetOrdinal("IdMedicamento"));
                an.Nombre = read.GetString(read.GetOrdinal("Nombre"));
                an.Precio = read.GetDouble(read.GetOrdinal("Precio"));
                an.Categoria = read.GetString(read.GetOrdinal("Categoria"));
                _list.Add(an);
            }
            con.CloseConn();
            return _list;
        }

        public void InsertSQL(Medicamentos an)
        {
            Conexion con = new Conexion();
            using (SqlCommand cmd = new SqlCommand("sp_AddMedicamento", con.OpenConn()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@nombre", SqlDbType.VarChar);
                param1.Value = an.Nombre;
                SqlParameter param2 = new SqlParameter("@cat", SqlDbType.VarChar);
                param2.Value = an.Categoria;
                SqlParameter param3 = new SqlParameter("@precio", SqlDbType.Float);
                param3.Value = an.Precio;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);

                cmd.ExecuteNonQuery();
            }
            con.CloseConn();
        }

        public void UpdateSQL(Medicamentos Medicamento)
        {
            Conexion con = new Conexion();
            SqlCommand comand = new SqlCommand("sp_UpMedicamento", con.OpenConn());
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter param0 = new SqlParameter("@id", SqlDbType.Int);
            param0.Value = Medicamento.IdMedicamento;
            SqlParameter param1 = new SqlParameter("@nombre", SqlDbType.VarChar);
            param1.Value = Medicamento.Nombre;
            SqlParameter param2 = new SqlParameter("@cat", SqlDbType.VarChar);
            param2.Value = Medicamento.Categoria;
            SqlParameter param3 = new SqlParameter("@precio", SqlDbType.Float);
            param3.Value = Medicamento.Precio;
            comand.Parameters.Add(param0);
            comand.Parameters.Add(param1);
            comand.Parameters.Add(param2);
            comand.Parameters.Add(param3);
            comand.ExecuteNonQuery();
            con.CloseConn();
        }

        public void DeleteSQL(Medicamentos Medicamento)
        {
            Conexion con = new Conexion();
            SqlCommand comand = new SqlCommand("sp_DTMedicamento", con.OpenConn());
            comand.CommandType = CommandType.StoredProcedure;
            SqlParameter param0 = new SqlParameter("@id", SqlDbType.Int);
            param0.Value = Medicamento.IdMedicamento;
            comand.Parameters.Add(param0);
            comand.ExecuteNonQuery();
            con.CloseConn();
        }
    }
}
