using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

namespace DecideTuCancha.DBContext.Base
{
    public class BaseRepository
    {
        public static IConfigurationRoot Configuration { get; set; }

        public SqlConnection GetSqlConnection(bool open = true)
        {
            // Construir el ConfigurationBuilder para cargar el archivo appsettings.json
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            // Corregido: Acceder a la cadena de conexión desde la sección correcta
            string cs = Configuration.GetConnectionString("DefaultConnection");

            var csb = new SqlConnectionStringBuilder(cs) { };

            var conn = new SqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }
    }
}
