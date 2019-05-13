using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using CapaNegocio;
using CapaDatos;



namespace SistemaDeInventariosJoel
{
    public partial class FormRegistrarEquipo : Form
    {
        //Conexion a la capam de negocio
        CNRegistroEquipoElectronico objetoCN = new CNRegistroEquipoElectronico();
        CDRegistroEquipo Fierro = new CDRegistroEquipo();
       

        public FormRegistrarEquipo()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        //Viene la funcion para actualizar los registros al momento de que se actualiza la bd
        private void RegistrarProductoInventario_Load(object sender, EventArgs e)
        {
            ListarMarcas();
            ListarModelos();
            ListarEquipo();
            txtProducto.Focus();
            
            //Privilegio();
        }

        #region METODOS PARA LISTAR
        public void ListarMarcas()
        {
            CNRegistroEquipoElectronico objMarca = new CNRegistroEquipoElectronico();
            comboMarca.DataSource = objMarca.ListarMarcas();
            comboMarca.DisplayMember = "marca";
            comboMarca.ValueMember = "idMarca";
        }

        public void ListarModelos()
        {
            CNRegistroEquipoElectronico objModelos = new CNRegistroEquipoElectronico();
            comboModelo.DataSource = objModelos.ListarModelos();
            comboModelo.DisplayMember = "modelo";
            comboModelo.ValueMember = "idModelo";
        }

        public void ListarEquipo()
        {
            CNRegistroEquipoElectronico objCN = new CNRegistroEquipoElectronico();
            GridEquipo.DataSource = objetoCN.ListarEquipo();
        }
        #endregion

        #region cODIGO PARA RESTRICCIONES A LOS BOTONES
        /*
        private void Privilegio()
        {
            if (Program.tipoUsuario != "Administrador")
            {
                btnGuardar.Visible = false;
                btnModificar.Visible = false;
                btnNuevo.Visible = false;
                btnBuscarImagen.Visible = false;
                btnEliminar.Visible = false;
            }
       }
             * */
        #endregion

