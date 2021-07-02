using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Telefono
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public bool Estado { get; set; }

        public Telefono()
        {

        }

        public Telefono(string Numero)
        {
            this.Numero = Numero;
        }

        public override string ToString()
        {
            return Numero;
        }
    }
}
