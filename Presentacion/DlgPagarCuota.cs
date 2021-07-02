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
    public partial class DlgPagarCuota : Form
    {
        public Cuota cuota { get; set; }

        public DlgPagarCuota()
        {
            InitializeComponent();
        }

        public void inicializar(Cuota cuota)
        {
            this.cuota = cuota;
            dtpFecha.Value = DateTime.Now;
        }

        private void guardar()
        {
            try
            {
                cuota.FechaPago = dtpFecha.Value;
                cuota.Estado = EnumEstadoCuota.Pagado;
                bool exito = LogicaPrestamo.PagarCuota(cuota);
                if (exito)
                {
                    this.Dispose();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
       

        private void DlgBuscarCliente_Load(object sender, EventArgs e)
        {
            
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
