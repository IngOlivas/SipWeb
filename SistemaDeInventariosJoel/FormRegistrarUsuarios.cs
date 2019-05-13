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
    public partial class FormRegistrarUsuarios : Form
    {
        //Conexion a la capa de negocio
        CNRegistroUsuarios objetoCN = new CNRegistroUsuarios();
        public delegate void enviar2(string idUsuario);
     //public event enviar2 Fierro;

        public FormRegistrarUsuarios()
        {
            InitializeComponent();
        }

        //Load del formulario
        private void FormRegistrarUsuarios_Load(object sender, EventArgs e)
        {

            MostrarUsuarios();
            txtNombre.Focus();
        }

        #region CODIGO PARA LOS BOTONES

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Metodo para guardar
            try
            {
                if (txtNombre.Text == "" || txtExpediente.Text == "" || txtContraseña.Text == "" || comboTipoUsuario.Text == "")
                {
                    MessageBox.Show("Error favor de llenar todos los campos correctamente!!!");
                }
                else
                {
                    objetoCN.InsertarUsuarios(txtNombre.Text, txtExpediente.Text, comboTipoUsuario.Text, txtContraseña.Text);
                    MessageBox.Show("Datos guardados correctamente!!!");
                    MostrarUsuarios();
                    limpiar();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido guardar!!!");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.ModificarUsuarios(txtNombre.Text, txtExpediente.Text, comboTipoUsuario.Text, txtContraseña.Text, Convert.ToInt32(txtIdUsuario.Text));
                MessageBox.Show("Datos modificados correctamente!!!");
                MostrarUsuarios();
                limpiar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido modificar!!!");
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (txtExpediente.Text == "" || txtContraseña.Text == ""    || txtNombre.Text == "" )
                {
                    MessageBox.Show("Favor de llenar todos los datos del usuario");
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea continuar?", "Ventana de confirmacion", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        objetoCN.EliminarUsuarios(Convert.ToInt32(txtIdUsuario.Text));
                        MessageBox.Show("Usuario eliminado correctamente!!!");
                        MostrarUsuarios();
                        limpiar();
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido eliminar el equipo correctamente!!!");           
            }
         
        }
        #endregion

        #region CODIGO LOE EVENTOS DEL FORMULARIO

        private void GridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Metodo para dar click y que se muestren los valores en los textbox
            try
            {
                DataGridViewRow fila = GridUsuarios.Rows[e.RowIndex];
                txtIdUsuario.Text = Convert.ToString(fila.Cells[0].Value);
                txtNombre.Text = Convert.ToString(fila.Cells[1].Value);
                txtExpediente.Text = Convert.ToString(fila.Cells[2].Value);
                comboTipoUsuario.Text = Convert.ToString(fila.Cells[3].Value);
                txtContraseña.Text = Convert.ToString(fila.Cells[4].Value);
                btnGuardar.Visible = false;
                btnModificar.Visible = true;
            }
            catch (Exception)
            {
            }

        }

        private void txtExpediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsValidarTextBox.SoloNumeros(e);
        }

        #endregion

        #region FUNCIONES Y METODO PARA LISTAR 

        private void MostrarUsuarios()
        {
            CNRegistroUsuarios objeto = new CNRegistroUsuarios();
            GridUsuarios.DataSource = objeto.MostrarUsuario();
        }

        private void limpiar()
        {
            txtIdUsuario.Clear();
            txtNombre.Clear();
            txtExpediente.Clear();
            txtContraseña.Clear();
            btnModificar.Visible = false;
            btnGuardar.Visible = true;
            txtNombre.Focus();
        }

        #endregion
    }
}