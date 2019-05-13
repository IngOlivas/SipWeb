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
using System.Data.SqlClient;

namespace SistemaDeInventariosJoel
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        #region CODIGO DE LOS EVENTOS DEL FORMULARIO
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }

        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }
        #endregion

        #region CODIGO DE LOS BOTONES

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                CNUsuario objUsuario = new CNUsuario();
                SqlDataReader Loguear;
                objUsuario.Expediente = txtUsuario.Text;
                objUsuario.Contraseña = txtContraseña.Text;


                if (objUsuario.Expediente == txtUsuario.Text)
                {
                    labelErrorUsuario.Visible = false;

                    if (objUsuario.Contraseña == txtContraseña.Text)
                    {
                        labelErrorContraseña.Visible = false;
                        Loguear = objUsuario.IniciarSesion();

                        if (Loguear.Read() == true)
                        {
                            this.Hide();

                            Form_MenuPrincipal objFP = new Form_MenuPrincipal();

                            //Carga los campos guardados en datareader para usarlos en los forms
                            Program.tipoUsuario = Loguear["tipoUsuario"].ToString();
                            Program.nombre = Loguear["nombre"].ToString();
                            Program.expediente = Loguear["expediente"].ToString();
                            Program.idUsuario = Loguear["idUsuario"].ToString();
                            objFP.Show();
                        }

                        else
                        {
                            labelErrorLogin.Visible = true;
                            labelErrorLogin.Text = "Usuario o contraseña invalidos. intente de nuevo";
                            txtUsuario.Text = "";
                            txtUsuario_Leave(null, e);
                            txtUsuario.Focus();
                        }

                    }
                    else
                    {
                        labelErrorContraseña.Visible = true;
                        labelErrorContraseña.Text = objUsuario.Contraseña;
                    }
                }
                else
                {
                    labelErrorUsuario.Visible = true;
                    labelErrorUsuario.Text = objUsuario.Expediente;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error con la conexion al servidor. " +
                "Verifique que la cadena de conexion y la ruta esten correctas!!!");
            }         
        }


        #endregion

           }
}
