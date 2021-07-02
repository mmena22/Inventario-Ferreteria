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
    
    public partial class FrmReporteUsuarios : Form
    {
        private List<Usuario> usuarios;
        private DataTable dataTable;
        public FrmReporteUsuarios()
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
            dataTable.Columns.Add(new DataColumn("Usuario", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Responsable", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Perfiles", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Estado", typeof(string)));
            dgvLista.DataSource = dataTable;

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
                        (i + 1),
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

        private void FrmReporteUsuarios_Load(object sender, EventArgs e)
        {
            inicializar();
        }
    }

    

}
