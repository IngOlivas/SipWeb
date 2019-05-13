using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaDatos;


namespace SistemaDeInventariosJoel
{
    public partial class Form_MenuPrincipal : Form
    {
        CDConexion conexion = new CDConexion();
        SqlCommand cmd;
       
        public Form_MenuPrincipal()
        {
            InitializeComponent();
 
        }

        //Load del formulario
        private void Form_MenuPrincipal_Load(object sender, EventArgs e)
        {
            PrivilegioUsuario();
            MostrarUsuarioActivo();
            DasboardDatos();
        }

        #region Metodo para imprimir el usuario y el expediente en el menu
        private void MostrarUsuarioActivo()
        {
            labelnombreUsuario.Text = Program.nombre;
            labelnumeroExp.Text = Program.expediente;
            labeltipoUsuario.Text = Program.tipoUsuario;
        }
        #endregion

        #region Metodo para restringir acceso a forms a los usuarios
        //Metodo para restringir el acceso a forms a los usuarios
        private void PrivilegioUsuario()
        {

            //Deshabilitar boton
            if (Program.tipoUsuario != "Administrador")
            {
                btnReportes.Enabled = false;
                btnFormEquipo.Enabled = false;
                btnFormRegistroUsuario.Enabled = false;
                panelTotalEquipos.Visible = false;
                panelTotalUsuarios.Visible = false;
                panelTotalPrestamos.Visible = false;
                panelCantidadMarcas.Visible = false;
                panelCantidadModelos.Visible = false;
            }

            //Ocultar boton
            /*
            if (Program.tipoUsuario != "Administrador")
            {
                btnReportes.Visible = false;
                btnFormEquipo.Visible = false;

            }
            
            */
            //Bloquear evento de boton

        }
        #endregion

        #region funcionalidades del formulario
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        //Evento para arrastrar el formulario con el raton
        private void panelTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Metodo para imprimir imformacion sobre el sistema en los Textbox superiores
        private void DasboardDatos()
        {

            try
            {
                cmd = new SqlCommand("DashboardDatos", conexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter totalEquipos = new SqlParameter("@totalEquipos", 0); totalEquipos.Direction = ParameterDirection.Output;
                SqlParameter totalUsuarios = new SqlParameter("@totalUsuarios", 0); ; totalUsuarios.Direction = ParameterDirection.Output;
                SqlParameter totalPrestamos = new SqlParameter("@totalPrestamos", 0); totalPrestamos.Direction = ParameterDirection.Output;
                SqlParameter cantidadMarcas = new SqlParameter("@cantidadMarcas", 0); cantidadMarcas.Direction = ParameterDirection.Output;
                SqlParameter cantidadModelos = new SqlParameter("@cantidadModelos", 0); cantidadModelos.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(totalEquipos);
                cmd.Parameters.Add(totalUsuarios);
                cmd.Parameters.Add(totalPrestamos);
                cmd.Parameters.Add(cantidadMarcas);
                cmd.Parameters.Add(cantidadModelos);

                conexion.AbrirConexion();
                cmd.ExecuteNonQuery();
                labelTotalEquipos.Text = cmd.Parameters["@totalEquipos"].Value.ToString();
                labelTotalUsuarios.Text = cmd.Parameters["@totalUsuarios"].Value.ToString();
                labelTotalPrestamos.Text = cmd.Parameters["@totalPrestamos"].Value.ToString();
                labelTotalMarcas.Text = cmd.Parameters["@cantidadMarcas"].Value.ToString();
                labelTotalModelos.Text = cmd.Parameters["@cantidadModelos"].Value.ToString();

                conexion.CerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("Error falta procedimiento almacenado de DashBoard Datos!!!");
            }
           
        }

        #endregion

        #region metodos para abir los formularios dentro del panel
        //METODO PARA ABRIR FORMULARIOS DENTRO DEL PANEL

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                //Linea para abrir varios formularios dentro de un panel
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                //
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }
        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["FormRegistrarEquipo"] == null)
                btnFormEquipo.BackColor = Color.FromArgb(4, 41, 68);

            if (Application.OpenForms["FormRegistrarPrestamoDevolucion"] == null)
                btnPrestamo.BackColor = Color.FromArgb(4, 41, 68);

            if (Application.OpenForms["FormReportes"] == null)
                btnReportes.BackColor = Color.FromArgb(4, 41, 68);

            if (Application.OpenForms["FormRegistrarUsuarios"] == null)
                btnFormRegistroUsuario.BackColor = Color.FromArgb(4, 41, 68);

        }
        #endregion

        #region funciones de los botones para abrir forms
        //Funciones de los botones para abrir forms
        //Barra de titulo
        //Capturar posiocion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;

        private void btnMaximizar_Click_1(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta a punto de cerrar Sip V1.6 ¿Desea Continuar?","Ventana de Confirmacion" , MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
        private void btnRestaurar_Click_1(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }
        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Botones de los formularios del sistema
        private void btnFormEquipo_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormRegistrarEquipo>();
            btnFormEquipo.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void btnFormRegistroUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormRegistrarUsuarios>();
            btnFormRegistroUsuario.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

         private void button1_Click(object sender, EventArgs e)
        {
            FormAcercaDe Form = new FormAcercaDe();
            Form.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DasboardDatos();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Desea Cerrar Sesion?", "Ventana de Confirmacion", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                FormLogin form = new FormLogin();
                this.Hide();
                form.Show();
             
            }

        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormRegistrarPrestamoDevolucion>();
            btnPrestamo.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormReportes>();
            btnReportes.BackColor = Color.FromArgb(12, 61, 92);
        }
        #endregion     
    }
}