namespace TiendaAlmacen
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.paneContenedor = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.productoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarNuevoProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroIngresoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarEliminarProduccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPlatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.paneContenedor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 562);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // paneContenedor
            // 
            this.paneContenedor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.paneContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneContenedor.Location = new System.Drawing.Point(3, 32);
            this.paneContenedor.Name = "paneContenedor";
            this.paneContenedor.Size = new System.Drawing.Size(778, 527);
            this.paneContenedor.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(778, 23);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productoToolStripMenuItem,
            this.ingresoToolStripMenuItem,
            this.salidasToolStripMenuItem,
            this.mnuUser,
            this.empleadosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 23);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // productoToolStripMenuItem
            // 
            this.productoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarNuevoProductoToolStripMenuItem,
            this.buscarProductoToolStripMenuItem});
            this.productoToolStripMenuItem.Name = "productoToolStripMenuItem";
            this.productoToolStripMenuItem.Size = new System.Drawing.Size(68, 19);
            this.productoToolStripMenuItem.Text = "Producto";
            // 
            // ingresarNuevoProductoToolStripMenuItem
            // 
            this.ingresarNuevoProductoToolStripMenuItem.Name = "ingresarNuevoProductoToolStripMenuItem";
            this.ingresarNuevoProductoToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.ingresarNuevoProductoToolStripMenuItem.Text = "Ingresar Nuevo Producto";
            this.ingresarNuevoProductoToolStripMenuItem.Click += new System.EventHandler(this.ingresarNuevoProductoToolStripMenuItem_Click_1);
            // 
            // buscarProductoToolStripMenuItem
            // 
            this.buscarProductoToolStripMenuItem.Name = "buscarProductoToolStripMenuItem";
            this.buscarProductoToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.buscarProductoToolStripMenuItem.Text = "Buscar Producto";
            this.buscarProductoToolStripMenuItem.Click += new System.EventHandler(this.buscarProductoToolStripMenuItem_Click_1);
            // 
            // ingresoToolStripMenuItem
            // 
            this.ingresoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroIngresoToolStripMenuItem});
            this.ingresoToolStripMenuItem.Name = "ingresoToolStripMenuItem";
            this.ingresoToolStripMenuItem.Size = new System.Drawing.Size(58, 19);
            this.ingresoToolStripMenuItem.Text = "Ingreso";
            // 
            // registroIngresoToolStripMenuItem
            // 
            this.registroIngresoToolStripMenuItem.Name = "registroIngresoToolStripMenuItem";
            this.registroIngresoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.registroIngresoToolStripMenuItem.Text = "Registro Ingreso";
            this.registroIngresoToolStripMenuItem.Click += new System.EventHandler(this.registroIngresoToolStripMenuItem_Click_1);
            // 
            // salidasToolStripMenuItem
            // 
            this.salidasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produccionToolStripMenuItem,
            this.buscarEliminarProduccionToolStripMenuItem,
            this.buscarPlatoToolStripMenuItem});
            this.salidasToolStripMenuItem.Name = "salidasToolStripMenuItem";
            this.salidasToolStripMenuItem.Size = new System.Drawing.Size(46, 19);
            this.salidasToolStripMenuItem.Text = "Plato";
            // 
            // produccionToolStripMenuItem
            // 
            this.produccionToolStripMenuItem.Name = "produccionToolStripMenuItem";
            this.produccionToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.produccionToolStripMenuItem.Text = "Produccion";
            this.produccionToolStripMenuItem.Click += new System.EventHandler(this.produccionToolStripMenuItem_Click_1);
            // 
            // buscarEliminarProduccionToolStripMenuItem
            // 
            this.buscarEliminarProduccionToolStripMenuItem.Name = "buscarEliminarProduccionToolStripMenuItem";
            this.buscarEliminarProduccionToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.buscarEliminarProduccionToolStripMenuItem.Text = "Buscar - Eliminar produccion";
            this.buscarEliminarProduccionToolStripMenuItem.Click += new System.EventHandler(this.buscarEliminarProduccionToolStripMenuItem_Click_1);
            // 
            // mnuUser
            // 
            this.mnuUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuUser.Enabled = false;
            this.mnuUser.Name = "mnuUser";
            this.mnuUser.Size = new System.Drawing.Size(42, 19);
            this.mnuUser.Text = "User";
            // 
            // buscarPlatoToolStripMenuItem
            // 
            this.buscarPlatoToolStripMenuItem.Name = "buscarPlatoToolStripMenuItem";
            this.buscarPlatoToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.buscarPlatoToolStripMenuItem.Text = "Buscar plato";
            this.buscarPlatoToolStripMenuItem.Click += new System.EventHandler(this.buscarPlatoToolStripMenuItem_Click);
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarEmpleadosToolStripMenuItem});
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(77, 19);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            // 
            // buscarEmpleadosToolStripMenuItem
            // 
            this.buscarEmpleadosToolStripMenuItem.Name = "buscarEmpleadosToolStripMenuItem";
            this.buscarEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.buscarEmpleadosToolStripMenuItem.Text = "Buscar empleados";
            this.buscarEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.buscarEmpleadosToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cypa Venta de comida";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel paneContenedor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem productoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarNuevoProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroIngresoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarEliminarProduccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUser;
        private System.Windows.Forms.ToolStripMenuItem buscarPlatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarEmpleadosToolStripMenuItem;

    }
}

