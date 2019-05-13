using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace SistemaDeInventariosJoel
{
    public partial class SubFormEquiposParaPrestamo : Form
    {
        //Metodo para enviar los datos a el form de Prestamos en el campo equipos
        public delegate void enviar(string idEquipo, string nombre, string marca, string modelo, string noSerie, string noActivo, string ubicacion, string estado);
        public event enviar enviado;

        //Conexion a la capa de negocio
        CNRegistroPrestamoDevolucion objetoCN = new CNRegistroPrestamoDevolucion();

        public SubFormEquiposParaPrestamo()
        {
            InitializeComponent();
            ListarEquipoParaPrestamo();
        }

        #region FUNCIONES PARA LISTAR
        public void ListarEquipoParaPrestamo()
        {
            CNRegistroEquipoElectronico ListarEquipoPrestamos = new CNRegistroEquipoElectronico();
            gridEquiposPrestamo.DataSource = objetoCN.ListarEquipoParaPrestamos();
        }
        #endregion

        #region BOTONES Y EL GRID
        private void gridEquiposPrestamo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            FormRegistrarPrestamoDevolucion FormPrestamo = new FormRegistrarPrestamoDevolucion();
            //Form_MenuPrincipal Fierro = new Form_MenuPrincipal();

            try
            {
                DataGridViewRow fila = gridEquiposPrestamo.Rows[e.RowIndex];

                enviado(Convert.ToString(fila.Cells[0].Value),
                        Convert.ToString(fila.Cells[1].Value),
                        Convert.ToString(fila.Cells[2].Value),
                        Convert.ToString(fila.Cells[3].Value),
                        Convert.ToString(fila.Cells[4].Value),
                        Convert.ToString(fila.Cells[5].Value),
                        Convert.ToString(fila.Cells[6].Value),
                        Convert.ToString(fila.Cells[7].Value));

                this.Close();

            }
            catch (Exception) { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region FORMATO DE CELDAS
        private void gridEquiposPrestamo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.gridEquiposPrestamo.Columns[e.ColumnIndex].Name == "estado")
            {
                if (Convert.ToString(e.Value) == "Dañado")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Red;
                }
                if (Convert.ToString(e.Value) == "OK")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Green;
                }
                if (Convert.ToString(e.Value) == "Necesita Reparacion")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.OrangeRed;
                }
            }
        }
        #endregion

        #region EVENTOS DEL FORMULARIOS
        private void txtBuscarEquipo_TextChanged(object sender, EventArgs e)
        {
            string combo = comboBuscar.Text;

            try
            {
                switch (combo)
                {
                    case "Nombre":
                        objetoCN.parametros = txtBuscar.Text;
                        gridEquiposPrestamo.DataSource = objetoCN.BuscarEquipoPorParametros(objetoCN.parametros, "ListarEquiposNombre");
                        break;
                    case "Marca":
                        objetoCN.parametros = txtBuscar.Text;
                        gridEquiposPrestamo.DataSource = objetoCN.BuscarEquipoPorParametros(objetoCN.parametros, "ListarEquipoMarca");
                        break;
                    case "No.Serie":
                        objetoCN.parametros = txtBuscar.Text;
                        gridEquiposPrestamo.DataSource = objetoCN.BuscarEquipoPorParametros(objetoCN.parametros, "ListarEquiposNoSerie");
                        break;
                    case "No.Activo":
                        objetoCN.parametros = txtBuscar.Text;
                        gridEquiposPrestamo.DataSource = objetoCN.BuscarEquipoPorParametros(objetoCN.parametros, "ListarEquiposNoActivo");
                        break;
                    case "Ubicacion":
                        objetoCN.parametros = txtBuscar.Text;
                        gridEquiposPrestamo.DataSource = objetoCN.BuscarEquipoPorParametros(objetoCN.parametros, "ListarEquiposUbicacion");
                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido buscar correctamente!!!");
            }
        }
        #endregion
    }
}