        #region CODIGO PARA LOS BOTONES
        //Boton para guardar los datos en BD
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProducto.Text == "" || txtNumeroSerie.Text == "" || txtNumeroActivo.Text == "")
                {
                    MessageBox.Show("Error favor de llenar el minimo de registros");
                }
                else
                {
                    objetoCN.InsertarEquipo(Convert.ToInt32(comboMarca.SelectedValue), Convert.ToInt32(comboModelo.SelectedValue), 
                    txtProducto.Text, txtDescripcion.Text, txtNumeroSerie.Text, txtNumeroActivo.Text, txtNumFactura.Text,
                    txtUbicacionBien.Text, pictureBox1, comboEstado.Text);

                    MessageBox.Show("El equipo se ha guardado correctamente!!!");
                    NuevoRegistro();
                    ListarEquipo();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido guardar correctamente");
            }
        }

        //Boton para modificar los datos en BD.
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.ModificarEquipo(Convert.ToInt32(txtIdEquipo.Text), Convert.ToInt32(comboMarca.SelectedValue), Convert.ToInt32(comboModelo.SelectedValue), txtProducto.Text, txtDescripcion.Text, txtNumeroSerie.Text, txtNumeroActivo.Text, txtNumFactura.Text, txtUbicacionBien.Text, pictureBox1, comboEstado.Text);
                MessageBox.Show("Se ha modificado correctamente");
                ListarEquipo();
            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido modificar correctamente!!!");
            }
           

        }

        //Boton para eliminar los datos en BD
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProducto.Text == "" || txtNumeroSerie.Text == "" || txtNumeroActivo.Text == "")
                {
                    MessageBox.Show("Error favor de llenar el minimo de registros");
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea continuar?", "Ventana de confirmacion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        objetoCN.EliminarEquipo(Convert.ToInt32(txtIdEquipo.Text));
                        MessageBox.Show("Se ha eliminado correctamente!!!");
                        ListarEquipo();
                        NuevoRegistro();
                    }
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido eliminar!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SubFormRegistrarNuevaMarca SubFormMarca = new SubFormRegistrarNuevaMarca();
            SubFormMarca.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubFormRegistrarNuevoModelo SubFormModelo = new SubFormRegistrarNuevoModelo();
            SubFormModelo.Show();
        }

        //Boton para buscar Imagen
        private void btnBuscarImagen_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }
        #endregion

        #region EVENTOS DEL GRID E IMAGEN DEL FORMULARIO

        private void GridEquipo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.GridEquipo.Columns[e.ColumnIndex].Name == "estado")
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

        //Codigo para Visualizar la imagen en el Picture Box
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);

        }

        private void GridEquipo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridViewRow fila = GridEquipo.Rows[e.RowIndex];

                txtIdEquipo.Text = Convert.ToString(fila.Cells[0].Value);
                txtProducto.Text = Convert.ToString(fila.Cells[1].Value);
                comboMarca.Text = Convert.ToString(fila.Cells[2].Value);
                comboModelo.Text = Convert.ToString(fila.Cells[3].Value);
                txtDescripcion.Text = Convert.ToString(fila.Cells[4].Value);
                txtNumeroSerie.Text = Convert.ToString(fila.Cells[5].Value);
                txtNumeroActivo.Text = Convert.ToString(fila.Cells[6].Value);
                txtNumFactura.Text = Convert.ToString(fila.Cells[7].Value);
                txtUbicacionBien.Text = Convert.ToString(fila.Cells[8].Value);
                comboEstado.Text = Convert.ToString(fila.Cells[9].Value);
                objetoCN.verImagen(Convert.ToInt32(txtIdEquipo.Text), pictureBox1);
                btnGuardar.Visible = false;
                btnModificar.Visible = true;

            }
            catch (Exception)
            {

            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string combo = comboBuscar.Text;

            try
            {
                switch (combo)
                {
                    case "Nombre":
                        Fierro.parametros = txtBuscar.Text;
                        GridEquipo.DataSource = Fierro.BuscarEquipoPorParametros(Fierro.parametros, "ListarEquiposNombre");
                        break;
                    case "Marca":
                        Fierro.parametros = txtBuscar.Text;
                        GridEquipo.DataSource =  Fierro.BuscarEquipoPorParametros(Fierro.parametros, "ListarEquipoMarca");
                        break;
                    case "No.Serie":
                        Fierro.parametros = txtBuscar.Text;
                        GridEquipo.DataSource = Fierro.BuscarEquipoPorParametros(Fierro.parametros, "ListarEquiposNoSerie");
                        break;
                    case "No.Activo":
                        Fierro.parametros = txtBuscar.Text;
                        GridEquipo.DataSource = Fierro.BuscarEquipoPorParametros(Fierro.parametros, "ListarEquiposNoActivo");
                        break;
                    case "Ubicacion":
                        Fierro.parametros = txtBuscar.Text;
                        GridEquipo.DataSource = Fierro.BuscarEquipoPorParametros(Fierro.parametros, "ListarEquiposUbicacion");
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

        #region EVENTOS PARA LA VALIDACION DE CAMPOS
        private void txtNumeroSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsValidarTextBox.SoloNumeros(e);
        }

        private void txtNumeroActivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsValidarTextBox.SoloNumeros(e);
        }

        private void txtNumFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsValidarTextBox.SoloNumeros(e);
        }
        #endregion

        #region FUNCIONES DEL FORMULARIO
        public void NuevoRegistro()
        {
            txtIdEquipo.Text = "";
            txtProducto.Text = "";
            txtDescripcion.Text = "";
            txtNumeroSerie.Text = "";
            txtNumeroActivo.Text = "";
            txtUbicacionBien.Text = "";
            txtNumFactura.Text = "";
            txtNumFactura.Text = "";
            pictureBox1.Image = System.Drawing.Image.FromFile(@"C:\Program Files\Ing.Ricardo Olivas\Setup-Sip V1.6\PantallaOrdenador.png");
            txtBuscar.Text = "";
            btnGuardar.Visible = true;
            btnModificar.Visible = false;
            txtProducto.Focus();
        }
        //Codigo para poner y actualizar la fecha y la hora
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();

        }

        #endregion
    }
}



