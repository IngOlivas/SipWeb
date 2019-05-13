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
using System.Data.SqlClient;
using System.Collections;
using System.IO;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SistemaDeInventariosJoel
{
    public partial class FormReportes : Form
    {

        //Constructores para las consultas SQL
        CDConexion conexion = new CDConexion();
        SqlCommand cmd;
        SqlDataReader dr;

        public FormReportes()
        {
            InitializeComponent();
        }

        //Load del formulario
        private void FormReportes_Load(object sender, EventArgs e)
        {
            GrafEquipoPreferido();
            GrafEquipoPreferidos();
        }

        #region METODOS PARA MOSTRAR VALORES EN LOS GRAFICOS
        ArrayList EquipoPref = new ArrayList();
        ArrayList Cantidad = new ArrayList();

        private void GrafEquipoPreferido()
        {

            try
            {
                cmd = new SqlCommand("EquiposPreferidos", conexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.AbrirConexion();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EquipoPref.Add(dr.GetString(0));
                    Cantidad.Add(dr.GetInt32(1));
                }
                chartEquiposPreferdos.Series[0].Points.DataBindXY(EquipoPref, Cantidad);
                dr.Close();
                conexion.CerrarConexion();

            }
            catch (Exception)
            {
                MessageBox.Show("Error por favor instale el prcedimiento almacenado de EquiposPreferidos");
            }
        }


        ArrayList EquipoPreferido = new ArrayList();
        ArrayList Cantidades = new ArrayList();

        private void GrafEquipoPreferidos()
        {
            try
            {
                cmd = new SqlCommand("EquiposPreferidos", conexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.AbrirConexion();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EquipoPreferido.Add(dr.GetString(0));
                    Cantidades.Add(dr.GetInt32(1));
                }
                chart2.Series[0].Points.DataBindXY(EquipoPreferido, Cantidad);
                dr.Close();
                conexion.CerrarConexion();
            }
            catch (Exception)
            {

                MessageBox.Show("Error por favor instale el prcedimiento almacenado de EquiposPreferidos");
            }

        }
        #endregion

        #region CODIGO PARA LOS BOTONES
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReporteEstadoEquipo_Click(object sender, EventArgs e)
        {
            try
            {

                string cadena = @"C:\CadenaDeConexion.txt";
                string lineaNombreServidor = File.ReadAllLines(cadena)[1];
                string lineaNombreBD = File.ReadAllLines(cadena)[2];


                FormCristalReporteEstadoEquipo form = new FormCristalReporteEstadoEquipo();
                CrystalReportEstadoEquipo reporte = new CrystalReportEstadoEquipo();

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

                form.BringToFront();
                form.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido mostrar el reporte");
            }
        }

        private void btnReporteInventario_Click_1(object sender, EventArgs e)
        {
             try
            {

               
                string cadena = @"C:\CadenaDeConexion.txt";
                string lineaNombreServidor = File.ReadAllLines(cadena)[1];
                string lineaNombreBD = File.ReadAllLines(cadena)[2];

                FormCristalReporteEstadoEquipo form = new FormCristalReporteEstadoEquipo();
                CrystalReportEstadoInventario reporte = new CrystalReportEstadoInventario();

                form.crystalReportViewerEstadoEquipo.ReportSource = reporte;

                var cn = new ConnectionInfo()
                {
                    ServerName = lineaNombreServidor,
                    DatabaseName = lineaNombreBD,
                    IntegratedSecurity = true,
                    Type = ConnectionInfoType.SQL
                };

                SetDbLogonForReport(cn,reporte);
                reporte.Refresh();
               

                form.BringToFront();
                form.Show();
           }
            catch (Exception)
            {
                MessageBox.Show("Error no se ha podido mostrar el reporte");
            }
         

        }
        #endregion

        #region FUNCION PARA LA EXTRACCION DE LOS DATOS DE CONEXION REPORTE

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