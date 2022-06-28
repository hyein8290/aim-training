using Lunch.Common;
using Lunch.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lunch.Manager
{
    internal class RestaurantManager
    {
        public DataSet GetRestDataSet()
        {
            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from vwrestlist";
                using(var adapter = new OleDbDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        public DataSet GetRestDataSet(string categoryIdList, string userName, string startDate, string endDate)
        {
            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;

                StringBuilder query = new StringBuilder();

                query.Append($"select * from vwrestlist where value in ( {categoryIdList}) ");
                
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    query.Append("and username like '%" + userName + "%' ");
                }
                
                query.Append("and lastpickdate between '" + startDate + "' and '" + endDate + "'");

                command.CommandText = query.ToString();

                using (var adapter = new OleDbDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        public bool InsertRest(string restName, string category, string signature)
        {
            EnumManager enumManager = new EnumManager();

            string memberId = Properties.Settings.Default.LoginId;
            string categoryId = enumManager.GetEnumId("category", category);

            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                OleDbTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();
                    command.Transaction = transaction;

                    command.CommandText = $"INSERT INTO Restaurant(restid, restname, categoryId, signature) VALUES (seqRestaurant.nextVal, '{restName}', {categoryId}, '{signature}')";
                    command.ExecuteNonQuery();

                    command.CommandText = $"insert into RestEditLog(seq, memberId, restId, eventName, eventTime) values (seqRestEditLog.nextVal, '{memberId}', seqRestaurant.currVal, 'C', sysdate)";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool UpdateRestaurant(int restId, string restName, string category, string signature)
        {
            EnumManager enumManager = new EnumManager();

            string memberId = Properties.Settings.Default.LoginId;
            string categoryId = enumManager.GetEnumId("category", category);

            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                OleDbTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();
                    command.Transaction = transaction;

                    command.CommandText = $"UPDATE Restaurant SET restname = '{restName}', categoryId = '{categoryId}', signature = '{signature}' WHERE restid = {restId}";
                    command.ExecuteNonQuery();

                    command.CommandText = $"INSERT INTO RestEditLog(seq, memberId, restId, eventName, eventTime) VALUES (seqRestEditLog.nextVal, '{memberId}', {restId}, 'U', sysdate)";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }


        public bool DeleteRest(string restId)
        {
            EnumManager enumManager = new EnumManager();

            string memberId = Properties.Settings.Default.LoginId;

            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                OleDbTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();
                    command.Transaction = transaction;

                    command.CommandText = $"DELETE FROM Restaurant WHERE restId = {restId}";
                    command.ExecuteNonQuery();
                    
                    command.CommandText = $"INSERT INTO RestEditLog(seq, memberId, restId, eventName, eventTime) VALUES (seqRestEditLog.nextVal, '{memberId}', {restId}, 'D', sysdate)";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool ExistsRestName(string restName)
        {
            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"select restId from restaurant where restName = '{restName}'";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }

        public Restaurant GetRandomRestaurant(string preferCategory, string exceptCategory, string exceptRestName, int rnum)
        {
            int restId;
            string memberId = Properties.Settings.Default.LoginId;
            Restaurant restaurant = new Restaurant();
            
            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                
                string query = $@"select b.restid
                                from (select rownum as rnum, a.*
                                        from (select r.restId,
                                            case
                                                when r.restId in (select restId from PickLog where memberId = '{memberId}' and sysdate - eventTime <= 7) then 1
                                                else 0
                                            end as isRecent,
                                            case
                                                when r.categoryId in ({preferCategory}) then 1
                                                else 0
                                            end as isPrefer,
                                            count(p.seq) as pickCount
                                            from (select * from Restaurant where restname not in ({exceptRestName}) and categoryId not in ({exceptCategory})) r
                                            left outer join PickLog p on p.restid = r.restid
                                            group by r.restid, r.restname, r.categoryId
                                            order by isRecent asc, isprefer desc, pickCount desc) a) b
                                where rnum = {rnum}";
                command.CommandText = query;

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        restId = Convert.ToInt32(reader["restId"].ToString());
                    else
                        return null;
                }
            }

            return GetRestaurantById(restId);
        }

        private Restaurant GetRestaurantById(int restId)
        {
            Restaurant restaurant = new Restaurant();

            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"select restname, signature from Restaurant where restid = {restId}";
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        restaurant.RestId = restId;
                        restaurant.RestName = reader["restname"].ToString();
                        restaurant.Signature = reader["signature"].ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return restaurant;
        }

        public void AddPickLog(string restId)
        {
            string memberId = Properties.Settings.Default.LoginId;

            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO PickLog(seq, memberId, restId, eventTime) VALUES (seqPickLog.nextVal, '{memberId}', {restId}, sysdate)";
                command.ExecuteNonQuery();
            }
        }
    }
}
