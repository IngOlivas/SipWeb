using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace CapaDatos
{
    public class CDConexion
    {

        static int i = 0; //Numero de la linea para leer la cadena de conexion (Primera linea)
        static string cadena = @"C:\CadenaDeConexion.txt";


       // static string rutaConexion = File.ReadAllText(cadena);

      static string rutaConexion = File.ReadAllLines(cadena)[i];

        public SqlConnection conexion = new SqlConnection(rutaConexion);

        public SqlConnection AbrirConexion()
        {

            if (conexion.State == ConnectionState.Closed)

                conexion.Open();
            return conexion;

        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }

    }


}