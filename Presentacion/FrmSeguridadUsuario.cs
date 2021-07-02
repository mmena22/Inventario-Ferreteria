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
    public partial class FrmSeguridadUsuario : Form
    {
        private Persona persona = null;
        private Usuario usuario;
        private List<Usuario> usuarios;
        private DataTable dataTable;

        public FrmSeguridadUsuario()
        {
            InitializeComponent();
        }

        private void inicializar()
        {
            usuario = new Usuario();
            cboEstado.DataSource = Enum.GetValues(typeof(EnumEstado));
            cboEstado.SelectedIndex = 1;
            inicializarDataTable();
            llenarPerfiles();
        }

        private void llenarPerfiles()
        {
            cboPerfil.Items.Clear();
            List<Perfil> perfiles = LogicaPerfil.ListarPerfiles();
            foreach (Perfil item in perfiles)
            {
                cboPerfil.Items.Add(item);
            }
            cboPerfil.SelectedIndex = 0;

        }

        private void inicializarDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("#", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Usuario", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Responsable", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Perfiles", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Estado", typeof(string)));
            dgvLista.DataSource = dataTable;
            dgvLista.Columns.Add(BotonDeColumna("ver/editar"));

            CambiarAnchoColumna(dgvLista, 2, 300);
            CambiarAnchoColumna(dgvLista, 3, 300);
            DesactivarOrdenamientoDGV(dgvLista);
            listar();
        }

        private void listar()
        {
            try
            {
                dataTable.Rows.Clear();
                usuarios = LogicaUsuario.Listar();
                for (int i = 0; i < usuarios.Count; i++)
                {
                    Usuario item = usuarios[i];
                    dataTable.Rows.Add(
                        (i+1),
                            item.NombreUsuario,
                            item.Persona.ToString(),
                            item.getPerfiles(),
                            item.Estado
                            );
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

        }



        private void BuscarPersona()
        {
            DlgBuscarPersona dialog = new DlgBuscarPersona();
            dialog.ShowDialog();
            if (dialog.persona != null)
            {
                if (LogicaUsuario.ExisteUsuarioPorPersona(dialog.persona)!=null)
                {
                    MessageBox.Show("La persona responsable seleccionada ya tiene un usuario asignado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnBuscar.Focus();
                    return;
                }

                persona = dialog.persona;
                txtPersona.Text = persona.ToString();
            }
        }

        private Boolean validarGuardar()
        {
            if (persona==null&&usuario.Id==0)
            {
                MessageBox.Show("Debe seleccionar una persona responsable.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnBuscar.Focus();
                return false;
            }

            if (txtNombreUsuario.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }

            if (txtPassword.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe ingresar una contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (cboPerfil.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un perfil.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void limpiar()
        {
            usuario = new Usuario();
            persona = null;
            btnBuscar.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtPersona.Text = "";
            txtNombreUsuario.Text = "";
            txtPassword.Text = "";
            listar();
        }

        private void registrar()
        {
            try
            {
                if (validarGuardar() == false) return;
                usuario.Persona = persona;
                usuario.NombreUsuario = txtNombreUsuario.Text;
                usuario.Password = txtPassword.Text;              
                usuario.Estado = (EnumEstado)cboEstado.SelectedItem;
                usuario.agregarPerfil((Perfil)cboPerfil.SelectedItem);

                if (LogicaUsuario.ExisteUsuario(usuario) != null)
                {
                    MessageBox.Show("El nombre usuario ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreUsuario.Focus();
                    return;
                }

                bool exito = LogicaUsuario.registrar(usuario);
                if (exito)
                {
                    limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void cargarActualizar(Usuario usuario)
        {
            try
            {
                btnBuscar.Enabled = false;
                txtNombreUsuario.Enabled = false;

                this.usuario = usuario;                
                txtNombreUsuario.Text = usuario.NombreUsuario;
                txtPassword.Text = usuario.Password;
                txtPersona.Text = usuario.Persona.ToString();
                cboEstado.SelectedItem = usuario.Estado;                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void actualizar()
        {
            try
            {
                if (validarGuardar() == false) return;
                
                usuario.Password = txtPassword.Text;
                usuario.Estado = (EnumEstado)cboEstado.SelectedItem;               
                usuario.agregarPerfil((Perfil)cboPerfil.SelectedItem);
                
                bool exito = LogicaUsuario.actualizar(usuario);
                if (exito)
                {
                    limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            BuscarPersona();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPersona();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            inicializar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (usuario.Id>0) actualizar();
            else registrar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (usuarios.Count < 1 || e.RowIndex < 0 || e.RowIndex == usuarios.Count) return;
            if (e.ColumnIndex == 0)
            {
                cargarActualizar(usuarios[e.RowIndex]);
            }
        }
    }
}
