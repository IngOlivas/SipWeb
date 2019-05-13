using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDatos
{
   public class CDRegistroPrestamoDevolucion
    {

        private CDConexion conexion = new CDConexion();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();
        string parametros;
        public DataSet D;

        public void InsertarPrestamo(int idUsuario, string fechaInicio,string fechaEntrega, string estado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarPrestamo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idUsuario", idUsuario);
            comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            comando.Parameters.AddWithValue("@fechaEntrega", fechaEntrega);
            comando.Parameters.AddWithValue("@estado", estado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void ModificarEstadoPrestamo(int idEquipo,int idPrestamo)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarEstadoPrestamo";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idEquipo", idEquipo);
            comando.Parameters.AddWithValue("@idPrestamo",idPrestamo);
            comando.ExecuteNonQuery();
        
        }
        
        public void ModificarEquipoDevolucion(int idEquipo, string ubicacionBien, string estado)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarEquipoDevolucion";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idEquipo",idEquipo);
            comando.Parameters.AddWithValue("@ubicacionBien",ubicacionBien);
            comando.Parameters.AddWithValue("@estado",estado);
            comando.ExecuteNonQuery();
        }

        public void ModificarFechaEntregaDevolucion(int idPrestamo, string nuevaFecha)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarFechaEntregaDevolucion";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);
            comando.Parameters.AddWithValue("@nuevaFecha",nuevaFecha);
            comando.ExecuteNonQuery();

        }
      
        public DataTable ListarEquipoParaPrestamos()
        {
            DataTable Tabla = new DataTable();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ListarEquipoParaPrestamos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            Tabla.Load(leer);
            conexion.CerrarConexion();
            
            return Tabla;
        }

        public DataTable ListarPrestamos()
        {
            DataTable Tabla = new DataTable();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ListarPrestamos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            Tabla.Load(leer);
            conexion.CerrarConexion();

            return Tabla;
        }

        public DataTable BuscarEquipoPorParametros(string parametro, string tipoBusqueda)
        {
            parametros = parametro;

            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Clear();
            comando.CommandText = tipoBusqueda;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@parametro", parametro);

            SqlDataAdapter DA = new SqlDataAdapter(comando);
            D = new DataSet();
            DA.Fill(D, "EquipoElectronico");
            comando.Connection = conexion.CerrarConexion();
            return D.Tables["EquipoElectronico"];
        }

        public DataTable BuscarIdPrestamoDevolucion(int idPrestamo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Clear();
            comando.CommandText = "ListarDatosParaDevolucion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);

        
            SqlDataAdapter DA = new SqlDataAdapter(comando);
            D = new DataSet();
            DA.Fill(D, "DetallePrestamo");
            comando.Connection = conexion.CerrarConexion();
            return D.Tables["DetallePrestamo"];

        }

        public DataTable VerEquiposParaDevolucion(int idPrestamo)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Clear();
            comando.CommandText = "VerEquiposParaDevolucion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);


            SqlDataAdapter DA = new SqlDataAdapter(comando);
            D = new DataSet();
            DA.Fill(D, "DetallePrestamo");
            comando.Connection = conexion.CerrarConexion();
            return D.Tables["DetallePrestamo"];
        }

           }
}
