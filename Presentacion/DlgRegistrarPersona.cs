using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocio;
using Entidades;
using static Utilitarios.Enumeradores;
using static Utilitarios.Componentes;
using static Utilitarios.Formatos;

namespace Presentacion
{
    public partial class DlgRegistrarPersona : Form
    {
        public Persona persona { get; set; }
        public DlgRegistrarPersona()
        {
            InitializeComponent();
        }

        private void inicializar()
        {
            persona = new Persona();
            cboEstadoCivil.DataSource = Enum.GetValues(typeof(EnumEstadoCivil));
            cboGenero.DataSource = Enum.GetValues(typeof(EnumGenero));
            dtpFechaNacimiento.Value = DateTime.Now.AddYears(-20);
           
        }

        private bool Validar()
        {
            if (txtDocumento.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe indicar documento de identidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return false;

            }

            if (txtNombres.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar los nombres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return false;
            }

            if (txtApellidos.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar los apellidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return false;
            }

            if (cboGenero.SelectedIndex == 0)
            {
                MessageBox.Show("Debe indicar el género", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGenero.Focus();
                return false;
            }

            if (cboEstadoCivil.SelectedIndex == 0)
            {
                MessageBox.Show("Debe indicar el estado civil", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEstadoCivil.Focus();
                return false;
            }

            return true;
        }

        private void LlenarPersona()
        {
            persona.DocumentoPersona = txtDocumento.Text;
            persona.Nombres = txtNombres.Text;
            persona.Apellidos = txtApellidos.Text;
            persona.Email = txtEmail.Text;
            persona.Genero = (EnumGenero)cboGenero.SelectedValue;
            persona.FechaNacimiento = dtpFechaNacimiento.Value;
            persona.EstadoCivil = (EnumEstadoCivil)cboEstadoCivil.SelectedValue;

        }

        private void guardar()
        {
            try
            {
                if (Validar() == false) return;

                LlenarPersona();

                if (LogicaPersona.ExistePersona(persona) != null)
                {
                    MessageBox.Show("El documento de identidad ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDocumento.Focus();
                    return;
                }

                bool registro = LogicaPersona.registrar(persona);
                if (registro)
                {
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void DlgRegistrarPersona_Load(object sender, EventArgs e)
        {
            inicializar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
