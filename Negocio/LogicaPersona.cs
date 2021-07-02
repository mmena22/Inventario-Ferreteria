
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using Entidades;
using AccesoDatos;

namespace Negocio
{
    public class LogicaPersona
    {

        private static void llenarParametrosLista(SQLSentencias peticion, string documento,string buscar)
        {
            

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@DocumentoPersona",
                Value = documento,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 10

            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Buscar",
                Value = buscar,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 100

            });
        }

        public static Persona ExistePersona(Persona persona)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ListarPersonas @DocumentoPersona,@Buscar";
            llenarParametrosLista(peticion, persona.DocumentoPersona, "");
            return DatosPersona.Listar(peticion).FirstOrDefault();
        }

        public static List<Persona> Buscar(string buscar)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ListarPersonas @DocumentoPersona,@Buscar";
            llenarParametrosLista(peticion, "", buscar);
            return DatosPersona.Listar(peticion);
        }

        public static List<Persona> Listar()
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ListarPersonas @DocumentoPersona,@Buscar";
            llenarParametrosLista(peticion, "", "");
            return DatosPersona.Listar(peticion);
        }

        public static List<Telefono> ListarTelefonos(Persona persona)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ListarPersonaTelefonos @IdPersona";
            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@IdPersona",
                Value = persona.Id,
                SqlDbType = System.Data.SqlDbType.Int

            });
            return DatosPersona.ListarTelefonos(peticion);
        }

        

        private static List<SQLSentencias> sentenciasTelefonos(Persona persona)
        {
            List<SQLSentencias> retorno = new List<SQLSentencias>();
            foreach (Telefono telefono in persona.Telefonos)
            {
                SQLSentencias peticionTelefono = new SQLSentencias();
                peticionTelefono.Peticion = "EXEC PA_CrearPersonaTelefonos @IdPersona,@Numero";

                peticionTelefono.LstParametros.Add(new SqlParameter
                {
                    ParameterName = "@Numero",
                    Value = telefono.Numero,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 12
                });

                if (persona.Id > 0)
                {
                    peticionTelefono.LstParametros.Add(new SqlParameter
                    {
                        ParameterName = "@IdPersona",
                        Value = persona.Id,
                        SqlDbType = System.Data.SqlDbType.Int
                    });
                }

                retorno.Add(peticionTelefono);
            }

            return retorno;
        }

        private static void llenarParametrosPersona(SQLSentencias peticion, Persona persona)
        {
            if (persona.Id > 0)
            {
                peticion.LstParametros.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = persona.Id,
                    SqlDbType = System.Data.SqlDbType.Int
                });
            }

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@DocumentoPersona",
                Value = persona.DocumentoPersona,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 10

            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Nombres",
                Value = persona.Nombres,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 50
            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Apellidos",
                Value = persona.Apellidos,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 50
            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@FechaNacimiento",
                Value = persona.FechaNacimiento,
                SqlDbType = System.Data.SqlDbType.Date
            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@EstadoCivil",
                Value = (int)persona.EstadoCivil,
                SqlDbType = System.Data.SqlDbType.Int
            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Genero",
                Value = (int)persona.Genero,
                SqlDbType = System.Data.SqlDbType.Int
            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Email",
                Value = persona.Email,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 100
            });
        }

        private static SQLSentencias sentenciaPersonaGuardar(Persona persona)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_CrearPersona @DocumentoPersona,@Nombres,@Apellidos,@FechaNacimiento,@EstadoCivil,@Genero,@Email";
            llenarParametrosPersona(peticion, persona);
            return peticion;
        }

        private static SQLSentencias sentenciaPersonaEditar(Persona persona)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ActualizarPersona @Id,@DocumentoPersona,@Nombres,@Apellidos,@FechaNacimiento,@EstadoCivil,@Genero,@Email";
            llenarParametrosPersona(peticion, persona);
            return peticion;
        }

        public static bool registrar(Persona persona)
        {
            SQLSentencias sentencia = sentenciaPersonaGuardar(persona);
            List<SQLSentencias> sentencias = sentenciasTelefonos(persona);
            return DatosPersona.registrar(sentencia, sentencias);
        }

        public static bool actualizar(Persona persona)
        {
            List<SQLSentencias> sentencias = new List<SQLSentencias> { sentenciaPersonaEditar(persona) };
            sentencias.AddRange(sentenciasTelefonos(persona));
            return DatosPersona.actualizar(sentencias);
        }
    }
}
