using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Utilitarios.Enumeradores;

namespace Entidades
{
    public class Prestamo
    {
        public int Id { get; set; }
        public Persona Persona { get; set; }
        public DateTime Fecha { get; set; }
        public Double Monto { get; set; }
        public Double Interes { get; set; }
        public Double MontoAPagar { get; set; }
        public EnumEstadoPrestamo Estado { get; set; }
        public List<Cuota> Cuotas { get; set; }
        public int CantidadCuotas { get; set; }
        public Prestamo()
        {
            Cuotas = new List<Cuota>();
        }

        public void crearCuotas(int cantidad, Double total, DateTime fecha)
        {
            Cuotas = new List<Cuota>();
            //DateTime temp = new DateTime(fecha.Year,fecha.Month,1);            
            for (int i = 0; i < cantidad; i++)
            {
                Cuota c = new Cuota();
                
                c.Monto = total / cantidad;
                c.FechaCobro = fecha.AddMonths(i).Date;
                Cuotas.Add(c);
            }
        }

        public List<Cuota> obtenerCuotasPendientes()
        {
            List<Cuota> retorno = new List<Cuota>();
            foreach (Cuota item in Cuotas)
            {
                if(item.Estado.Equals(EnumEstadoCuota.Pendiente)) retorno.Add(item);
            }
            return retorno;
        }
    }
}
