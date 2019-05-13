using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;    

namespace CapaDatos
{
  public class CDRegistroUsuarios
    {

        private CDConexion conexion = new CDConexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable MostrarUsuarios()
        {
            
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Mostrarusuarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void InsertarUsuarios(string nombre, string expediente, string tipoUsuario, string contraseña)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre",nombre);
            comando.Parameters.AddWithValue("@expediente",expediente);
            comando.Parameters.AddWithValue("@tipoUsuario",tipoUsuario);
            comando.Parameters.AddWithValue("@contraseña",contraseña);
            comando.ExecuteNonQuery();
        }

        public void ModificarUsuarios(string nombre, string expediente, string tipoUsuario, string contraseña , int id)
        {

            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();            
            comando.CommandText = "ModificarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@expediente", expediente);
            comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
            comando.Parameters.AddWithValue("@contraseña", contraseña);
            comando.Parameters.AddWithValue("@idUsuario", id);
            comando.ExecuteNonQuery();
        }

        public void EliminarUsuario(int idUsuario)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SPEliminarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", idUsuario);
            comando.ExecuteNonQuery();       
        }
    }
}
