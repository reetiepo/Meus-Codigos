using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Locadora
{
    class Conexao
    {
        public static SqlConnection Conectar()
        {
            string connectionString = @"Data Source=RENATA-PC;Initial Catalog=locadora;Integrated Security=True;Pooling=False";
            SqlConnection sqlConn = new SqlConnection(connectionString);

            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();

            return sqlConn;
        }
    }
}
