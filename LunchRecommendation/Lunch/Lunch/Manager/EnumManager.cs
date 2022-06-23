using Lunch.Common;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Lunch.Manager
{
    internal class EnumManager
    {
        public string GetEnumId(string type, string value)
        {
            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"select enumId from enum where type = '{type}' and value = '{value}'";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return reader[0].ToString();
                    else
                        return null;
                }
            }
        }
    }
}
