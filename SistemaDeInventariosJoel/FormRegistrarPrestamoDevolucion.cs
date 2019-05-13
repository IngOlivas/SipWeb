using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using System.Data.SqlClient;
using System.IO;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace SistemaDeInventariosJoel
{
    public partial class FormRegistrarPrestamoDevolucion : Form
    {

        CNRegistroPrestamoDevolucion objetoCN = new CNRegistroPrestamoDevolucion();
        CDConexion conexion = new CDConexion();

        public FormRegistrarPrestamoDevolucion()
        {
            InitializeComponent();
            timer1.Enabled = true;
            MostrarUsuarioActivo();
        }

        private void FormRegistrarPrestamoDevolucion_Load(object sender, EventArgs e)
        {
            txtNombrePrestamo.Focus();
        }

        #region CODIGO PARA LOS BOTONES
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            SubFormEquiposParaPrestamo Form = new SubFormEquiposParaPrestamo();
            Form.enviado += new SubFormEquiposParaPrestamo.enviar(ejecutar);
            Form.ShowDialog();
        }

        private void btnBuscarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                SubFormPrestamos Form2 = new SubFormPrestamos();
                Form2.enviado += new SubFormPrestamos.enviarDatos(ejecutarBusqueda);

                Form2.ShowDialog();
                NuevaDevolucion();

                objetoCN.BuscarIdPrestamoDevolucion(Convert.ToInt32(txtidPrestamo.Text));

                GridDevolucion.DataSource = objetoCN.VerEquiposParaDevolucion(Convert.ToInt32(txtidPrestamo.Text));

            }
            catch (Exception)
            {
                NuevoRegistro();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             try
            {
            if (txtNombrePrestamo.Text == "")
            {
                MessageBox.Show("Favor de introducir los datos del cliente y el equipo!!!");
            }
            else
            {
                //Variables para los metodos
                DateTime fechaInicio = dateTimeInicioPrestamo.Value;
                DateTime fechaEntrega = dateTimeFinalPrestamo.Value;
                string estado = "Prestado";

                //Metodos para guardar el prestamo, el detalle y modificar parametros en EquipoElectronico
                objetoCN.InsertarPrestamo(Convert.ToInt32(txtidUsuario.Text), fechaInicio.ToShortDateString().ToString(), fechaEntrega.ToShortDateString().ToString(), estado);
                VerUltimoPrestamo();
                InsertarDetalleEquipo();

                ModificarEquipoPrestamo();

                //Mensajes de salida
                MessageBox.Show("Prestamo Realizado correctamente!!!");

                    //Generacion del reporte

                    string cadena = @"C:\CadenaDeConexion.txt";
                    string lineaNombreServidor = File.ReadAllLines(cadena)[1];
                    string lineaNombreBD = File.ReadAllLines(cadena)[2];

                    FormCristalReporteEstadoEquipo form = new FormCristalReporteEstadoEquipo();
                    CrystalReportValePrestamo reporte = new CrystalReportValePrestamo();
                   
                    form.crystalReportViewerEstadoEquipo.ReportSource = reporte;

                    var cn = new ConnectionInfo()
                    {
                        ServerName = lineaNombreServidor,
                        DatabaseName = lineaNombreBD,
                        IntegratedSecurity = true,
                        Type = ConnectionInfoType.SQL
                    };


                    SetDbLogonForReport(cn, reporte);
                    reporte.Refresh();
                    reporte.SetParameterValue("@idPrestamo", Convert.ToInt32(txtidPrestamo.Text));
                    form.Show();

                    NuevoRegistro();
                    form.BringToFront();
                }

              }
            catch (Exception)
            {
              MessageBox.Show("Error no se ha podido realizar el prestamo correctamente!!!");
            }
             finally
            {
              conexion.CerrarConexion();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                GridEquipo.Rows.Remove(GridEquipo.CurrentRow);
            }
            catch (Exception)
            {

            }

        }

        private void btnAñadirEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtidEquipo.Text == "" || txtExpediente.Text == "" || txtNombrePrestamo.Text == "")
                {
                    MessageBox.Show("Favor de introducir todos los datos del usuario a prestar y/o equipo!!");
                }
                else
                {
                    GridEquipo.Rows.Add(txtidEquipo.Text, txtNombrePrestamo.Text, txtExpediente.Text,
                    txtNombre.Text, txtMarca.Text, txtModelo.Text, txtnoSerie.Text, txtnoActivo.Text, txtUbicacion.Text,
                    comboEstado.Text);

                    NuevoEquipo();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido añadir el equipo!!!");
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.ModificarEstadoPrestamo(Convert.ToInt32(txtidEquipo.Text), Convert.ToInt32(txtidPrestamo.Text));
                MessageBox.Show("Devolucion realizada correctamente!!!");
                GridDevolucion.DataSource = objetoCN.VerEquiposParaDevolucion(Convert.ToInt32(txtidPrestamo.Text));
                ModificarEquipoDevolucion();
            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido realizar la devolucion correctamente!!!");
            }

        }

        private void GridDevolucion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      

            try
            {
                DataGridViewRow fila = GridDevolucion.Rows[e.RowIndex];
                txtidEquipo.Text = Convert.ToString(fila.Cells[0].Value);
                txtNombrePrestamo.Text = Convert.ToString(fila.Cells[1].Value);
                txtExpediente.Text = Convert.ToString(fila.Cells[2].Value);
                txtNombre.Text = Convert.ToString(fila.Cells[3].Value);
                txtMarca.Text = Convert.ToString(fila.Cells[4].Value);
                txtModelo.Text = Convert.ToString(fila.Cells[5].Value);
               // txtnoSerie.Text = Convert.ToString(fila.Cells[6].Value);
               // txtnoActivo.Text = Convert.ToString(fila.Cells[7].Value);
                txtUbicacion.Text = Convert.ToString(fila.Cells[6].Value);
              //CORREGIR LA IMPRESION DEL ESTADO EN EL COMBO
            }
            catch (Exception) { }
        }

        private void btnNuevoVale_Click(object sender, EventArgs e)
        {
            try
            {
                //MODIFICAR LA FECHA PARA EL NUEVO PRESTAMO
                DateTime fechaEntrega = dateTimeFinalPrestamo.Value;

                objetoCN.ModificarFechaEntregaDevolucion(Convert.ToInt32(txtidPrestamo.Text), fechaEntrega.ToShortDateString().ToString());

                //GENERACION DEL REPORTE

                string cadena = @"C:\CadenaDeConexion.txt";
                string lineaNombreServidor = File.ReadAllLines(cadena)[1];
                string lineaNombreBD = File.ReadAllLines(cadena)[2];

                FormCristalReporteEstadoEquipo form = new FormCristalReporteEstadoEquipo();
                CrystalReportValePrestamo reporte = new CrystalReportValePrestamo();

                form.crystalReportViewerEstadoEquipo.ReportSource = reporte;

                var cn = new ConnectionInfo()
                {
                    ServerName = lineaNombreServidor,
                    DatabaseName = lineaNombreBD,
                    IntegratedSecurity = true,
                    Type = ConnectionInfoType.SQL
                };


                SetDbLogonForReport(cn, reporte);
                reporte.Refresh();
                reporte.SetParameterValue("@idPrestamo", Convert.ToInt32(txtidPrestamo.Text));
                form.Show();

                NuevoRegistro();
                form.BringToFront();
            }

            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido mostrar el nuevo vale correctamente!!!");
            }
        }
        #endregion

        #region FUNCIONES PARA PASAR DATOS DE UN FORM A OTRO
        public void ejecutar(string idEquipo, string nombre, string marca, string modelo, string noSerie, string noActivo, string ubicacion, string estado)
        {
            txtidEquipo.Text = idEquipo;
            txtNombre.Text = nombre;
            txtMarca.Text = marca;
            txtModelo.Text = modelo;
            txtnoSerie.Text = noSerie;
            txtnoActivo.Text = noActivo;
            txtUbicacion.Text = ubicacion;
            comboEstado.Text = estado;
        }

        public void ejecutarBusqueda(string idPrestamo, DateTime fechInicial, DateTime fechaEntrega)
        {
            txtidPrestamo.Text = idPrestamo;
            dateTimeInicioPrestamo.Text = fechInicial.ToString();
            dateTimeFinalPrestamo.Text = fechaEntrega.ToString();
        }
        #endregion

        #region FUNCIONES PARA LISTAR
        private void NuevoRegistro()
        {
            txtidPrestamo.Clear();
            txtNombrePrestamo.Clear();
            txtExpediente.Clear();
            txtidEquipo.Clear();
            txtNombre.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtnoSerie.Clear();
            txtnoActivo.Clear();
            txtUbicacion.Clear();
            txtNombrePrestamo.Focus();
            GridEquipo.Rows.Clear();

            btnAñadirEquipo.Visible = true;
            btnGuardar.Visible = true;
            BtnBuscar.Visible = true;
            btnEliminar.Visible = true;
            comboEstado.Enabled = true;
            txtExpediente.Enabled = true;
            txtNombrePrestamo.Enabled = true;
            dateTimeInicioPrestamo.Enabled = true;

            GridEquipo.Visible = true;
            GridDevolucion.Visible = false;
            btnModificar.Visible = false;
            btnNuevoVale.Visible = false;
        }

        private void NuevoEquipo()
        {
            txtidEquipo.Clear();
            txtNombre.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtnoSerie.Clear();
            txtnoActivo.Clear();
            txtUbicacion.Clear();
            txtNombre.Focus();
        }

        private void NuevaDevolucion()
        {

            btnAñadirEquipo.Visible = false;
            btnGuardar.Visible = false;
            BtnBuscar.Visible = false;
            btnEliminar.Visible = false;
            comboEstado.Enabled = true;
            txtExpediente.Enabled = false;
            txtNombrePrestamo.Enabled = false;
            dateTimeInicioPrestamo.Enabled = false;
            GridEquipo.Visible = false;
            GridDevolucion.Visible = true;
            btnModificar.Visible = true;
            btnNuevoVale.Visible = true;
        }

        public void VerIdUsuario()
        {
            SqlCommand comando = new SqlCommand("select top(1) idPrestamo from PrestamoEquipo order by idPrestamo desc", conexion.conexion);
            conexion.AbrirConexion();
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                txtidPrestamo.Text = registro["idPrestamo"].ToString();
            }
            conexion.CerrarConexion();

        }

        private void MostrarUsuarioActivo()
        {
            labelUsuario.Text = Program.nombre;
            txtidUsuario.Text = Program.idUsuario;
        }



        #endregion

        #region FUNCIONES PARA LA VALIDACION DE TEXTBOX
        private void txtExpediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsValidarTextBox.SoloNumeros(e);
        }

        #endregion

        #region FUNCIONES PARA EL PRESTAMO DE EQUIPO
        public void VerUltimoPrestamo()
        {
            SqlCommand comando = new SqlCommand("select top(1) idPrestamo from PrestamoEquipo order by idPrestamo desc", conexion.conexion);
            conexion.AbrirConexion();

            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                txtidPrestamo.Text = registro["idPrestamo"].ToString();
            }
            conexion.CerrarConexion();
        }

        public void InsertarDetalleEquipo()
        {
            SqlCommand agregar = new SqlCommand("insert into DetallePrestamo values(@idPrestamo,@idEquipo,@nombrePrestamo,@Expediente,'Prestado')", conexion.conexion);
            conexion.AbrirConexion();

            foreach (DataGridViewRow row in GridEquipo.Rows)
            {
                agregar.Parameters.Clear();
                agregar.Parameters.AddWithValue("@idPrestamo", Convert.ToInt32(txtidPrestamo.Text));
                agregar.Parameters.AddWithValue("@idEquipo", Convert.ToInt32(row.Cells["idEquipo"].Value));
                agregar.Parameters.AddWithValue("@nombrePrestamo", Convert.ToString(row.Cells["nombrePrestamo"].Value));
                agregar.Parameters.AddWithValue("@expediente", Convert.ToString(row.Cells["expediente"].Value));
               
                agregar.ExecuteNonQuery();
            }

        }
        
        public void ModificarEquipoPrestamo()
        {    
            foreach (DataGridViewRow row in GridEquipo.Rows)
            {

                objetoCN.ModificarEquipoDevolucion
                (
                Convert.ToInt32(row.Cells["idEquipo"].Value),
                Convert.ToString(row.Cells[8].Value),
                Convert.ToString(row.Cells["estado"].Value)
                );
            }
        }

        public void ModificarEquipoDevolucion()
        {    
               objetoCN.ModificarEquipoDevolucion
               (Convert.ToInt32(txtidEquipo.Text),
                txtUbicacion.Text,
                comboEstado.Text
               );  
        }
        
        public void ModificarEstado()
        {

            SqlCommand Modificar = new SqlCommand("update DetallePrestamo set estadoPrestamo = 'Devuelto'  where idEquipo = @idEquipo", conexion.AbrirConexion());

            foreach (DataGridViewRow rows in GridEquipo.Rows)
            {
                Modificar.Parameters.Clear();

                Modificar.Parameters.AddWithValue("@idEquipo", Convert.ToInt32(rows.Cells["idEquipo"].Value));
                Modificar.ExecuteNonQuery();
            }

            MessageBox.Show("Devolucion realizada correctamente!!!");
            NuevoRegistro();


        }

        private void SetDbLogonForReport(ConnectionInfo connectionInfo, ReportDocument rptDocument)
        {
            Tables myTables = rptDocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table myTable in myTables)
            {
                TableLogOnInfo myTableLogonInfo = myTable.LogOnInfo;
                myTableLogonInfo.ConnectionInfo = connectionInfo;
                myTable.ApplyLogOnInfo(myTableLogonInfo);
            }
        }

        #endregion
    }
}