using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilitarios.Enumeradores;
namespace Entidades
{
    public class Cuota
    {
        public int Id { get; set; }
        public DateTime FechaCobro { get; set; }
        public DateTime FechaPago { get; set; }
        public Double Monto { get; set; }

        public EnumEstadoCuota Estado { get; set; }
    }
}
