using System;
using System.Collections.Generic;
using System.Data;

using Entidades;



namespace AccesoDatos
{
    public class DatosPerfil
    {
        public static List<Perfil> ListarPerfiles(SQLSentencias P_Sentencia)
        {
            List<Perfil> retorno = new List<Perfil>();
            try
            {
                DataSet dt = Conexion.GetInstancia().EjecutarSentencia(P_Sentencia);

                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Tables[0].Rows)
                    {
                        retorno.Add(new Perfil(Convert.ToInt32(item.ItemArray[0]), item.ItemArray[1].ToString()));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }
    }
}
