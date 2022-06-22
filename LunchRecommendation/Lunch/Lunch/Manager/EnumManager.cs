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
            OleDbCommand command = DbUtil.connection.CreateCommand();
            command.CommandText = $"select enumId from enum where type = '{type}' and value = '{value}'";
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                    return reader[0].ToString();
                else
                    return null;
            }
        }
    }
}
