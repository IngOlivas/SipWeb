using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Windows.Forms;
using System.Data;

namespace CapaNegocio
{
    public class CNRegistroEquipoElectronico
    {
        CDRegistroEquipo objetoCD = new CDRegistroEquipo();
        public string parametros;

        public void InsertarEquipo(int idMarca, int idModelo, string nombre, string descripcion, string noSerie, string noActivo, string numFactura, string ubicacionBien, PictureBox imagen, string estado)
        {
            objetoCD.InsertarEquipo(idMarca, idModelo, nombre, descripcion, noSerie, noActivo, numFactura, ubicacionBien, imagen, estado);
        }

        public void EliminarEquipo(int idEquipo)
        {
            objetoCD.EliminarEquipo(idEquipo);
        }

        public void ModificarEquipo(int idEquipo, int idMarca, int idModelo, string nombre, string descripcion, string noSerie, string noActivo, string numFactura, string ubicacionBien, PictureBox imagen, string estado)
        {
            objetoCD.ModificarEquipo(idEquipo, idMarca, idModelo, nombre, descripcion, noSerie, noActivo, numFactura, ubicacionBien, imagen, estado);
        }

        public void InsertarMarca(string marca)
        {
            objetoCD.InsertarMarca(marca);
        }

        public void EliminarMarca(int idMarca)
        {
            objetoCD.EliminarMarca(idMarca);
        }

        public void InsertarModelo(string modelo)
        {
            objetoCD.InsertarModelo(modelo);
        }

        public void EliminarModelo(int idModelo)
        {
            objetoCD.EliminarModelo(idModelo);
        }

        public void verImagen(int idEquipo, PictureBox imagen)
        {
            objetoCD.verImagen(idEquipo, imagen);
        }

        public DataTable ListarEquipo()
        {
            return objetoCD.ListarEquipo();
        }

        public DataTable ListarModelos()
        {
            return objetoCD.ListarModelos();
        }

        public DataTable ListarMarcas()
        {
            return objetoCD.ListarMarcas();
        }

        public DataTable BuscarEquipoPorParametros(string parametro, string tipoBusqueda)
        {
            parametros = parametro;
            return objetoCD.BuscarEquipoPorParametros(parametro , tipoBusqueda);
        }
    }
}