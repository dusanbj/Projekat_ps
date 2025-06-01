using Microsoft.Data.SqlClient;
using System;
using System.Configuration;


namespace DBBroker
{
    public class DbConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public DbConnection()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza_v15"].ConnectionString);
        }

        public void OpenConnection()
        {
            connection?.Open();
        }

        public void CloseConnection()
        {
            connection?.Close();
        }

        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            transaction?.Commit();
        }
        public void Rollback()
        {
            transaction.Rollback();
        }
        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", connection, transaction);
        }
    }
}
