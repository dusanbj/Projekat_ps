using Common;
using Common.Domain;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace DBBroker
{
    public class Broker
    {
        private DbConnection connection;
        public Broker()
        {
            connection = new DbConnection();
        }

        public void Add(IEntity obj)
        {
            var cmd = connection.CreateCommand();

            string cols = "";
            var insertColsProp = obj.GetType().GetProperty("InsertColumns");
            if (insertColsProp != null)
            {
                var val = insertColsProp.GetValue(obj) as string;
                if (!string.IsNullOrWhiteSpace(val))
                    cols = $"({val})";
            }

            cmd.CommandText = $"INSERT INTO {obj.TableName} {cols} VALUES({obj.Values})";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void Delete(IEntity obj)
        {
            string[] pkNames = obj.PrimaryKeyName.Split(',');
            string[] pkValues = obj.PrimaryKeyValue.Split(',');
            var conditions = pkNames.Select((name, i) => $"{name.Trim()} = {pkValues[i].Trim()}");
            string whereClause = string.Join(" AND ", conditions);

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM {obj.TableName} WHERE {whereClause}";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void Update(IEntity obj)
        {
            string[] pkNames = obj.PrimaryKeyName.Split(',');
            string[] pkValues = obj.PrimaryKeyValue.Split(',');
            var conditions = pkNames.Select((name, i) => $"{name.Trim()} = {pkValues[i].Trim()}");
            string whereClause = string.Join(" AND ", conditions);

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"UPDATE {obj.TableName} SET {obj.UpdateValues} WHERE {whereClause}";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName}";
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public List<IEntity> GetByCondition(IEntity entity, string condition)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = string.IsNullOrWhiteSpace(condition)
                ? $"SELECT * FROM {entity.TableName}"
                : $"SELECT * FROM {entity.TableName} WHERE {condition}";
            using SqlDataReader reader = command.ExecuteReader();
            var list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }

        //1. GetAllJoin - uzima nazive dve tabele i joinuje ih
        //2. dodati u GetByCondition
        //3. entity da ima join condition, ako je join condition null ide bez joina, ako nije null nalepi join i povezi property
    }
}
