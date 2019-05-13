using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDUsuario
    {
        private CDConexion conexion = new CDConexion();
        private SqlDataReader leer;

        public SqlDataReader IniciarSesion(string expediente, string contraseña)
        {
            
            SqlCommand comando = new SqlCommand("SPIniciarSesion",conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Usuario",expediente);
            comando.Parameters.AddWithValue("@Contraseña",contraseña);
            leer = comando.ExecuteReader();
            return leer;

        }
    }
}