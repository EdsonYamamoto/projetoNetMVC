using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCEventos.App_Start
{
    public class DbContext
    {
        private SqlConnection connection;
        private SqlCommand connectionCommand;
        private SqlDataReader connectionReader;
        private DataTable connectionDataTable;

        public static string sqlString = "";
        public SqlDataReader ConnectionReader
        {
            get { return connectionReader; }
            set { connectionReader = value; }
        }
        public DataTable ConnectionDataTable
        {
            get { return connectionDataTable; }
            set { connectionDataTable = value; }
        }
        public SqlCommand ConnectionCommand
        {
            get { return connectionCommand; }
            set { connectionCommand = value; }
        }
        public SqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }
        public DbContext()
        {
            try
            {
                if ((connection == null) || (connection.State != System.Data.ConnectionState.Open))
                {
                    connection = new SqlConnection();
                    connection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Evento; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                    //connection.ConnectionString = @"Data Source=NOTE-EDSON\\SQLEXPRESS;Initial Catalog=Evento;Integrated Security=true";
                    connection.Open();
                }
                connectionCommand = new SqlCommand();
                connectionCommand.Connection = connection;
            }

            catch (Exception ex)
            {
                throw new Exception("Conexão com o Banco:" + ex.Message);
            }
        }

    }
}