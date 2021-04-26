using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.Test.Dobles
{
    class SqlLiteDatabaseInMemory
    {
        public static DbConnection CreateConnection()
        {
            var connection = new SqliteConnection("Filename=:AnteProyecto:");

            connection.Open();

            return connection;
        }
    }
}
