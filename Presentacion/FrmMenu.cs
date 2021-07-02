using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace Presentacion
{
    public partial class FrmMenu : Form
    {
        public Usuario usuario { get; set; }
        public FrmMenu()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Ferreteria1.jpeg");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void cerrarSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonas frm = new FrmPersonas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void préstamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrestamos frm = new FrmPrestamos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeguridadUsuario frm = new FrmSeguridadUsuario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuiListaUsuarios_Click(object sender, EventArgs e)
        {
            FrmReporteUsuarios frm = new FrmReporteUsuarios();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuiListaClientes_Click(object sender, EventArgs e)
        {
            FrmReporteClientes frm = new FrmReporteClientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuiListaPrestamos_Click(object sender, EventArgs e)
        {
            FrmReportePrestamos frm = new FrmReportePrestamos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
