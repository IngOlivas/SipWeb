namespace SistemaDeInventariosJoel
{
    partial class FormReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title11 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title12 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportes));
            this.chartEquiposPreferdos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelGrafico1 = new System.Windows.Forms.Label();
            this.labelGrafico2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReporteEquipoMes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnReporteEstadoEquipo = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnReporteInventario = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartEquiposPreferdos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartEquiposPreferdos
            // 
            chartArea11.Name = "ChartArea1";
            this.chartEquiposPreferdos.ChartAreas.Add(chartArea11);
            this.chartEquiposPreferdos.Cursor = System.Windows.Forms.Cursors.No;
            legend11.Name = "Legend1";
            this.chartEquiposPreferdos.Legends.Add(legend11);
            this.chartEquiposPreferdos.Location = new System.Drawing.Point(617, 35);
            this.chartEquiposPreferdos.Name = "chartEquiposPreferdos";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series11.IsValueShownAsLabel = true;
            series11.LabelForeColor = System.Drawing.Color.White;
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            series11.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chartEquiposPreferdos.Series.Add(series11);
            this.chartEquiposPreferdos.Size = new System.Drawing.Size(434, 196);
            this.chartEquiposPreferdos.TabIndex = 0;
            this.chartEquiposPreferdos.Text = "chartEquiposPreferidos";
            title11.Name = "Title1";
            title11.Text = "Estadisticas del sistema";
            this.chartEquiposPreferdos.Titles.Add(title11);
            // 
            // chart2
            // 
            chartArea12.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea12.BackColor = System.Drawing.SystemColors.Control;
            chartArea12.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea12);
            this.chart2.Cursor = System.Windows.Forms.Cursors.Hand;
            legend12.BackColor = System.Drawing.SystemColors.Control;
            legend12.Enabled = false;
            legend12.Name = "Legend1";
            this.chart2.Legends.Add(legend12);
            this.chart2.Location = new System.Drawing.Point(15, 35);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            series12.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart2.Series.Add(series12);
            this.chart2.Size = new System.Drawing.Size(490, 196);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart1";
            title12.Name = "Title1";
            title12.Text = "Estadisticas del sistema";
            this.chart2.Titles.Add(title12);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelGrafico1);
            this.panel1.Controls.Add(this.labelGrafico2);
            this.panel1.Controls.Add(this.chartEquiposPreferdos);
            this.panel1.Controls.Add(this.chart2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 245);
            this.panel1.TabIndex = 64;
            // 
            // labelGrafico1
            // 
            this.labelGrafico1.AutoSize = true;
            this.labelGrafico1.BackColor = System.Drawing.SystemColors.Control;
            this.labelGrafico1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrafico1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.labelGrafico1.Location = new System.Drawing.Point(18, 7);
            this.labelGrafico1.Name = "labelGrafico1";
            this.labelGrafico1.Size = new System.Drawing.Size(379, 25);
            this.labelGrafico1.TabIndex = 69;
            this.labelGrafico1.Text = "Top 5 de los equipos mas prestados.";
            this.labelGrafico1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelGrafico2
            // 
            this.labelGrafico2.AutoSize = true;
            this.labelGrafico2.BackColor = System.Drawing.SystemColors.Control;
            this.labelGrafico2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrafico2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.labelGrafico2.Location = new System.Drawing.Point(623, 9);
            this.labelGrafico2.Name = "labelGrafico2";
            this.labelGrafico2.Size = new System.Drawing.Size(343, 23);
            this.labelGrafico2.TabIndex = 2;
            this.labelGrafico2.Text = "Top 5 de los equipos mas prestados.";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1088, 59);
            this.panel2.TabIndex = 65;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.label10.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(5, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(287, 38);
            this.label10.TabIndex = 22;
            this.label10.Text = "Generar Reportes";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnReporteEquipoMes);
            this.panel3.Controls.Add(this.btnReporteEstadoEquipo);
            this.panel3.Controls.Add(this.btnReporteInventario);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1088, 315);
            this.panel3.TabIndex = 69;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1000, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 74;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnReporteEquipoMes
            // 
            this.btnReporteEquipoMes.Activecolor = System.Drawing.Color.DodgerBlue;
            this.btnReporteEquipoMes.BackColor = System.Drawing.Color.Blue;
            this.btnReporteEquipoMes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporteEquipoMes.BorderRadius = 0;
            this.btnReporteEquipoMes.ButtonText = "Reporte del equipo utilizado durante el mes.";
            this.btnReporteEquipoMes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporteEquipoMes.DisabledColor = System.Drawing.Color.Gray;
            this.btnReporteEquipoMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEquipoMes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnReporteEquipoMes.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnReporteEquipoMes.Iconimage")));
            this.btnReporteEquipoMes.Iconimage_right = null;
            this.btnReporteEquipoMes.Iconimage_right_Selected = null;
            this.btnReporteEquipoMes.Iconimage_Selected = null;
            this.btnReporteEquipoMes.IconMarginLeft = 0;
            this.btnReporteEquipoMes.IconMarginRight = 0;
            this.btnReporteEquipoMes.IconRightVisible = true;
            this.btnReporteEquipoMes.IconRightZoom = 0D;
            this.btnReporteEquipoMes.IconVisible = true;
            this.btnReporteEquipoMes.IconZoom = 90D;
            this.btnReporteEquipoMes.IsTab = false;
            this.btnReporteEquipoMes.Location = new System.Drawing.Point(16, 198);
            this.btnReporteEquipoMes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReporteEquipoMes.Name = "btnReporteEquipoMes";
            this.btnReporteEquipoMes.Normalcolor = System.Drawing.Color.Blue;
            this.btnReporteEquipoMes.OnHovercolor = System.Drawing.Color.DodgerBlue;
            this.btnReporteEquipoMes.OnHoverTextColor = System.Drawing.Color.White;
            this.btnReporteEquipoMes.selected = false;
            this.btnReporteEquipoMes.Size = new System.Drawing.Size(358, 36);
            this.btnReporteEquipoMes.TabIndex = 72;
            this.btnReporteEquipoMes.Text = "Reporte del equipo utilizado durante el mes.";
            this.btnReporteEquipoMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporteEquipoMes.Textcolor = System.Drawing.Color.White;
            this.btnReporteEquipoMes.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnReporteEstadoEquipo
            // 
            this.btnReporteEstadoEquipo.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReporteEstadoEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnReporteEstadoEquipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporteEstadoEquipo.BorderRadius = 0;
            this.btnReporteEstadoEquipo.ButtonText = "Reporte de estado del equipo.";
            this.btnReporteEstadoEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporteEstadoEquipo.DisabledColor = System.Drawing.Color.Gray;
            this.btnReporteEstadoEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEstadoEquipo.Iconcolor = System.Drawing.Color.Transparent;
            this.btnReporteEstadoEquipo.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnReporteEstadoEquipo.Iconimage")));
            this.btnReporteEstadoEquipo.Iconimage_right = null;
            this.btnReporteEstadoEquipo.Iconimage_right_Selected = null;
            this.btnReporteEstadoEquipo.Iconimage_Selected = null;
            this.btnReporteEstadoEquipo.IconMarginLeft = 0;
            this.btnReporteEstadoEquipo.IconMarginRight = 0;
            this.btnReporteEstadoEquipo.IconRightVisible = true;
            this.btnReporteEstadoEquipo.IconRightZoom = 0D;
            this.btnReporteEstadoEquipo.IconVisible = true;
            this.btnReporteEstadoEquipo.IconZoom = 90D;
            this.btnReporteEstadoEquipo.IsTab = false;
            this.btnReporteEstadoEquipo.Location = new System.Drawing.Point(16, 133);
            this.btnReporteEstadoEquipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReporteEstadoEquipo.Name = "btnReporteEstadoEquipo";
            this.btnReporteEstadoEquipo.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnReporteEstadoEquipo.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReporteEstadoEquipo.OnHoverTextColor = System.Drawing.Color.White;
            this.btnReporteEstadoEquipo.selected = false;
            this.btnReporteEstadoEquipo.Size = new System.Drawing.Size(358, 36);
            this.btnReporteEstadoEquipo.TabIndex = 71;
            this.btnReporteEstadoEquipo.Text = "Reporte de estado del equipo.";
            this.btnReporteEstadoEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporteEstadoEquipo.Textcolor = System.Drawing.Color.White;
            this.btnReporteEstadoEquipo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEstadoEquipo.Click += new System.EventHandler(this.btnReporteEstadoEquipo_Click);
            // 
            // btnReporteInventario
            // 
            this.btnReporteInventario.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnReporteInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnReporteInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporteInventario.BorderRadius = 0;
            this.btnReporteInventario.ButtonText = "Reporte del equipo actual en el inventario.";
            this.btnReporteInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporteInventario.DisabledColor = System.Drawing.Color.Gray;
            this.btnReporteInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteInventario.Iconcolor = System.Drawing.Color.Transparent;
            this.btnReporteInventario.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnReporteInventario.Iconimage")));
            this.btnReporteInventario.Iconimage_right = null;
            this.btnReporteInventario.Iconimage_right_Selected = null;
            this.btnReporteInventario.Iconimage_Selected = null;
            this.btnReporteInventario.IconMarginLeft = 0;
            this.btnReporteInventario.IconMarginRight = 0;
            this.btnReporteInventario.IconRightVisible = true;
            this.btnReporteInventario.IconRightZoom = 0D;
            this.btnReporteInventario.IconVisible = true;
            this.btnReporteInventario.IconZoom = 90D;
            this.btnReporteInventario.IsTab = false;
            this.btnReporteInventario.Location = new System.Drawing.Point(14, 63);
            this.btnReporteInventario.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporteInventario.Name = "btnReporteInventario";
            this.btnReporteInventario.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnReporteInventario.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnReporteInventario.OnHoverTextColor = System.Drawing.Color.White;
            this.btnReporteInventario.selected = false;
            this.btnReporteInventario.Size = new System.Drawing.Size(357, 36);
            this.btnReporteInventario.TabIndex = 70;
            this.btnReporteInventario.Text = "Reporte del equipo actual en el inventario.";
            this.btnReporteInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporteInventario.Textcolor = System.Drawing.Color.White;
            this.btnReporteInventario.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteInventario.Click += new System.EventHandler(this.btnReporteInventario_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Reportes de inventario";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this.btnReporteEstadoEquipo;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 20;
            this.bunifuElipse2.TargetControl = this.btnReporteInventario;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 20;
            this.bunifuElipse3.TargetControl = this.btnReporteEquipoMes;
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1088, 619);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReportes";
            this.Text = "FormReportes";
            this.Load += new System.EventHandler(this.FormReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartEquiposPreferdos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartEquiposPreferdos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelGrafico2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelGrafico1;
        private Bunifu.Framework.UI.BunifuFlatButton btnReporteInventario;
        private Bunifu.Framework.UI.BunifuFlatButton btnReporteEstadoEquipo;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuFlatButton btnReporteEquipoMes;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private System.Windows.Forms.Button button1;
    }
}