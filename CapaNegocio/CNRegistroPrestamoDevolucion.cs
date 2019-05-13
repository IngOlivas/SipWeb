using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
   public class CNRegistroPrestamoDevolucion
    {
        private CDRegistroPrestamoDevolucion objetoCD = new CDRegistroPrestamoDevolucion();
        public string parametros;

        public void InsertarPrestamo(int idUsuario, string fechaInicio, string fechaEntrega , string estado)
        {
            objetoCD.InsertarPrestamo(idUsuario,fechaInicio,fechaEntrega,estado);    
        }

        public void ModificarEstadoPrestamo(int idEquipo,int idPrestamo)
        {
            objetoCD.ModificarEstadoPrestamo(idEquipo , idPrestamo);
        }
        
        public void ModificarEquipoDevolucion(int idEquipo , string ubicacionBien, string estado)
        {
            objetoCD.ModificarEquipoDevolucion(idEquipo,ubicacionBien,estado);
        }

        public void ModificarFechaEntregaDevolucion(int idPrestamo, string nuevaFecha)
        {
            objetoCD.ModificarFechaEntregaDevolucion(idPrestamo,nuevaFecha);
        }

        public DataTable ListarEquipoParaPrestamos()
        {
            return objetoCD.ListarEquipoParaPrestamos();
        }

        public DataTable ListarPrestamos()
        {
            return objetoCD.ListarPrestamos();
        }

        public DataTable BuscarEquipoPorParametros(string parametro, string tipoBusqueda)
        {
            parametros = parametro;
            return objetoCD.BuscarEquipoPorParametros(parametro, tipoBusqueda);
        }

        public DataTable BuscarIdPrestamoDevolucion(int idPrestamo)
        {
            return objetoCD.BuscarIdPrestamoDevolucion(idPrestamo);
        }

        public DataTable VerEquiposParaDevolucion(int idPrestamo)
        {
            return objetoCD.VerEquiposParaDevolucion(idPrestamo);
        }
    }
}