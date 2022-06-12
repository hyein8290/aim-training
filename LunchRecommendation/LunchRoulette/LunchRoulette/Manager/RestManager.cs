using LunchRoulette.Common;
using LunchRoulette.Data;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<Restaurant> GetRestList()
        {
            DatabaseQuery query = new DatabaseQuery();
            OleDbCommand command = DbUtil.connection.CreateCommand();
            command.CommandText = "select * from vwrestlist";
            OleDbDataReader reader = command.ExecuteReader();

            List<Restaurant> restaurants = new List<Restaurant>();
            while (reader.Read())
            {
                Restaurant restaurant = new Restaurant();

                restaurant.Name = reader[0].ToString();
                restaurant.Signature = reader[1].ToString();
                restaurant.Category = reader[2].ToString();
                restaurant.UserName = reader[3].ToString();
                restaurant.LastDate = reader[4].ToString();
                restaurant.Count = Convert.ToInt32(reader[5].ToString());

                restaurants.Add(restaurant);
            }

            return restaurants;

        }

        public DataSet GetRestDataSet()
        {
            OleDbCommand command = DbUtil.connection.CreateCommand();
            command.CommandText = "select * from vwrestlist";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
    }
}
