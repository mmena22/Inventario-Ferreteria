using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Enumeradores
    {
        public enum EnumEstadoCivil
        {
            Ninguno = 0,
            Soltero = 1,
            Casado = 2,
            Divorciado = 3,
            UnionLibre = 4,
            Viudo = 5
        }

        public enum EnumGenero
        {
            Ninguno = 0,
            Masculino = 1,
            Femenino = 2,
            SinMencionar = 3
        }

     

        public enum EnumEstado
        {
            Activo = 1,
            Inactivo = 0
        }

   
     
       
        public enum EnumEstadoPrestamo
        {
            Activo = 0,
            Atrasado = 1,
            Finalizado = 2,
            Judicial = 3,
        }


        public enum EnumEstadoCuota
        {
            Pendiente = 0,
            Pagado = 1
        }
    }
}
