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
    public partial class SubFormPrestamos : Form
    {
        //Metodo para enviar los datos a el form de Prestamos en el campo equipos
        public delegate void enviarDatos(string idPrestamo , DateTime fechaInicial, DateTime fechaEntrega);
        public event enviarDatos enviado;

        //Conexion a capa de datos
        CNRegistroPrestamoDevolucion objetoCN = new CNRegistroPrestamoDevolucion();

        public SubFormPrestamos()
        {
            InitializeComponent();
            ListarPrestamos();
        }

        #region  Botones y Grid

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Funciones para listar
        public void ListarPrestamos()
       {
            gridPrestamos.DataSource = objetoCN.ListarPrestamos();
        }
        #endregion

        private void gridPrestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormRegistrarPrestamoDevolucion FormPrestamo = new FormRegistrarPrestamoDevolucion();
            Form_MenuPrincipal Fierro = new Form_MenuPrincipal();

            try
            {
                DataGridViewRow fila = gridPrestamos.Rows[e.RowIndex];

                enviado(Convert.ToString(fila.Cells[0].Value),
                    Convert.ToDateTime(fila.Cells[2].Value),
                    Convert.ToDateTime(fila.Cells[3].Value)
                    );

                this.Close();

            }
            catch (Exception){}
            }
    }
}