using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Utilitarios.Enumeradores;

namespace Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public EnumEstado Estado { get; set; }

        public List<Perfil> Perfiles { get; set; }

        public Persona Persona { get; set; }
        public Usuario()
        {
            Perfiles = new List<Perfil>();
        }

        public void agregarPerfil(Perfil perfil)
        {
            foreach (Perfil item in Perfiles)
            {
                if (item.Id == perfil.Id) return;
            }
            Perfiles.Add(perfil);

        }

        public String getPerfiles()
        {
            String _perfiles = "";
            foreach (Perfil item in Perfiles)
            {
                _perfiles += item.Descripcion + ", ";
            }
            return _perfiles;
        }
    }
}
