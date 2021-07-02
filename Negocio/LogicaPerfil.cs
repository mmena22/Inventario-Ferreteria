
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using Entidades;
using AccesoDatos;

namespace Negocio
{
    public class LogicaPerfil
    {
        public static List<Perfil> ListarPerfiles()
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ListarPerfiles @Id";
            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Id",
                Value = 0,
                SqlDbType = System.Data.SqlDbType.Int

            });
            return DatosPerfil.ListarPerfiles(peticion);
        }
    }
}
