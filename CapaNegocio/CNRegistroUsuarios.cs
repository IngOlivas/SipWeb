using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CNRegistroUsuarios
    {
        private CDRegistroUsuarios objetoCD = new CDRegistroUsuarios();

        public DataTable MostrarUsuario()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarUsuarios();
            return tabla;
        }

        public void InsertarUsuarios(string nombre, string expediente, string tipoUsuario, string contraseña)
        {
            objetoCD.InsertarUsuarios(nombre,expediente,tipoUsuario,contraseña);
        }

        public void ModificarUsuarios(string nombre, string expediente, string tipoUsuario, string contraseña, int id)
        {
            objetoCD.ModificarUsuarios(nombre,expediente,tipoUsuario,contraseña,id);
        }

        public void EliminarUsuarios(int idUsuario)
        {
            objetoCD.EliminarUsuario(idUsuario);
        }
    }
}