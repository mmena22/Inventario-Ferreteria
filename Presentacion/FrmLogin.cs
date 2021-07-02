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
using Negocio;

namespace Presentacion
{
    public partial class FrmLogin : Form

    {
        public FrmLogin()
        {
            InitializeComponent();
            //txtUsuario.Text = "admin";
            //txtClave.Text = "123";

           
        }


        private void iniciar()
        {
            try
            {
                Usuario u = new Usuario();

                u.NombreUsuario = txtUsuario.Text.Trim();
                u.Password = txtClave.Text.Trim();

                Usuario objusuario = LogicaUsuario.VerificarAcceso(u);

                if (objusuario != null)
                {
                    FrmMenu frm = new FrmMenu();

                    frm.usuario = objusuario;
                    frm.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Usuario y/o contraseña incorrectas");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOlvideContrasena_Click(object sender, EventArgs e)
        {
            FrmRecuperarContrasena frmRecuperarContrasena = new FrmRecuperarContrasena();
            frmRecuperarContrasena.Show();
            this.Hide();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            iniciar();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
