using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
  public class CNUsuario
    {
        //Encapsular variables
        private CDUsuario objDato = new CDUsuario(); //Instancia a la capa de datos de usuarios
        //Variables necesarias para el login
        private String _expediente;
        private String _contraseña;
        //Todas las demas...
        private String _tipoUsuario;
        private String _idUsuario;
        private String _nombre;

        //Metodos GET Y SET  --> para el manejo de variables
        public String Contraseña
        {
            set
            {
                /*Se verifica si el usuario intenta loguearse con datos nulos para evitar que se haga la
                consulta al servidor y consumir recursos inecesarios agilizando asi la velocidad de respuesta*/
                if (value == "CONTRASEÑA") { _contraseña = "No ha ingresado la contraseña"; }
                else { _contraseña = value; }
            }
            get { return _contraseña; }
        }

        public String Expediente
        {

            set
            {
             /*Se verifica si el usuario intenta loguearse con datos nulos para evitar que se haga la
             consulta al servidor y consumir recursos inecesarios agilizando asi la velocidad de respuesta*/
                if (value == "USUARIO") { _expediente = "No ha ingresado el usuario"; }
                else { _expediente = value; }
                
            }
            get { return _expediente;}
        }

        public String TipoUsuario
        {
            set { _tipoUsuario = value; }
            get { return _tipoUsuario; }
        }

        public String Nombre
        {
            set {_nombre = value; }
            get { return _nombre; }
        }

        public String IdUsuario
        {
            set { _idUsuario = value; }
            get { return _idUsuario; }
        }

        //Constructor
        public CNUsuario(){}
        //FUNCIONES O METODOS
        public SqlDataReader IniciarSesion()
        {
            SqlDataReader Loguear;
            Loguear = objDato.IniciarSesion(Expediente , Contraseña);
            return Loguear;
        }
    }
}
