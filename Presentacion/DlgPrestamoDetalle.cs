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
using static Utilitarios.Enumeradores;

namespace Presentacion
{
    public partial class DlgPrestamoDetalle : Form
    {
        private DataTable dataTable;
        private Prestamo prestamo { get; set; }

        public DlgPrestamoDetalle()
        {
            InitializeComponent();
        }

        private void inicializar()
        {
            cboEstado.DataSource = Enum.GetValues(typeof(EnumEstadoPrestamo));
            inicializarDataTable();
            if (prestamo.Estado.Equals(EnumEstadoPrestamo.Finalizado))
            {
                cboEstado.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void inicializarDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("#", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Monto", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Fecha vencimiento", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Fecha de pago", typeof(string)));            
            dataTable.Columns.Add(new DataColumn("Estado", typeof(string)));
            dgvLista.DataSource = dataTable;
            dgvLista.Columns.Add(BotonDeColumna("Pagar"));

            int tamCol = dgvLista.Columns.Count;
            CambiarAnchoColumna(dgvLista, tamCol - 1, 60);
            DesactivarOrdenamientoDGV(dgvLista);
            listar();
        }

        private void listar()
        {
            try
            {

                dataTable.Rows.Clear();
                prestamo.Cuotas = LogicaPrestamo.ListarDetalle(prestamo);
                for (int i = 0; i < prestamo.Cuotas.Count; i++)
                {
                    Cuota item = prestamo.Cuotas[i];
                    dataTable.Rows.Add(
                        i + 1,
                        item.Monto.ToString(FormatoMonto),
                        item.FechaCobro.ToString(FormatoFecha),
                        item.FechaPago.Equals(DateTime.MinValue)?"" : item.FechaPago.ToString(FormatoFecha),                        
                        item.Estado
                        );
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void seleccionar(Cuota cuota)
        {
            try
            {
                if (cuota.FechaPago.Equals(DateTime.MinValue))
                {
                    DlgPagarCuota dialog = new DlgPagarCuota();
                    dialog.inicializar(cuota);
                    _ = dialog.ShowDialog();
                    listar();
                }
                else
                {
                    MessageBox.Show("Esta cuota ya está pagada.");
                }

                
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public void asignarPrestamo(Prestamo prestamo)
        {
            this.prestamo = prestamo;
            inicializar();
            cboEstado.SelectedItem = prestamo.Estado;
        }

        private void guardar()
        {
            try
            {
               bool exito = LogicaPrestamo.CambiarEstadoPrestamo(prestamo,(EnumEstadoPrestamo)cboEstado.SelectedItem);
                if (exito) this.Dispose();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private void DlgBuscarCliente_Load(object sender, EventArgs e)
        {
          
        }


        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (prestamo.Cuotas.Count < 1 || e.RowIndex < 0 || e.RowIndex >= prestamo.Cuotas.Count) return;
            if (e.ColumnIndex == 0)
            {
                seleccionar(prestamo.Cuotas[e.RowIndex]);
            }
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
