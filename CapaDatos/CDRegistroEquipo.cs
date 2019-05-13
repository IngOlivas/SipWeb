using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace CapaDatos
{
   public class CDRegistroEquipo
    {
        private CDConexion conexion = new CDConexion();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();
        public DataSet D;
       public string parametros;

        public DataTable ListarMarcas()
        {
            DataTable Tabla = new DataTable();

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "ListarMarcas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            Tabla.Load(leer);
            conexion.CerrarConexion();

            return Tabla;
        }

        public DataTable ListarModelos()
        {
            DataTable Tabla = new DataTable();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ListarModelos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            Tabla.Load(leer);
            conexion.CerrarConexion();

            return Tabla;
        }

        public void InsertarEquipo(int idMarca, int idModelo, string nombre, string descripcion, string noSerie, string noActivo, string numFactura, string ubicacionBien, PictureBox imagen, string estado)
        {

            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarEquipo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idMarca",idMarca);
            comando.Parameters.AddWithValue("@idModelo",idModelo);
            comando.Parameters.AddWithValue("@nombre",nombre);
            comando.Parameters.AddWithValue("@descripcion",descripcion);
            comando.Parameters.AddWithValue("@noSerie",noSerie);
            comando.Parameters.AddWithValue("@noActivo",noActivo);
            comando.Parameters.AddWithValue("@numFactura",numFactura);
            comando.Parameters.AddWithValue("@ubicacionBien",ubicacionBien);

            comando.Parameters.Add("@imagen",SqlDbType.Image);
            //Convertir la imagen a binario para poder asignar el valor en BD
            //Buffer guarda los binarios en sql
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

             comando.Parameters["@imagen"].Value = ms.GetBuffer();

         
            comando.Parameters.AddWithValue("@estado",estado);

            comando.ExecuteNonQuery();
        
        }

        public DataTable ListarEquipo()
        {
            DataTable Tabla = new DataTable();

            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Clear();
            comando.CommandText = "ListarEquipo";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            Tabla.Load(leer);
            conexion.CerrarConexion();

            return Tabla;
        }

        public void verImagen(int idEquipo, PictureBox imagen)
        {
            SqlDataAdapter dp = new SqlDataAdapter(comando);

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "VerImagen";
            //comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@idEquipo", SqlDbType.Int);
            comando.Parameters["@idEquipo"].Value = idEquipo;

            DataSet ds = new DataSet("EquipoElectronico");
            dp.Fill(ds, "EquipoElectronico");
            byte[] datos = new byte[0];
            DataRow dr = ds.Tables["EquipoElectronico"].Rows[0];

            //Nombre del campo de la tabla seleccionada
            datos = (byte[])dr["imagen"];

            //Iguala el memorystream a datos
            System.IO.MemoryStream ms = new System.IO.MemoryStream(datos);

            imagen.Image = System.Drawing.Bitmap.FromStream(ms);

            comando.Parameters.Clear();
        }

        public void EliminarEquipo(int idEquipo)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarEquipo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEquipo", idEquipo);
            comando.ExecuteNonQuery();      
        }

        public void ModificarEquipo(int idEquipo, int idMarca, int idModelo, string nombre, string descripcion, string noSerie, string noActivo, string numFactura, string ubicacionBien, PictureBox imagen, string estado)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarEquipo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEquipo",idEquipo);
            comando.Parameters.AddWithValue("@idMarca", idMarca);
            comando.Parameters.AddWithValue("@idModelo", idModelo);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@noSerie", noSerie);
            comando.Parameters.AddWithValue("@noActivo", noActivo);
            comando.Parameters.AddWithValue("@numFactura", numFactura);
            comando.Parameters.AddWithValue("@ubicacionBien", ubicacionBien);

            comando.Parameters.Add("@imagen", SqlDbType.Image);
            //Convertir la imagen a binario para poder asignar el valor en BD
            //Buffer guarda los binarios en sql
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            comando.Parameters["@imagen"].Value = ms.GetBuffer();


            comando.Parameters.AddWithValue("@estado", estado);

            comando.ExecuteNonQuery();
         
        }

        public void InsertarMarca(string marca)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarMarca";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@marca",marca);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void EliminarMarca(int idMarca)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarMarca";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idMarca", idMarca);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void InsertarModelo(string modelo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarModelo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@modelo",modelo);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void EliminarModelo(int modelo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarModelo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idModelo",modelo);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable BuscarEquipoPorParametros(string parametro ,string tipoBusqueda)
        {
            parametros = parametro;

            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Clear();
            comando.CommandText = tipoBusqueda;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@parametro", parametro);
            
            SqlDataAdapter DA = new SqlDataAdapter(comando);
            D = new DataSet();
            DA.Fill(D,"EquipoElectronico");
            comando.Connection = conexion.CerrarConexion();
            return D.Tables["EquipoElectronico"]; 
        }

    }

}

