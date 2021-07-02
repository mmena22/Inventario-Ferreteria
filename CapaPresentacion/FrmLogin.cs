using CapaNegocio;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        //Metodo Ingresar.
        private void Ingresar()
        {
            DataTable Datos = Ntrabajador.Login(txtUsuario.Text, txtPassword.Text);

            if (Datos == null)
            {
                MessageBox.Show("Usuario y/o contraseña invalido", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmPrincipal frm = new FrmPrincipal();
                frm.idTrabajador = Datos.Rows[0][0].ToString();
                frm.apellido = Datos.Rows[0][1].ToString();
                frm.nombre = Datos.Rows[0][2].ToString();
                frm.acceso = Datos.Rows[0][3].ToString();
                frm.Show();
                Hide();
            }
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, System.EventArgs e)
        {

            if (lbl_Captcha.Text == txt_Captcha.Text)
            {
                MessageBox.Show("Usted no es un bot", "Validado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Ingresar();
            }
            else
            {
                MessageBox.Show("Usted podria ser un bot, reintente", "Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.OnLoad(e);
            }

        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Ingresar();
            }
        }

        private void FrmLogin_Load(object sender, System.EventArgs e)
        {
            #region Metodo del captcha
            Random rand = new Random();
                int iColor = rand.Next(0, 255);
                int iColor2 = rand.Next(0, 255);
                int iColor3 = rand.Next(0, 255);
                int iNum = rand.Next(7, 9);
                string sCaptcha = "";
                int iTotal = 0;
                do
                {
                    int chr = rand.Next(48, 123);
                    if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                    {
                        sCaptcha = sCaptcha + (char)chr;
                        iTotal++;
                        if (iTotal == iNum)
                            break;
                        {

                        }
                    }
                }
                while (true);
                lbl_Captcha.ForeColor = Color.FromArgb(iColor, iColor2, iColor3);
                lbl_Captcha.Text = sCaptcha;

            #endregion
        }
    }
}
