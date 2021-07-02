using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using static Utilitarios.Enumeradores;


namespace AccesoDatos
{
    public class DatosPersona
    {
        public static List<Persona> Listar(SQLSentencias P_Sentencia)
        {
            List<Persona> retorno = new List<Persona>();
            try
            {
                DataSet dt = Conexion.GetInstancia().EjecutarSentencia(P_Sentencia);

                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item2 in dt.Tables[0].Rows)
                    {
                        Persona persona = new Persona();
                        persona.Id = Convert.ToInt32(item2.ItemArray[0].ToString());
                        persona.DocumentoPersona = item2.ItemArray[1].ToString();
                        persona.Nombres = item2.ItemArray[2].ToString();
                        persona.Apellidos = item2.ItemArray[3].ToString();
                        persona.FechaNacimiento = Convert.ToDateTime(item2.ItemArray[4].ToString());
                        persona.EstadoCivil = (EnumEstadoCivil)Convert.ToInt32(item2.ItemArray[5].ToString());
                        persona.Genero = (EnumGenero)Convert.ToInt32(item2.ItemArray[6].ToString());
                        persona.Email = item2.ItemArray[9].ToString();
                        retorno.Add(persona);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }

        public static List<Telefono> ListarTelefonos(SQLSentencias P_Sentencia)
        {
            List<Telefono> retorno = new List<Telefono>();
            try
            {
                DataSet dt = Conexion.GetInstancia().EjecutarSentencia(P_Sentencia);

                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Tables[0].Rows)
                    {
                        Telefono telefono = new Telefono();
                        telefono.Id = Convert.ToInt32(item.ItemArray[0]);
                        telefono.Numero = item.ItemArray[2].ToString();
                        telefono.Estado = Convert.ToBoolean(item.ItemArray[3]);
                        retorno.Add(telefono);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public static bool registrar(SQLSentencias sentenciaPersona, List<SQLSentencias> sentenciasTelefonos)
        {

            SqlTransaction objtran = null;
            Conexion conexion = null;
            try
            {
                conexion = Conexion.GetInstancia();
                objtran = conexion.GetObjConexion().BeginTransaction();

              
                DataSet dt = conexion.EjecutarSentenciaTransaccion(sentenciaPersona, objtran);
                if (dt.Tables.Count > 0)
                {
                    foreach (SQLSentencias sentencia2 in sentenciasTelefonos)
                    {
                        sentencia2.LstParametros.Add(new SqlParameter
                        {
                            ParameterName = "@IdPersona",
                            Value = Convert.ToInt32(dt.Tables[0].Rows[0].ItemArray[0]),
                            SqlDbType = System.Data.SqlDbType.Int
                        });
                        conexion.EjecutarSentenciaTransaccion(sentencia2, objtran);
                    }
                }
                else
                {
                    objtran.Rollback();
                    conexion.Cerrar();
                    return false;
                }
                Console.WriteLine(dt.Tables.Count);                
                objtran.Commit();
                return true;

            }
            catch (Exception ex)
            {
                objtran.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        public static bool actualizar(List<SQLSentencias> sentencias)
        {
            return Conexion.GetInstancia().EjecutarTransaccion(sentencias);
        }
    }
}
