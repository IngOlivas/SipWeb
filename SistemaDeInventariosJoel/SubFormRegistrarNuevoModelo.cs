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
    public partial class SubFormRegistrarNuevoModelo : Form
    {
        CNRegistroEquipoElectronico objetoCN = new CNRegistroEquipoElectronico();
    
        public SubFormRegistrarNuevoModelo()
        {
            InitializeComponent();
        }

        private void SubFormRegistrarNuevoModelo_Load(object sender, EventArgs e)
        {
            ListarModelos();
        }

        #region CODIGO PARA LOS BOTONES Y EL DATAGRID
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdModelo.Text == "")
                {
                    MessageBox.Show("Error no ha seleciconado nungun dato!!!");
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea continuar?", "Ventana de confirmacion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        objetoCN.EliminarModelo(Convert.ToInt32(txtIdModelo.Text));
                        MessageBox.Show("Datos eliminados correctamente!!!");
                        txtIdModelo.Clear();
                        txtNombreModelo.Clear();
                        txtNombreModelo.Focus();
                        ListarModelos();
                    }         
                }
            }
            catch (Exception)
           {
                MessageBox.Show("Error no se ha podido eliminar!!!");
            }
           }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreModelo.Text == "")
                {
                    MessageBox.Show("Error no ha ingresado ningun dato!!!");
                }
                else
                {
                    objetoCN.InsertarModelo(txtNombreModelo.Text);
                    MessageBox.Show("Datos guardados correctamente!!!");
                    txtIdModelo.Clear();
                    txtNombreModelo.Clear();
                    txtNombreModelo.Focus();
                    ListarModelos();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido guardar!!!");
            }
        }

        private void gridModelo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow filas = gridModelo.Rows[e.RowIndex];

                txtIdModelo.Text = Convert.ToString(filas.Cells[0].Value);
                txtNombreModelo.Text = Convert.ToString(filas.Cells[1].Value);
            }
            catch (Exception) { }
        }

        #endregion

        #region METODOS PARA LISTAR

        private void ListarModelos()
        {
            CNRegistroEquipoElectronico objetoModelos = new CNRegistroEquipoElectronico();
            gridModelo.DataSource = objetoModelos.ListarModelos();
        }

        #endregion
    }
}