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

        public bool isLogin(string memberId)
        {
            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $@"select eventName from connlog where memberid = '{memberId}' and eventTime = (select max(eventTime) from connlog where memberid = '{memberId}')";
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader[0].ToString().Equals("I"))
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
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
