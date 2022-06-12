using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunchRoulette.Manager
{
    internal class DatabaseQuery
    {
        public string FindAllQuery(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT * FROM " + tableName);
            return query.ToString();
        }

        public string FindQuery(string tableName, string[] columns)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ");
            int length;
            for(length = 0; length < columns.Length; length++)
            {
                if(length < columns.Length - 1)
                    query.Append(columns[length] + ", ");
                else
                    query.Append(columns[length]);
            }
            query.Append(" FROM " + tableName);
            return query.ToString();
        }

        public string FindQuery(string tableName, string[] columns, string[] values)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT * FROM " + tableName + " WHERE ");
            int length;
            for (length = 0; length < columns.Length; length++)
            {
                if (length < columns.Length - 1)
                    query.Append(columns[length] + "='" + values[length] + "' AND ");
                else
                    query.Append(columns[length] + "='" + values[length] + "'");
            }
            return query.ToString();
        }

        public string FindQuery(string tableName, string column, string value)
        {
            return string.Format("SELECT * FROM " + tableName + " WHERE {0} = '{1}'", column, value);
        }

        public string InsertQuery(string tableName, string[] columns, string[] values)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO " + tableName + "(");
            int length;
            for (length = 0; length < columns.Length; length++)
            {
                if (length < columns.Length - 1)
                    query.Append(columns[length] + ", ");
                else
                    query.Append(columns[length] + ") VALUES (");
            }

            for (length = 0; length < values.Length; length++)
            {
                if (length < values.Length - 1)
                    query.Append(values[length] + ", ");
                else
                    query.Append(values[length] + ")");
            }

            return query.ToString();
        }
    }
}
