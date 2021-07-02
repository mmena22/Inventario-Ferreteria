using System;
using System.Threading;
using System.Net.Mail;
using System.Windows.Forms;

using Utilitarios;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class FrmRecuperarContrasena : Form
    {
        private Configuracion configuracion;

        public FrmRecuperarContrasena()
        {
            InitializeComponent();
            configuracion = LogicaConfiguracion.Obtener();
        }

        private OpcionesEmail opciones(String email, String nombre, String contrasenia,String usuario)
        {
            OpcionesEmail opcionesEmail = new OpcionesEmail(configuracion.EmailHost, configuracion.EmailPort);
            opcionesEmail.To = new MailAddress(email, nombre);

            MailAddress origen = new MailAddress(configuracion.Email, configuracion.NombreFinanciera);            
            opcionesEmail.FromPassword = configuracion.EmailPassword;

            opcionesEmail.Subject = "Recuperar contraseña";
            opcionesEmail.Body = "Hola, "+ nombre + ". Su usuario y contraseña son: "+ usuario+" "+ contrasenia;

            opcionesEmail.From = origen;

            return opcionesEmail;
        }

        private bool validar()
        {
            if (txtEmail.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Debe ingresar un email", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

           

            return true;
        }

        private void enviarCorreo()
        {
            try
            {
                String email = txtEmail.Text;
                Usuario usuario = LogicaUsuario.ExisteUsuarioPorEmail(email);
                if (usuario == null)
                {
                    MessageBox.Show("El email ingresado no se encuentra registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }


                    OpcionesEmail opcionesEmail = opciones(email, usuario.Persona.ToString(), usuario.Password,usuario.NombreUsuario);
                Thread newThread = new Thread(EmailUtil.Enviar);
                newThread.Start(opcionesEmail);
                MessageBox.Show("Se ha enviado un correo con la contraseña al email ingresado.");
                regresar();                
            }
            catch (Exception e)
            {
                                MessageBox.Show(e.Message);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            enviarCorreo();
        }

        private void regresar()
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btnOlvideContrasena_Click(object sender, EventArgs e)
        {
            regresar();
        }
    }
}
