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
    
    public partial class FrmReporteClientes : Form
    {
        private List<Persona> personas;
        private DataTable dataTable;
        public FrmReporteClientes()
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
            

            int tamCol = dgvLista.Columns.Count;
            DesactivarOrdenamientoDGV(dgvLista);
            buscar();
        }

        private void buscar()
        {
            try
            {

                personas = LogicaPersona.Buscar("");
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

        private void FrmReporteClientes_Load(object sender, EventArgs e)
        {
            inicializar();
        }
    }

    

}
