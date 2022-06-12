using LunchRoulette.Common;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace LunchRoulette.Manager
{
    internal class RestManager
    {
        public Boolean ExistsRest(string name)
        {
            DatabaseQuery query = new DatabaseQuery();
            OleDbCommand command = DbUtil.connection.CreateCommand();
            command.CommandText = query.FindQuery("tblRestaurant", "name", name);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return true;
            else
                return false;
        }
    }
}
