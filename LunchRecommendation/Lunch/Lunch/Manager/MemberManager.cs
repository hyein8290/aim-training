using Lunch.Common;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lunch.Manager
{
    internal class MemberManager
    {
        public bool ExistsMemberId(string memberId)
        {
            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"select * from member where memberId = '{memberId}'";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }

        public int AddMember(string memberId, string memberName, string position)
        {
            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"insert into member values ('{memberId}', '{memberName}', '{position}')";
                return command.ExecuteNonQuery();
            }
        }

        public bool isLoggedin(string memberId)
        {
            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $@"SELECT eventName FROM (SELECT eventName FROM connlog WHERE memberId = '{memberId}' ORDER BY eventTime DESC) WHERE rownum = 1";
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader["eventName"].ToString().Equals("I"))
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }

                    //if (!reader.Read())
                    //    return false;
                    //else if (reader["eventName"].ToString().Equals("O"))
                    //    return false;
                    //else
                    //    return true;
                }
            }
        }

        public bool ExistsUserName(string name)
        {
            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"select memberId from member where membername = '{name}'";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }

    }
}
