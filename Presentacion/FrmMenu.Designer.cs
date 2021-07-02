namespace Presentacion
{
    partial class FrmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuiCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiPrestamos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiListaUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiListaClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuiCerrar,
            this.mnuiClientes,
            this.mnuiPrestamos,
            this.mnuiUsuarios,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuiCerrar
            // 
            this.mnuiCerrar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSistemaToolStripMenuItem});
            this.mnuiCerrar.Name = "mnuiCerrar";
            this.mnuiCerrar.Size = new System.Drawing.Size(60, 20);
            this.mnuiCerrar.Text = "Sistema";
            // 
            // cerrarSistemaToolStripMenuItem
            // 
            this.cerrarSistemaToolStripMenuItem.Name = "cerrarSistemaToolStripMenuItem";
            this.cerrarSistemaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarSistemaToolStripMenuItem.Text = "Cerrar sistema";
            this.cerrarSistemaToolStripMenuItem.Click += new System.EventHandler(this.cerrarSistemaToolStripMenuItem_Click);
            // 
            // mnuiClientes
            // 
            this.mnuiClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem});
            this.mnuiClientes.Name = "mnuiClientes";
            this.mnuiClientes.Size = new System.Drawing.Size(101, 20);
            this.mnuiClientes.Text = "Mantenimiento";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // mnuiPrestamos
            // 
            this.mnuiPrestamos.Name = "mnuiPrestamos";
            this.mnuiPrestamos.Size = new System.Drawing.Size(66, 20);
            this.mnuiPrestamos.Text = "Procesos";
            // 
            // mnuiUsuarios
            // 
            this.mnuiUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem});
            this.mnuiUsuarios.Name = "mnuiUsuarios";
            this.mnuiUsuarios.Size = new System.Drawing.Size(72, 20);
            this.mnuiUsuarios.Text = "Seguridad";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuiListaUsuarios,
            this.mnuiListaClientes});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // mnuiListaUsuarios
            // 
            this.mnuiListaUsuarios.Name = "mnuiListaUsuarios";
            this.mnuiListaUsuarios.Size = new System.Drawing.Size(180, 22);
            this.mnuiListaUsuarios.Text = "Lista usuarios";
            this.mnuiListaUsuarios.Click += new System.EventHandler(this.mnuiListaUsuarios_Click);
            // 
            // mnuiListaClientes
            // 
            this.mnuiListaClientes.Name = "mnuiListaClientes";
            this.mnuiListaClientes.Size = new System.Drawing.Size(180, 22);
            this.mnuiListaClientes.Text = "Lista clientes";
            this.mnuiListaClientes.Click += new System.EventHandler(this.mnuiListaClientes_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "Usuario conectado:";
            // 
            // tsslUsuario
            // 
            this.tsslUsuario.Name = "tsslUsuario";
            this.tsslUsuario.Size = new System.Drawing.Size(54, 17);
            this.tsslUsuario.Text = "(usuario)";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem mnuiCerrar;
        private System.Windows.Forms.ToolStripMenuItem cerrarSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuiClientes;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuiPrestamos;
        private System.Windows.Forms.ToolStripMenuItem mnuiUsuarios;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuiListaUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuiListaClientes;
        private System.Windows.Forms.ToolStripStatusLabel tsslUsuario;
    }
}