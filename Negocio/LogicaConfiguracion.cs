
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using Entidades;
using AccesoDatos;

namespace Negocio
{
    public class LogicaConfiguracion
    {
        public static Configuracion Obtener()
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ObtenerConfiguracion";            
            return DatosConfiguracion.Obtener(peticion);
        }
    }
}
