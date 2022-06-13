using LunchRoulette.Common;
using LunchRoulette.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        public DataSet GetRestDataSet(List<string> categories, string userName, string startDate, string endDate)
        {
            OleDbCommand command = DbUtil.connection.CreateCommand();
            
            StringBuilder query = new StringBuilder();
            query.Append("select * from vwrestlist where category in (");
            for(int i = 0; i < categories.Count; i++)
            {
                if(i < categories.Count - 1) 
                    query.Append("'" + categories[i] + "',");
                else
                    query.Append("'" + categories[i] + "') ");
            }
            if(userName != "")
            {
                query.Append("and username = '" + userName + "' ");
            }
            query.Append("and lastdate between '" + startDate + "' and '" + endDate + "'");
            
            command.CommandText = query.ToString();

            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;

        }

        public void AddConnLog(string id)
        {
            DatabaseQuery query = new DatabaseQuery();
            OleDbCommand command = DbUtil.connection.CreateCommand();

            string[] columns = { "id", "userId", "type", "connDate" };
            string[] values = { "seqConnLog.nextVal", id, "'I'", "sysdate" };

            command.CommandText = query.InsertQuery("tblConnLog", columns, values);
            command.ExecuteNonQuery();
        }
    }
}
