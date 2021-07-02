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
    public partial class FrmPrestamos : Form
    {
        private Persona persona=null;
        private Prestamo prestamo;

        private DataTable dataTableCuotas;

        private DataTable dataTable;
        private List<Prestamo> prestamos = new List<Prestamo>();

        public FrmPrestamos()
        {
            InitializeComponent();
        }

        private void inicializar()
        {
            prestamo = new Prestamo();
            inicializarDataTable();
            inicializarDataTableCuotas();
            CalcularCoutas();
            dtpFecha.Value = DateTime.Now;
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
            dgvLista.Columns.Add(BotonDeColumna("Ver"));
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
                dataTable.Rows.Clear();
                prestamos = LogicaPrestamo.listar();
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

        private void inicializarDataTableCuotas()
        {
            dataTableCuotas = new DataTable();
            dataTableCuotas.Columns.Add(new DataColumn("#", typeof(string)));
            dataTableCuotas.Columns.Add(new DataColumn("Monto", typeof(string)));
            dataTableCuotas.Columns.Add(new DataColumn("Fecha pago", typeof(string)));
            dgvListaHoras.DataSource = dataTableCuotas;          
            DesactivarOrdenamientoDGV(dgvListaHoras);
            listarCuotas();
        }

        private void listarCuotas()
        {
            try
            {

                dataTableCuotas.Rows.Clear();
                for (int i = 0; i < prestamo.Cuotas.Count; i++)
                {
                    Cuota item = prestamo.Cuotas[i];
                    dataTableCuotas.Rows.Add(
                        i + 1,
                        item.Monto.ToString(FormatoMonto),
                        item.FechaCobro.ToString(FormatoFecha)
                        );
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void BuscarPersona()
        {
            DlgBuscarPersona dialog = new DlgBuscarPersona();
            dialog.ShowDialog();            
            if (dialog.persona != null)
            {
                persona = dialog.persona;
                txtPersona.Text = persona.ToString();
            }
        }

        private void CalcularCoutas()
        {
            try
            {
                dtpFechaPrimeraCuota.MinDate = new DateTime(dtpFecha.Value.Year, dtpFecha.Value.AddMonths(1).Month, 1);

                int cantidad = (int)spiCuotas.Value;
                double monto = (double)spiMonto.Value;
                double interes = (double)spiInteres.Value;
                double final = monto + monto * (interes / 100);

                prestamo.CantidadCuotas = cantidad;
                prestamo.Monto = monto;
                prestamo.Interes = interes;
                prestamo.MontoAPagar = final;
                prestamo.Fecha = dtpFecha.Value;

                DateTime fecha = dtpFechaPrimeraCuota.Value;
                txtMontoTotal.Text = final.ToString(FormatoMonto);
                prestamo.crearCuotas(cantidad, final, fecha);
                listarCuotas();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private bool validar()
        {
            if (persona == null)
            {
                MessageBox.Show("Debe seleccionar una persona.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnBuscar.Focus();
                return false;
            }

            if (((double)spiMonto.Value)<=0)
            {
                MessageBox.Show("Debe seleccionar un monto mayor a 0.00", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spiMonto.Focus();
                return false;
            }

            return true;
        }

        private void guardar()
        {
            try
            {
                if (validar() == false) return;
                prestamo.Persona = persona;
                bool exito = LogicaPrestamo.registrar(prestamo);
                if (exito)
                {
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Hubo un error al registrar.");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Limpiar()
        {
            persona = null;
            txtPersona.Text = String.Empty;
            prestamo = new Prestamo();
            spiMonto.Value = 0;
            spiCuotas.Value = 1;
            spiInteres.Value = 0;
            listar();
            listarCuotas();
        }

        private void cargarDetalle(Prestamo prestamo)
        {
            DlgPrestamoDetalle dialog = new DlgPrestamoDetalle();
            dialog.asignarPrestamo(prestamo);
            dialog.ShowDialog();
            listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPersona();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void FrmPrestamos_Load(object sender, EventArgs e)
        {
            inicializar();
        }

        private void spiCuotas_ValueChanged(object sender, EventArgs e)
        {
            CalcularCoutas();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            
            CalcularCoutas();
        }

        private void spiMonto_ValueChanged(object sender, EventArgs e)
        {
            CalcularCoutas();
        }

        private void spiInteres_ValueChanged(object sender, EventArgs e)
        {
            CalcularCoutas();
        }

        private void stpFechaPrimeraCuota_ValueChanged(object sender, EventArgs e)
        {
            CalcularCoutas();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (prestamos.Count < 1 || e.RowIndex < 0 || e.RowIndex >= prestamos.Count) return;
            if (e.ColumnIndex == 0)
            {
                cargarDetalle(prestamos[e.RowIndex]);
            }
        }
    }
}
