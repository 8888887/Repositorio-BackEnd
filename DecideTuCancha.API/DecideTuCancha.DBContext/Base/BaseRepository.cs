using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DecideTuCancha.DBContext.Base
{
    public class BaseRepository
    {
        public static IConfigurationRoot Configuration { get; set; }

        public SqlConnection GetSqlConnection(bool open = true)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            string cs = Configuration["ConnectionStrings:DefaultConnection"];

            var csb = new SqlConnectionStringBuilder(cs) { };

            var conn = new SqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }

    }
}
