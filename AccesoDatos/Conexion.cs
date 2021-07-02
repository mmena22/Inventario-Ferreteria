using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

using Entidades;


namespace AccesoDatos
{
    public class Conexion
    {
        private static Conexion Instancia = null;

        private readonly string strConexion = Properties.Settings.Default.Conexion;
        private SqlConnection objconexion;


        private Conexion()
        {
            try
            {
                objconexion = new SqlConnection(strConexion);
                this.Abrir();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                this.Cerrar();
            }
        }

        public SqlConnection GetObjConexion()
        {
            return objconexion;
        }

        public static Conexion GetInstancia()
        {
            if (Instancia == null) Instancia = new Conexion();
            Instancia.Abrir();
            return Instancia;

        }

        private void Abrir()
        {
            if (objconexion.State == System.Data.ConnectionState.Closed)
                objconexion.Open();
        }
        public void Cerrar()
        {
            if (objconexion.State == System.Data.ConnectionState.Open)
                objconexion.Close();
        }

        public DataSet EjecutarSentencia(SQLSentencias sentencia)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = objconexion;
                cmd.CommandText = sentencia.Peticion;

                if (sentencia.LstParametros.Count > 0)
                    cmd.Parameters.AddRange(sentencia.LstParametros.ToArray());

                SqlDataAdapter objcarga = new SqlDataAdapter(cmd);
                objcarga.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataSet EjecutarSentenciaTransaccion(SQLSentencias sentencia, SqlTransaction objtran)
        {
            DataSet dt = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = objconexion;
                cmd.CommandText = sentencia.Peticion;
                cmd.Transaction = objtran;

                if (sentencia.LstParametros.Count > 0)
                    cmd.Parameters.AddRange(sentencia.LstParametros.ToArray());


                SqlDataAdapter objcarga = new SqlDataAdapter(cmd);
                objcarga.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public bool EjecutarTransaccion(List<SQLSentencias> sentencias)
        {
            Abrir();
            SqlTransaction objtran = objconexion.BeginTransaction();
            try
            {

                foreach (SQLSentencias sentencia in sentencias)
                {
                    DataSet dt = EjecutarSentenciaTransaccion(sentencia, objtran);
                    Console.WriteLine(dt.Tables.Count);
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
                Cerrar();
            }
        }
    }
}
