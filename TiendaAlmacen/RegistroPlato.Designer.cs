namespace TiendaAlmacen
{
    partial class RegistroPlato
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
            this.components = new System.ComponentModel.Container();
            this.panelRegistroPlato = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cmBoxClasificacion = new System.Windows.Forms.ComboBox();
            this.txtCostoPlato = new System.Windows.Forms.TextBox();
            this.txtNonmrePlato = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewRegistroPlato = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.errorExistePlato = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelRegistroPlato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistroPlato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorExistePlato)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRegistroPlato
            // 
            this.panelRegistroPlato.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelRegistroPlato.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelRegistroPlato.Controls.Add(this.label1);
            this.panelRegistroPlato.Controls.Add(this.btnEliminar);
            this.panelRegistroPlato.Controls.Add(this.btnGuardar);
            this.panelRegistroPlato.Controls.Add(this.cmBoxClasificacion);
            this.panelRegistroPlato.Controls.Add(this.txtCostoPlato);
            this.panelRegistroPlato.Controls.Add(this.txtNonmrePlato);
            this.panelRegistroPlato.Controls.Add(this.label3);
            this.panelRegistroPlato.Controls.Add(this.label2);
            this.panelRegistroPlato.Controls.Add(this.dataGridViewRegistroPlato);
            this.panelRegistroPlato.Location = new System.Drawing.Point(29, 25);
            this.panelRegistroPlato.Name = "panelRegistroPlato";
            this.panelRegistroPlato.Size = new System.Drawing.Size(933, 475);
            this.panelRegistroPlato.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del Plato";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEliminar.Image = global::TiendaAlmacen.Properties.Resources.boton_de_cancelacion_de_icono_7349_48;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(623, 45);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(147, 49);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar ingrediente";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cmBoxClasificacion
            // 
            this.cmBoxClasificacion.FormattingEnabled = true;
            this.cmBoxClasificacion.Location = new System.Drawing.Point(172, 121);
            this.cmBoxClasificacion.Name = "cmBoxClasificacion";
            this.cmBoxClasificacion.Size = new System.Drawing.Size(196, 21);
            this.cmBoxClasificacion.TabIndex = 6;
            // 
            // txtCostoPlato
            // 
            this.txtCostoPlato.Location = new System.Drawing.Point(172, 74);
            this.txtCostoPlato.Name = "txtCostoPlato";
            this.txtCostoPlato.Size = new System.Drawing.Size(76, 20);
            this.txtCostoPlato.TabIndex = 5;
            this.txtCostoPlato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostoPlato_KeyPress);
            // 
            // txtNonmrePlato
            // 
            this.txtNonmrePlato.Location = new System.Drawing.Point(172, 34);
            this.txtNonmrePlato.Name = "txtNonmrePlato";
            this.txtNonmrePlato.Size = new System.Drawing.Size(195, 20);
            this.txtNonmrePlato.TabIndex = 4;
            this.txtNonmrePlato.Leave += new System.EventHandler(this.txtNonmrePlato_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Clasificacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Costo del Plato";
            // 
            // dataGridViewRegistroPlato
            // 
            this.dataGridViewRegistroPlato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRegistroPlato.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRegistroPlato.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewRegistroPlato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegistroPlato.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Codigo,
            this.Cantidad,
            this.Unidad});
            this.dataGridViewRegistroPlato.Location = new System.Drawing.Point(27, 176);
            this.dataGridViewRegistroPlato.Name = "dataGridViewRegistroPlato";
            this.dataGridViewRegistroPlato.Size = new System.Drawing.Size(884, 277);
            this.dataGridViewRegistroPlato.TabIndex = 0;
            this.dataGridViewRegistroPlato.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRegistroPlato_CellValueChanged);
            this.dataGridViewRegistroPlato.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewRegistroPlato_EditingControlShowing);
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo Producto";
            this.Codigo.Name = "Codigo";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Unidad
            // 
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            // 
            // errorExistePlato
            // 
            this.errorExistePlato.ContainerControl = this;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGuardar.Image = global::TiendaAlmacen.Properties.Resources.descarga__1_1;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(460, 45);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(105, 49);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // RegistroPlato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRegistroPlato);
            this.Name = "RegistroPlato";
            this.Size = new System.Drawing.Size(945, 515);
            this.panelRegistroPlato.ResumeLayout(false);
            this.panelRegistroPlato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistroPlato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorExistePlato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRegistroPlato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmBoxClasificacion;
        private System.Windows.Forms.TextBox txtCostoPlato;
        private System.Windows.Forms.TextBox txtNonmrePlato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewRegistroPlato;
        private System.Windows.Forms.DataGridViewComboBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewComboBoxColumn Unidad;
        private System.Windows.Forms.ErrorProvider errorExistePlato;
    }
}
