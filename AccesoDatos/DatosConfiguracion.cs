using System;
using System.Collections.Generic;
using System.Data;

using Entidades;



namespace AccesoDatos
{
    public class DatosConfiguracion
    {
        public static Configuracion Obtener(SQLSentencias P_Sentencia)
        {
            Configuracion retorno = new Configuracion();
            try
            {
                DataSet dt = Conexion.GetInstancia().EjecutarSentencia(P_Sentencia);

                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Tables[0].Rows)
                    {
                        retorno.Id = Convert.ToInt32(item.ItemArray[0]);
                        retorno.NombreFinanciera =item.ItemArray[1].ToString();
                        retorno.Email = item.ItemArray[2].ToString();
                        retorno.EmailPassword = item.ItemArray[3].ToString();
                        retorno.EmailHost = item.ItemArray[4].ToString();
                        retorno.EmailPort = Convert.ToInt32(item.ItemArray[5]);
                        
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
