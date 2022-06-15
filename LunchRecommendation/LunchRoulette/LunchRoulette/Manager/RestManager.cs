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
            query.Append("and lastpickdate between '" + startDate + "' and '" + endDate + "'");
            
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

        public int AddRest(string name, string category, string signature) 
        {
            DatabaseQuery query = new DatabaseQuery();
            OleDbCommand command = DbUtil.connection.CreateCommand();

            //string[] columns = { "id", "name", "category", "signature"};
            //string[] values = { "seqRestaurant.nextVal", name, category, signature };

            //command.CommandText = query.InsertQuery("tblRestaurant", columns, values);
            command.CommandText = String.Format("INSERT INTO tblRestaurant(id, name, category, signature) VALUES (seqRestaurant.nextVal, '{0}', '{1}', '{2}')", name, category, signature);
            return command.ExecuteNonQuery();
        }

        public int DeleteRestByName(string name)
        {
            OleDbCommand command = DbUtil.connection.CreateCommand();
            string query = "DELETE FROM tblRestaurant WHERE name = ?";
            command.CommandText = query;
            command.Parameters.AddWithValue("?", name);

            return command.ExecuteNonQuery();
        }

        public Restaurant GetRecomRestaurant(string preferCategory, string exceptCategory, string exceptRestName, int rnum)
        {
            Restaurant restaurant = new Restaurant();

            OleDbCommand command = DbUtil.connection.CreateCommand();
            //string exceptQuery = $@"select * from tblRestaurant where name not in ({exceptRestaurant}) and category not in ({exceptCategory})";
            string userId = Properties.Settings.Default.LoginId;

            string query = $@"select b.id
                                from (select rownum as rnum, a.*
                                        from (select r.id,
                                            case
                                                when r.id in (select restId from tblPickLog where userId = '{userId}' and sysdate - pickdate <= 7) then 1
                                                else 0
                                            end as isRecent,
                                            case
                                                when r.category in ({preferCategory}) then 1
                                                else 0
                                            end as isPrefer,
                                            count(p.id) as pickCount,
                                            round(dbms_random.value() * 1000) as rnd
                                            from (select * from tblRestaurant where name not in ({exceptRestName}) and category not in ({exceptCategory})) r
                                            left outer join tblPickLog p on p.restid = r.id
                                            group by r.id, r.name, r.category
                                            order by isrecent asc, isprefer desc, pickCount desc, rnd desc) a) b
                                where rnum = {rnum}";
            command.CommandText = query;

            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                restaurant.Id = Convert.ToInt32(reader[0].ToString());
            }
            else
            {
                return null;
            }

            

            string query2 = $"select name, signature from tblRestaurant where id = {restaurant.Id}";

            OleDbCommand command2 = DbUtil.connection.CreateCommand();
            command2.CommandText = query2;
            OleDbDataReader reader2 = command2.ExecuteReader();

            if (reader2.Read())
            {
                restaurant.Name = reader2[0].ToString();
                restaurant.Signature = reader2[1].ToString();
            }

            return restaurant;

        }
    }
}
