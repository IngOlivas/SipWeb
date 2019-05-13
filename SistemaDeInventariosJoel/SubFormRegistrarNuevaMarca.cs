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
    public partial class SubFormRegistrarNuevaMarca : Form
    {
    
        CNRegistroEquipoElectronico objetoCN = new CNRegistroEquipoElectronico();
    
        public SubFormRegistrarNuevaMarca()
        {
            InitializeComponent();
        }

        private void SubFormRegistrarNuevaMarca_Load(object sender, EventArgs e)
        {
            ListarMarcas();
        }

        #region Codigo para los botones y el datagrid

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreMarca.Text == "")
                {
                    MessageBox.Show("Error no ha ingresado ningun dato!!!");
                }
                else
                {
                    objetoCN.InsertarMarca(txtNombreMarca.Text);
                    MessageBox.Show("Marca guardada correctamente!!!");
                    txtIdMarca.Clear();
                    txtNombreMarca.Clear();
                    txtNombreMarca.Focus();
                    ListarMarcas();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido guardad!!!");
            }
           
            }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdMarca.Text == "")
                {
                    MessageBox.Show("Error no ha seleccionado ningun dato!!!");
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea continuar?", "Ventana de confirmacion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        objetoCN.EliminarMarca(Convert.ToInt32(txtIdMarca.Text));
                        MessageBox.Show("Datos eliminados correctamente!!!");
                        txtIdMarca.Clear();
                        txtNombreMarca.Clear();
                        ListarMarcas();
                    }
                }
            } catch (Exception)
            {
                MessageBox.Show("Error no se ha podido eliminar correctamente!!!");
            }
        }

        private void gridMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow fila = gridMarca.Rows[e.RowIndex];

                txtIdMarca.Text = Convert.ToString(fila.Cells[0].Value);
                txtNombreMarca.Text = Convert.ToString(fila.Cells[1].Value);
            }
            catch (Exception) { }
        }
        #endregion

        #region Metodos para listar
        private void ListarMarcas()
        {
            CNRegistroEquipoElectronico objetoMarca = new CNRegistroEquipoElectronico();
            gridMarca.DataSource = objetoMarca.ListarMarcas();
        }

        #endregion
    }
}