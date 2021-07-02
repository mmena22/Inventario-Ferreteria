using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using static Utilitarios.Enumeradores;


namespace AccesoDatos
{
    public class DatosUsuario
    {
        public static Usuario VerificarAcceso(SQLSentencias P_Sentencia)
        {
            Usuario usuario = null;
            try
            {
                DataSet dt = Conexion.GetInstancia().EjecutarSentencia(P_Sentencia);

                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Tables[0].Rows)
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(item.ItemArray[0]);
                        usuario.NombreUsuario = item.ItemArray[1].ToString();
                        usuario.Estado = (EnumEstado)Convert.ToInt32(item.ItemArray[2]);

                        if (dt.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow item2 in dt.Tables[1].Rows)
                            {
                                usuario.Perfiles.Add(new Perfil(Convert.ToInt32(item2.ItemArray[0]), item2.ItemArray[1].ToString()));
                            }
                        }

                        if (dt.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow item2 in dt.Tables[2].Rows)
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
                                usuario.Persona = persona;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuario;
        }

        public static Usuario ExisteUsuario(SQLSentencias P_Sentencia)
        {
            Usuario usuario = null;
            try
            {
                DataSet dt = Conexion.GetInstancia().EjecutarSentencia(P_Sentencia);

                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Tables[0].Rows)
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(item.ItemArray[0]);
                        usuario.NombreUsuario = item.ItemArray[1].ToString();
                        usuario.Estado = (EnumEstado)Convert.ToInt32(item.ItemArray[4]);

                        
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuario;
        }

        public static List<Usuario> Listar(SQLSentencias P_Sentencia)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                DataSet dt = Conexion.GetInstancia().EjecutarSentencia(P_Sentencia);

                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Tables[0].Rows)
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(item.ItemArray[0]);
                        usuario.NombreUsuario = item.ItemArray[1].ToString();
                        usuario.Password = item.ItemArray[2].ToString();
                        usuario.Estado = (EnumEstado)Convert.ToInt32(item.ItemArray[4]);

                        Persona persona = new Persona();
                        persona.Id = Convert.ToInt32(item.ItemArray[5]);
                        persona.DocumentoPersona = item.ItemArray[6].ToString();
                        persona.Nombres = item.ItemArray[7].ToString();
                        persona.Apellidos = item.ItemArray[8].ToString();
                        persona.FechaNacimiento = Convert.ToDateTime(item.ItemArray[9].ToString());
                        persona.EstadoCivil = (EnumEstadoCivil)Convert.ToInt32(item.ItemArray[10].ToString());
                        persona.Genero = (EnumGenero)Convert.ToInt32(item.ItemArray[11].ToString());
                        persona.Email = item.ItemArray[14].ToString();
                        usuario.Persona = persona;

                        usuarios.Add(usuario);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;
        }

        public static List<Perfil> ListarPerfilesPorUsuario(SQLSentencias P_Sentencia)
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

        public static bool actualizar(List<SQLSentencias> sentencias)
        {
            return Conexion.GetInstancia().EjecutarTransaccion(sentencias);
        }

        public static bool registrar(SQLSentencias cabecera, List<SQLSentencias> detalle, SQLSentencias spersona)
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
                            ParameterName = "@IdUsuario",
                            Value = Convert.ToInt32(dt.Tables[0].Rows[0].ItemArray[0]),
                            SqlDbType = System.Data.SqlDbType.Int
                        });
                        conexion.EjecutarSentenciaTransaccion(sentencia2, objtran);
                    }

                    spersona.LstParametros.Add(new SqlParameter
                    {
                        ParameterName = "@IdUsuario",
                        Value = Convert.ToInt32(dt.Tables[0].Rows[0].ItemArray[0]),
                        SqlDbType = System.Data.SqlDbType.Int
                    });
                    conexion.EjecutarSentenciaTransaccion(spersona, objtran);
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
    }
}
