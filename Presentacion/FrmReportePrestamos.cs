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
    
    public partial class FrmReportePrestamos : Form
    {
        private DataTable dataTable;
        private List<Prestamo> prestamos = new List<Prestamo>();
        public FrmReportePrestamos()
        {
            InitializeComponent();
        }

        private void inicializar()
        {
            inicializarDataTable();
            cboEstado.DataSource = Enum.GetValues(typeof(EnumEstadoPrestamo));
        }

        private void inicializarDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("#", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Cliente", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Fecha", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Monto", typeof(string)));
            dataTable.Columns.Add(new DataColumn("% Interés", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Monto a pagar", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Cuotas", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Estado", typeof(string)));
            dgvLista.DataSource = dataTable;
            dgvLista.Columns.Add(BotonDeColumna("Ver detalle"));
            int tamCol = dgvLista.Columns.Count;
            CambiarAnchoColumna(dgvLista, 0, 40);
            CambiarAnchoColumna(dgvLista, tamCol - 1, 80);
            DesactivarOrdenamientoDGV(dgvLista);
            listar();
        }

        private void listar()
        {
            try
            {
                dataTable.Rows.Clear();
                if (tabControl1.SelectedIndex == 0)
                {
                    prestamos = LogicaPrestamo.filtrar(txtDocumento.Text, -1);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    EnumEstadoPrestamo estado = (EnumEstadoPrestamo)cboEstado.SelectedItem;
                    prestamos = LogicaPrestamo.filtrar("", (int)estado);
                }


                for (int i = 0; i < prestamos.Count; i++)
                {
                    Prestamo item = prestamos[i];
                    dataTable.Rows.Add(
                        i + 1,
                        item.Persona,
                        item.Fecha.ToString(FormatoFecha),
                        item.Monto.ToString(FormatoMonto),
                        item.Interes.ToString(FormatoMonto),
                        item.MontoAPagar.ToString(FormatoMonto),
                        item.CantidadCuotas,
                        item.Estado
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cargarDetalle(Prestamo prestamo)
        {
            DlgPrestamoDetalleReporte dialog = new DlgPrestamoDetalleReporte();
            dialog.asignarPrestamo(prestamo);
            dialog.ShowDialog();            
        }

        private void FrmReporteClientes_Load(object sender, EventArgs e)
        {
            inicializar();
        }

        private void txtDocumento_Enter(object sender, EventArgs e)
        {
            txtDocumento.SelectAll();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            listar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            listar();
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (prestamos.Count < 1 || e.RowIndex < 0 || e.RowIndex >= prestamos.Count) return;
            if (e.ColumnIndex == 0)
            {
                cargarDetalle(prestamos[e.RowIndex]);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDocumento.Text = "";
            listar();
        }
    }

    

}
