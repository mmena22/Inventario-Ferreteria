using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Configuracion
    {
        public int Id { get; set; }
        public string NombreFinanciera { get; set; }
        public string Email { get; set; }
        public string EmailPassword { get; set; }
        public string EmailHost { get; set; }
        public int EmailPort { get; set; }
    }
}
