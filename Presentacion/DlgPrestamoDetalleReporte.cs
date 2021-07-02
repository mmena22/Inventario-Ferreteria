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
    public partial class DlgPrestamoDetalleReporte : Form
    {
        private DataTable dataTable;
        private Prestamo prestamo { get; set; }

        public DlgPrestamoDetalleReporte()
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
            dataTable.Columns.Add(new DataColumn("Monto", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Fecha vencimiento", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Fecha de pago", typeof(string)));            
            dataTable.Columns.Add(new DataColumn("Estado", typeof(string)));
            dgvLista.DataSource = dataTable;

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

        

        public void asignarPrestamo(Prestamo prestamo)
        {
            this.prestamo = prestamo;
            inicializar();
        }

        

        private void DlgBuscarCliente_Load(object sender, EventArgs e)
        {
          
        }


        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

    }
}
