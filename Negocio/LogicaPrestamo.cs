using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using static Utilitarios.Enumeradores;

namespace Negocio
{
    public class LogicaPrestamo
    {
        private static SQLSentencias obtenerSentenciaPrestamo(Prestamo prestamo)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_RegistrarPrestamo @IdPersona,@Fecha,@Monto,@Interes,@MontoAPagar,@CantidadCuotas";

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@IdPersona",
                Value = prestamo.Persona.Id,
                SqlDbType = System.Data.SqlDbType.Int

            });
            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Fecha",
                Value = prestamo.Fecha,
                SqlDbType = System.Data.SqlDbType.Date

            });peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Monto",
                Value = prestamo.Monto,
                SqlDbType = System.Data.SqlDbType.Decimal

            });peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Interes",
                Value = prestamo.Interes,
                SqlDbType = System.Data.SqlDbType.Decimal

            });
            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@MontoAPagar",
                Value = prestamo.MontoAPagar,
                SqlDbType = System.Data.SqlDbType.Decimal

            });peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@CantidadCuotas",
                Value = prestamo.CantidadCuotas,
                SqlDbType = System.Data.SqlDbType.Int

            });

            return peticion;
        }

        private static List<SQLSentencias> obtenerSentenciasCoutas(Prestamo prestamo)
        {
            List<SQLSentencias> retorno = new List<SQLSentencias>();
            foreach (Cuota item in prestamo.Cuotas)
            {
                SQLSentencias peticion = new SQLSentencias();
                peticion.Peticion = "EXEC PA_RegistrarPrestamoCuota @IdPrestamo,@FechaCobro,@Monto";

                peticion.LstParametros.Add(new SqlParameter
                {
                    ParameterName = "@FechaCobro",
                    Value = item.FechaCobro,
                    SqlDbType = System.Data.SqlDbType.Date
                }); 
                peticion.LstParametros.Add(new SqlParameter
                {
                    ParameterName = "@Monto",
                    Value = item.Monto,
                    SqlDbType = System.Data.SqlDbType.Decimal
                });

                retorno.Add(peticion);
            }

            return retorno;
        }

        public static bool registrar(Prestamo prestamo)
        {
            return DatosPrestamo.registrar(obtenerSentenciaPrestamo(prestamo),obtenerSentenciasCoutas(prestamo));
        }

        private static void llenarParametrosFiltro(SQLSentencias peticion,string DocumentoPersona,int Estado)
        {
            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@DocumentoPersona",
                Value = DocumentoPersona,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 10
            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Estado",
                Value = Estado,
                SqlDbType = System.Data.SqlDbType.Int
            });
        }
        

        public static List<Prestamo> listar()
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ListarPrestamos @DocumentoPersona,@Estado";
            llenarParametrosFiltro(peticion, "", -1);
            return DatosPrestamo.Listar(peticion);
        }

        public static List<Prestamo> filtrar( string DocumentoPersona, int estado)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ListarPrestamos @DocumentoPersona,@Estado";
            llenarParametrosFiltro(peticion, DocumentoPersona, estado);
            return DatosPrestamo.Listar(peticion);
        }

        public static List<Cuota> ListarDetalle(Prestamo prestamo)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ListarPrestamoCuota @IdPrestamo";
            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@IdPrestamo",
                Value = prestamo.Id,
                SqlDbType = System.Data.SqlDbType.Int
            }); 
            return DatosPrestamo.ListarDetalle(peticion);
        }

        public static bool CambiarEstadoPrestamo(Prestamo prestamo,EnumEstadoPrestamo estado)
        {

            List<SQLSentencias> sentencias = new List<SQLSentencias>();
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ActualizarPrestamo @Id,@Estado";
            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Id",
                Value = prestamo.Id,
                SqlDbType = System.Data.SqlDbType.Int
            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Estado",
                Value = estado,
                SqlDbType = System.Data.SqlDbType.Int
            });
            sentencias.Add(peticion);
            if (estado.Equals(EnumEstadoPrestamo.Finalizado))
            {
               
                foreach (Cuota cuota in prestamo.obtenerCuotasPendientes())
                {
                    SQLSentencias peticion2 = new SQLSentencias();
                    peticion2.Peticion = "EXEC PA_RegistrarPagoCuota @Id,@Estado,@FechaPago";
                    peticion2.LstParametros.Add(new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = cuota.Id,
                        SqlDbType = System.Data.SqlDbType.Int
                    });

                    peticion2.LstParametros.Add(new SqlParameter
                    {
                        ParameterName = "@Estado",
                        Value = EnumEstadoCuota.Pagado,
                        SqlDbType = System.Data.SqlDbType.Int
                    }); peticion2.LstParametros.Add(new SqlParameter
                    {
                        ParameterName = "@FechaPago",
                        Value = DateTime.Now,
                        SqlDbType = System.Data.SqlDbType.Date
                    });
                    sentencias.Add(peticion2);
                }
            }

            return DatosPrestamo.actualizar(sentencias);
        }

        public static bool PagarCuota(Cuota cuota)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_RegistrarPagoCuota @Id,@Estado,@FechaPago";
            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Id",
                Value = cuota.Id,
                SqlDbType = System.Data.SqlDbType.Int
            });  
            
            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Estado",
                Value = cuota.Estado,
                SqlDbType = System.Data.SqlDbType.Int
            }); peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@FechaPago",
                Value = cuota.FechaPago,
                SqlDbType = System.Data.SqlDbType.Date
            });

            return DatosPrestamo.actualizar(new List<SQLSentencias> { peticion });
        }


    }
}
