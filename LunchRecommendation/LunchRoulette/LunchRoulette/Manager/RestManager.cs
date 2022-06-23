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
            //if(userName != "")
            if (!string.IsNullOrWhiteSpace(userName))
            {
                query.Append("and username like '%" + userName + "%' ");
            }
            query.Append("and (lastpickdate between '" + startDate + "' and '" + endDate + "'");
            query.Append("or lastpickdate = '없음')");
            
            command.CommandText = query.ToString();

            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;

        }

        //public int AddRest(string name, string category, string signature) 
        //{
        //    DatabaseQuery query = new DatabaseQuery();
        //    OleDbCommand command = DbUtil.connection.CreateCommand();
            

        //    //string[] columns = { "id", "name", "category", "signature"};
        //    //string[] values = { "seqRestaurant.nextVal", name, category, signature };

        //    //command.CommandText = query.InsertQuery("tblRestaurant", columns, values);
        //    //command.CommandText = String.Format("INSERT INTO tblRestaurant(id, name, category, signature) VALUES (seqRestaurant.nextVal, '{0}', '{1}', '{2}')", name, category, signature);
        //    command.CommandText = $"INSERT INTO tblRestaurant(id, name, category, signature) VALUES (seqRestaurant.nextVal, '{name}', '{category}', '{signature}')";
        //    return command.ExecuteNonQuery();
        //}

        public bool AddRest(string name, string category, string signature)
        {
            DatabaseQuery query = new DatabaseQuery();
            OleDbCommand command = DbUtil.connection.CreateCommand();
            OleDbTransaction transaction = null;

            string userId = Properties.Settings.Default.LoginId;

            try
            {
                transaction = DbUtil.connection.BeginTransaction();
                command.Transaction = transaction;

                command.CommandText = $"INSERT INTO tblRestaurant(id, name, category, signature) VALUES (seqRestaurant.nextVal, '{name}', '{category}', '{signature}')";
                command.ExecuteNonQuery();

                command.CommandText = $"insert into tblRestEditLog(id, userId, restId, type, editdate) values (seqRestEditLog.nextVal, {userId}, seqRestaurant.currVal, 'C', sysdate)";
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

        public bool InsertRest(string name, string category, string signature)
        {
            DatabaseQuery query = new DatabaseQuery();
            OleDbCommand command = DbUtil.connection.CreateCommand();
            OleDbTransaction transaction = null;

            string userId = Properties.Settings.Default.LoginId;

            try
            {
                transaction = DbUtil.connection.BeginTransaction();
                command.Transaction = transaction;

                command.CommandText = $"INSERT INTO tblRestaurant(id, name, category, signature) VALUES (seqRestaurant.nextVal, '{name}', '{category}', '{signature}')";
                command.ExecuteNonQuery();

                command.CommandText = $"insert into tblRestEditLog(id, userId, restId, type, editdate) values (seqRestEditLog.nextVal, {userId}, seqRestaurant.currVal, 'C', sysdate)";
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
        public bool UpdateRest(string orgRestName, string name, string category, string signature)
        {
            DatabaseQuery query = new DatabaseQuery();
            OleDbCommand command = DbUtil.connection.CreateCommand();
            OleDbTransaction transaction = null;

            string userId = Properties.Settings.Default.LoginId;
            string restId = GetRestId(orgRestName);

            try
            {
                transaction = DbUtil.connection.BeginTransaction();
                command.Transaction = transaction;

                command.CommandText = $"UPDATE tblRestaurant SET name = '{name}', category = '{category}', signature = '{signature}' WHERE id = {restId}";
                command.ExecuteNonQuery();

                command.CommandText = $"insert into tblRestEditLog(id, userId, restId, type, editdate) values (seqRestEditLog.nextVal, {userId}, {restId}, 'U', sysdate)";
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

        public bool DeleteRest(string restName)
        {
            DatabaseQuery query = new DatabaseQuery();
            OleDbCommand command = DbUtil.connection.CreateCommand();
            OleDbTransaction transaction = null;

            string userId = Properties.Settings.Default.LoginId;
            string restId = GetRestId(restName);

            try
            {
                transaction = DbUtil.connection.BeginTransaction();
                command.Transaction = transaction;

                command.CommandText = $"DELETE FROM tblRestaurant WHERE id = {restId}";
                command.ExecuteNonQuery();

                command.CommandText = $"insert into tblRestEditLog(id, userId, restId, type, editdate) values (seqRestEditLog.nextVal, {userId}, {restId}, 'D', sysdate)";
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

        private string GetEditRestQuery()
        {
            //1. 추가
            // INSERT INTO tblRestaurant(id, name, category, signature) VALUES (seqRestaurant.nextVal, '{name}', '{category}', '{signature}')
            //2. 수정
            // UPDATE tblRestaurant SET name = '{name}', category = '{category}', signature = '{signature}' WHERE name = 'orgRestName'
            //3. 삭제
            // DELETE FROM tblRestaurant WHERE name = {name}
            return null;
        }


        public void AddPickLog(string restName)
        {
            OleDbCommand command = DbUtil.connection.CreateCommand();

            string userId = Properties.Settings.Default.LoginId;
            string restId = GetRestId(restName);

            command.CommandText = $"insert into tblPickLog(id, userId, restId, pickdate) values(seqPickLog.nextVal, {userId}, {restId}, sysdate)";
            command.ExecuteNonQuery();
        }

        public void AddEditLog(string restName, string type)
        {
            OleDbCommand command = DbUtil.connection.CreateCommand();

            string userId = Properties.Settings.Default.LoginId;
            string restId = GetRestId(restName);

            command.CommandText = $"insert into tblRestEditLog(id, userId, restId, type, editdate) values (seqRestEditLog, {userId}, {restId}, '{type}', sysdate)";
        }
       

        public string GetRestId(string restName)
        {
            OleDbCommand command = DbUtil.connection.CreateCommand();
            command.CommandText = $"select id from tblRestaurant where name = '{restName}'";
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader[0].ToString();
                //return reader.GetDecimal(0).ToString();
            }

            return null;
        }

        public int DeleteRestByName(string name)
        {
            OleDbCommand command = DbUtil.connection.CreateCommand();
            string query = "DELETE FROM tblRestaurant WHERE name = ?";
            command.CommandText = query;
            command.Parameters.AddWithValue("?", name);

            return command.ExecuteNonQuery();
        }

        // TODO 수정이 필요해
        public Restaurant GetRecomRestaurant(string preferCategory, string exceptCategory, string exceptRestName, int rnum)
        {
            string userId = Properties.Settings.Default.LoginId;
            string exceptQuery;

            Restaurant restaurant = new Restaurant();

            OleDbCommand command = DbUtil.connection.CreateCommand();

            // TODO 수정이 필요해
            if (exceptCategory == "''" && exceptRestName == "''")
            {
                exceptQuery = "tblRestaurant";
            }
            else if (exceptCategory == "''")
            {
                exceptQuery = $@"(select * from tblRestaurant where name not in ({exceptRestName}))";
            }
            else if (exceptRestName == "''")
            {
                exceptQuery = $@"(select * from tblRestaurant where category not in ({exceptCategory}))";
            }
            else
            {
                exceptQuery = $@"(select * from tblRestaurant where name not in ({exceptRestName}) and category not in ({exceptCategory}))";
            }


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
                                            count(p.id) as pickCount
                                            from {exceptQuery} r
                                            left outer join tblPickLog p on p.restid = r.id
                                            group by r.id, r.name, r.category
                                            order by isRecent asc, isprefer desc, pickCount desc, rnd desc) a) b
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

            // TODO 변수명 수정
            // 따로 메서드 뺄까
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
