namespace SistemaDeInventariosJoel
{
    partial class FormCristalReporteEstadoEquipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCristalReporteEstadoEquipo));
            this.crystalReportViewerEstadoEquipo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewerEstadoEquipo
            // 
            this.crystalReportViewerEstadoEquipo.ActiveViewIndex = -1;
            this.crystalReportViewerEstadoEquipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerEstadoEquipo.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerEstadoEquipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerEstadoEquipo.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerEstadoEquipo.Name = "crystalReportViewerEstadoEquipo";
            this.crystalReportViewerEstadoEquipo.Size = new System.Drawing.Size(949, 511);
            this.crystalReportViewerEstadoEquipo.TabIndex = 0;
            this.crystalReportViewerEstadoEquipo.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(919, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 23);
            this.btnCerrar.TabIndex = 64;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormCristalReporteEstadoEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 511);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.crystalReportViewerEstadoEquipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCristalReporteEstadoEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte del Estado del Equipo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerEstadoEquipo;
        private System.Windows.Forms.Button btnCerrar;
    }
}