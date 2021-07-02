using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using static Utilitarios.Enumeradores;


namespace AccesoDatos
{
    public class DatosPrestamo
    {
        public static bool actualizar(List<SQLSentencias> sentencias)
        {
            return Conexion.GetInstancia().EjecutarTransaccion(sentencias);
        }

        public static bool registrar(SQLSentencias cabecera, List<SQLSentencias> detalle)
        {

            SqlTransaction objtran = null;
            Conexion conexion = null;
            try
            {
                conexion = Conexion.GetInstancia();
                objtran = conexion.GetObjConexion().BeginTransaction();


                DataSet dt = conexion.EjecutarSentenciaTransaccion(cabecera, objtran);
                if (dt.Tables.Count > 0)
                {
                    foreach (SQLSentencias sentencia2 in detalle)
                    {
                        sentencia2.LstParametros.Add(new SqlParameter
                        {
                            ParameterName = "@IdPrestamo",
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

        public static List<Prestamo> Listar(SQLSentencias P_Sentencia)
        {
            List<Prestamo> retorno = new List<Prestamo>();
            try
            {
                DataSet dt = Conexion.GetInstancia().EjecutarSentencia(P_Sentencia);

                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item2 in dt.Tables[0].Rows)
                    {
                        Prestamo prestamo = new Prestamo();
                        prestamo.Id = Convert.ToInt32(item2.ItemArray[0].ToString());
                        prestamo.Fecha = Convert.ToDateTime(item2.ItemArray[2].ToString());
                        prestamo.Monto = Double.Parse(item2.ItemArray[3].ToString());
                        prestamo.Interes = Double.Parse(item2.ItemArray[4].ToString());
                        prestamo.MontoAPagar = Double.Parse(item2.ItemArray[5].ToString());
                        prestamo.Estado = (EnumEstadoPrestamo)Convert.ToInt32(item2.ItemArray[6].ToString());
                        prestamo.CantidadCuotas = Convert.ToInt32(item2.ItemArray[8].ToString());

                        Persona persona = new Persona();
                        persona.Id = Convert.ToInt32(item2.ItemArray[9].ToString());
                        persona.DocumentoPersona = item2.ItemArray[10].ToString();
                        persona.Nombres = item2.ItemArray[11].ToString();
                        persona.Apellidos = item2.ItemArray[12].ToString();
                        persona.FechaNacimiento = Convert.ToDateTime(item2.ItemArray[13].ToString());
                        persona.EstadoCivil = (EnumEstadoCivil)Convert.ToInt32(item2.ItemArray[14].ToString());
                        persona.Genero = (EnumGenero)Convert.ToInt32(item2.ItemArray[15].ToString());
                        persona.Email = item2.ItemArray[18].ToString();
                        
                        prestamo.Persona = persona;
                        retorno.Add(prestamo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }

        public static List<Cuota> ListarDetalle(SQLSentencias P_Sentencia)
        {
            List<Cuota> retorno = new List<Cuota>();
            try
            {
                DataSet dt = Conexion.GetInstancia().EjecutarSentencia(P_Sentencia);

                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item2 in dt.Tables[0].Rows)
                    {
                        Cuota cuota = new Cuota();
                        cuota.Id = Convert.ToInt32(item2.ItemArray[0].ToString());
                        if(item2.ItemArray[2].ToString().Length>0) cuota.FechaCobro = Convert.ToDateTime(item2.ItemArray[2].ToString());
                        if(item2.ItemArray[3].ToString().Length > 0) cuota.FechaPago = Convert.ToDateTime(item2.ItemArray[3].ToString());
                        cuota.Monto = Double.Parse(item2.ItemArray[4].ToString());
                        cuota.Estado =(EnumEstadoCuota)Convert.ToInt32(item2.ItemArray[5].ToString());                      
                        retorno.Add(cuota);
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
