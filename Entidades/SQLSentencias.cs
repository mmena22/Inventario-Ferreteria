using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades
{
    public class SQLSentencias
    {
        public string Peticion { get; set; }
        public List<SqlParameter> LstParametros { get; set; }

        public SQLSentencias()
        {
            Peticion = string.Empty;
            LstParametros = new List<SqlParameter>();
        }
    }
}
