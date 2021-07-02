using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

using Entidades;
using AccesoDatos;
using static Utilitarios.Enumeradores;


namespace Negocio
{
    public class LogicaUsuario
    {
        public static Usuario VerificarAcceso(Usuario usuario)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_VerificarAcceso @NombreUsuario,@Password";

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@NombreUsuario",
                Value = usuario.NombreUsuario,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 50

            });


            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Password",
                Value = usuario.Password,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 20
            });

            return DatosUsuario.VerificarAcceso(peticion);
        }

        private static void llenarPerfiles(List<Usuario> usuarios)
        {
            foreach (Usuario item in usuarios)
            {
                SQLSentencias _perfiles = new SQLSentencias();
                _perfiles.Peticion = "EXEC PA_ListarPerfilesPorUsuario @IdUsuario";

                _perfiles.LstParametros.Add(new SqlParameter
                {
                    ParameterName = "@IdUsuario",
                    Value = item.Id,
                    SqlDbType = System.Data.SqlDbType.Int

                });

                item.Perfiles = DatosUsuario.ListarPerfilesPorUsuario(_perfiles);

            }
        }

        private static void llenarParametrosListarUsuario(SQLSentencias peticion,int idPersona,string email)
        {
            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@IdPersona",
                Value = idPersona,
                SqlDbType = System.Data.SqlDbType.Int

            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Email",
                Value = email,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 100
            });
        }
        
        public static List<Usuario> Listar()
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ListarUsuarios @IdPersona,@Email";
            llenarParametrosListarUsuario(peticion, 0, "");

            List<Usuario> usuarios = DatosUsuario.Listar(peticion);
            llenarPerfiles(usuarios);
            return usuarios;
        }

        public static Usuario ExisteUsuarioPorPersona(Persona persona)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ListarUsuarios @IdPersona,@Email";
            llenarParametrosListarUsuario(peticion,persona.Id,"");

            List<Usuario> usuarios = DatosUsuario.Listar(peticion);
            llenarPerfiles(usuarios);
            return usuarios.FirstOrDefault();
        }

        public static Usuario ExisteUsuarioPorEmail(String email)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ListarUsuarios @IdPersona,@Email";
            llenarParametrosListarUsuario(peticion, 0, email);

            List<Usuario> usuarios = DatosUsuario.Listar(peticion);
            llenarPerfiles(usuarios);
            return usuarios.FirstOrDefault();
        }

        private static void asignarParametrosSentenciaUsuario(SQLSentencias peticion, Usuario usuario)
        {
            if (usuario.Id > 0)
            {
                peticion.LstParametros.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = usuario.Id,
                    SqlDbType = System.Data.SqlDbType.Int
                });
            }

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@NombreUsuario",
                Value = usuario.NombreUsuario,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 20

            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Password",
                Value = usuario.Password,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 20
            });

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Estado",
                Value = usuario.Estado,
                SqlDbType = System.Data.SqlDbType.Bit
            });
        }

        private static List<SQLSentencias> senteciaPerfiles(Usuario usuario)
        {
            List<SQLSentencias> retorno = new List<SQLSentencias>();

            foreach (Perfil perfil in usuario.Perfiles)
            {
                SQLSentencias peticionPerfil = new SQLSentencias();
                peticionPerfil.Peticion = "EXEC PA_CrearUsuarioPerfil @IdUsuario,@IdPerfil";

                if (usuario.Id > 0)
                {

                    peticionPerfil.LstParametros.Add(new SqlParameter
                    {
                        ParameterName = "@IdUsuario",
                        Value = usuario.Id,
                        SqlDbType = System.Data.SqlDbType.Int

                    });
                }

                peticionPerfil.LstParametros.Add(new SqlParameter
                {
                    ParameterName = "@IdPerfil",
                    Value = perfil.Id,
                    SqlDbType = System.Data.SqlDbType.Int
                });

                retorno.Add(peticionPerfil);
            }

            return retorno;
        }

        public static Usuario ExisteUsuario(Usuario usuario)
        {
            SQLSentencias peticion = new SQLSentencias();
            peticion.Peticion = "EXEC PA_ExisteUsuario @NombreUsuario";

            peticion.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@NombreUsuario",
                Value = usuario.NombreUsuario,
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 50

            });
            return DatosUsuario.ExisteUsuario(peticion);
        }
        private static SQLSentencias sentenciaPersonaUsuario(Usuario usuario)
        {
            SQLSentencias senteciaUsuario = new SQLSentencias();
            senteciaUsuario.Peticion = "EXEC PA_CrearUsuarioPersona @Id,@IdUsuario";
            if (usuario.Id > 0)
            {

                senteciaUsuario.LstParametros.Add(new SqlParameter
                {
                    ParameterName = "@IdUsuario",
                    Value = usuario.Id,
                    SqlDbType = System.Data.SqlDbType.Int

                });
            }

            senteciaUsuario.LstParametros.Add(new SqlParameter
            {
                ParameterName = "@Id",
                Value = usuario.Persona.Id,
                SqlDbType = System.Data.SqlDbType.Int
            });


            return senteciaUsuario;
        }

        public static bool registrar(Usuario usuario)
        {
            SQLSentencias senteciaUsuario = new SQLSentencias();
            senteciaUsuario.Peticion = "EXEC PA_CrearUsuario @NombreUsuario,@Password,@Estado";
            asignarParametrosSentenciaUsuario(senteciaUsuario, usuario);

            List<SQLSentencias> sentenciasPerfiles = senteciaPerfiles(usuario);
            return DatosUsuario.registrar(senteciaUsuario, sentenciasPerfiles, sentenciaPersonaUsuario(usuario));
        }

        public static bool actualizar(Usuario usuario)
        {
            SQLSentencias senteciaUsuario = new SQLSentencias();
            senteciaUsuario.Peticion = "EXEC PA_ActualizarUsuario @Id,@Password,@Estado";
            asignarParametrosSentenciaUsuario(senteciaUsuario, usuario);
            List<SQLSentencias> sentencias = new List<SQLSentencias>();
            sentencias.Add(senteciaUsuario);
            sentencias.AddRange(senteciaPerfiles(usuario));
            return DatosUsuario.actualizar(sentencias);
        }
    }
}
