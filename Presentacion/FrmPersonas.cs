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
    public partial class FrmPersonas : Form
    {
        private List<Persona> personas;
        private Persona persona;
        private DataTable dataTable;

        public FrmPersonas()
        {
            InitializeComponent();
        }

        private void inicializar()
        {
            persona = new Persona();
            cboEstadoCivil.DataSource = Enum.GetValues(typeof(EnumEstadoCivil));
            cboGenero.DataSource = Enum.GetValues(typeof(EnumGenero));
            dtpFechaNacimiento.Value = DateTime.Now.AddYears(-20);
            inicializarDataTable();
        }

        private void inicializarDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("#", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Documento", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Nombres", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Genero", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Estado civil", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Fecha nacimiento", typeof(string)));
            dgvLista.DataSource = dataTable;
            dgvLista.Columns.Add(BotonDeColumna("Editar"));
            int tamCol = dgvLista.Columns.Count;
            CambiarAnchoColumna(dgvLista, 0, 40);
            CambiarAnchoColumna(dgvLista, tamCol - 1, 60);
            DesactivarOrdenamientoDGV(dgvLista);
            listar();
        }

        private void listar()
        {
            try
            {
                personas = LogicaPersona.Listar();
                dataTable.Rows.Clear();
                for (int i = 0; i < personas.Count; i++)
                {
                    Persona item = personas[i];
                    dataTable.Rows.Add(
                        i + 1,
                        item.DocumentoPersona,
                        item.ToString(),                        
                        item.Email,
                        item.Genero,
                        item.EstadoCivil,
                        item.FechaNacimiento.ToString(FormatoFecha)
                        );
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void listarTelefonos()

        {
            LstTxtTelefonos.Items.Clear();

            foreach (Telefono item in persona.Telefonos)
            {
                LstTxtTelefonos.Items.Add(item.Numero);
            }
        }

        private void limpiar()
        {
            persona = new Persona();
            txtDocumento.Enabled = true;

            txtDocumento.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            cboEstadoCivil.SelectedIndex = 0;
            cboGenero.SelectedIndex = 0;
            listarTelefonos();
            listar();
        }

        private void quitarTelefono()
        {
            try
            {
                int idx = LstTxtTelefonos.SelectedIndex;
                if (idx >= 0)
                {
                    persona.quitarTelefono(idx);
                }
                listarTelefonos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cargarActualizar(Persona persona)
        {
            try
            {
                this.persona = persona;
                txtDocumento.Text = persona.DocumentoPersona;
                txtNombres.Text = persona.Nombres;
                txtApellidos.Text = persona.Apellidos;
                txtEmail.Text = persona.Email;
                dtpFechaNacimiento.Value = persona.FechaNacimiento;
                cboEstadoCivil.SelectedIndex = (int)persona.EstadoCivil;
                cboGenero.SelectedIndex = (int)persona.Genero;
                this.persona.Telefonos = LogicaPersona.ListarTelefonos(persona);
                listarTelefonos();
                txtDocumento.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


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
                    limpiar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void editar()
        {
            try
            {
                if (Validar() == false) return;

                LlenarPersona();

                
                bool registro = LogicaPersona.actualizar(persona);
                if (registro)
                {
                    limpiar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void procesar()
        {
            if (persona.Id > 0)
            {
                editar();
            }
            else
            {
                guardar();
            }
        }

        private void AgregarNumero()
        {
            try
            {
                if (txtTelefono.Text.Equals(String.Empty)) return;

                Telefono telefono = new Telefono(txtTelefono.Text);
                persona.Telefonos.Add(telefono);
                txtTelefono.Text = "";
                listarTelefonos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            procesar();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            inicializar();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (personas.Count < 1 || e.RowIndex < 0 || e.RowIndex == personas.Count) return;
            if (e.ColumnIndex == 0)
            {
                cargarActualizar(personas[e.RowIndex]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarNumero();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            quitarTelefono();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
