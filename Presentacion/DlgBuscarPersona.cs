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
using static Utilitarios.Formatos;
using static Utilitarios.Componentes;

namespace Presentacion
{
    public partial class DlgBuscarPersona : Form
    {
        private List<Persona> personas;
        private DataTable dataTable;
        public Persona persona { get; set; }

        public DlgBuscarPersona()
        {
            InitializeComponent();
        }

        private void inicializar()
        {           
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
            dgvLista.Columns.Add(BotonDeColumna("Seleccionar"));

            int tamCol = dgvLista.Columns.Count;
            CambiarAnchoColumna(dgvLista, tamCol - 1, 100);
            DesactivarOrdenamientoDGV(dgvLista);
            buscar();
        }

        private void buscar()
        {
            try
            {

                personas = LogicaPersona.Buscar(txtBucar.Text);
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

        private void seleccionar(Persona persona)
        {
            this.persona = persona;
            this.Dispose();
            
        }

        private void DlgBuscarCliente_Load(object sender, EventArgs e)
        {
            inicializar();
        }

        private void txtBucar_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (personas.Count < 1 || e.RowIndex < 0 || e.RowIndex >= personas.Count) return;
            if (e.ColumnIndex == 7)
            {
                seleccionar(personas[e.RowIndex]);
            }

           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DlgRegistrarPersona dlg = new DlgRegistrarPersona();
            dlg.ShowDialog();
            if (dlg.persona != null)
            {
                txtBucar.Text = dlg.persona.DocumentoPersona;
                buscar();
            }
        }
    }
}
