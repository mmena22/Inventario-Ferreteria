using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perfil
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public Perfil(int Id, string Descripcion)
        {
            this.Id = Id;
            this.Descripcion = Descripcion;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
