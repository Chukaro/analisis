namespace TiendaAlmacen
{
    partial class buscarEmpleado
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewBuscarEmpleado = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscarEmpleado = new System.Windows.Forms.Button();
            this.cmBoxBuscarTipoEmpleado = new System.Windows.Forms.ComboBox();
            this.txtBuscarEmpleado = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuscarEmpleado)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Controls.Add(this.btnActualizar);
            this.panel3.Controls.Add(this.btnEliminar);
            this.panel3.Location = new System.Drawing.Point(0, 414);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(572, 60);
            this.panel3.TabIndex = 8;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnActualizar.Image = global::TiendaAlmacen.Properties.Resources.descarga;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(449, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(105, 43);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEliminar.Image = global::TiendaAlmacen.Properties.Resources.boton_de_cancelacion_de_icono_7349_481;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(326, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(106, 43);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.dataGridViewBuscarEmpleado);
            this.panel2.Location = new System.Drawing.Point(3, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(572, 337);
            this.panel2.TabIndex = 7;
            // 
            // dataGridViewBuscarEmpleado
            // 
            this.dataGridViewBuscarEmpleado.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewBuscarEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBuscarEmpleado.Location = new System.Drawing.Point(17, 12);
            this.dataGridViewBuscarEmpleado.Name = "dataGridViewBuscarEmpleado";
            this.dataGridViewBuscarEmpleado.Size = new System.Drawing.Size(534, 294);
            this.dataGridViewBuscarEmpleado.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.btnBuscarEmpleado);
            this.panel1.Controls.Add(this.cmBoxBuscarTipoEmpleado);
            this.panel1.Controls.Add(this.txtBuscarEmpleado);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 62);
            this.panel1.TabIndex = 6;
            // 
            // btnBuscarEmpleado
            // 
            this.btnBuscarEmpleado.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBuscarEmpleado.Image = global::TiendaAlmacen.Properties.Resources.buscar__1_;
            this.btnBuscarEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarEmpleado.Location = new System.Drawing.Point(422, 8);
            this.btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            this.btnBuscarEmpleado.Size = new System.Drawing.Size(100, 43);
            this.btnBuscarEmpleado.TabIndex = 2;
            this.btnBuscarEmpleado.Text = "Buscar";
            this.btnBuscarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarEmpleado.UseVisualStyleBackColor = false;
            this.btnBuscarEmpleado.Click += new System.EventHandler(this.btnBuscarEmpleado_Click);
            // 
            // cmBoxBuscarTipoEmpleado
            // 
            this.cmBoxBuscarTipoEmpleado.FormattingEnabled = true;
            this.cmBoxBuscarTipoEmpleado.Location = new System.Drawing.Point(213, 19);
            this.cmBoxBuscarTipoEmpleado.Name = "cmBoxBuscarTipoEmpleado";
            this.cmBoxBuscarTipoEmpleado.Size = new System.Drawing.Size(175, 21);
            this.cmBoxBuscarTipoEmpleado.TabIndex = 1;
            // 
            // txtBuscarEmpleado
            // 
            this.txtBuscarEmpleado.Location = new System.Drawing.Point(17, 20);
            this.txtBuscarEmpleado.Name = "txtBuscarEmpleado";
            this.txtBuscarEmpleado.Size = new System.Drawing.Size(172, 20);
            this.txtBuscarEmpleado.TabIndex = 0;
            // 
            // buscarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "buscarEmpleado";
            this.Size = new System.Drawing.Size(582, 488);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuscarEmpleado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewBuscarEmpleado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscarEmpleado;
        private System.Windows.Forms.ComboBox cmBoxBuscarTipoEmpleado;
        private System.Windows.Forms.TextBox txtBuscarEmpleado;

    }
}
