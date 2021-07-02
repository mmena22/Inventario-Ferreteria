using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Utilitarios.Enumeradores;

namespace Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        public string DocumentoPersona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public List<Telefono> Telefonos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public EnumEstadoCivil EstadoCivil { get; set; }
        public EnumGenero Genero { get; set; }

        public List<Prestamo> Prestamos { get; set; }

        public Persona()
        {
            Telefonos = new List<Telefono>();
        }

        public override string ToString()
        {
            return Nombres + " " + Apellidos;
        }

        public bool quitarTelefono(int idx)
        {
            Telefonos.RemoveAt(idx);
            return true;
        }
    }

}
