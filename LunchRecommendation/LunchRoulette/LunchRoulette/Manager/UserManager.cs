using LunchRoulette.Common;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LunchRoulette.Manager
{
    internal class UserManager
    {
        public Boolean ExistsUserId(string id)
        {
            DatabaseQuery query = new DatabaseQuery();
            OleDbCommand command = DbUtil.connection.CreateCommand();
            command.CommandText = query.FindQuery("tblUser", "id", id);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return true;
            else
                return false;
        }
        public Boolean ExistsUserName(string name)
        {
            DatabaseQuery query = new DatabaseQuery();
            OleDbCommand command = DbUtil.connection.CreateCommand();
            command.CommandText = query.FindQuery("tblUser", "name", name);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return true;
            else
                return false;
        }

        // TODO 다른 클래스로 빼야 되나?
        public void AddConnLog(string id, char type)
        {
            DatabaseQuery query = new DatabaseQuery();
            OleDbCommand command = DbUtil.connection.CreateCommand();

            string stype = "'" + type + "'"; 

            string[] columns = {"id", "userId", "type", "connDate"};
            string[] values = { "seqConnLog.nextVal", id, stype, "sysdate" };

            command.CommandText = query.InsertQuery("tblConnLog", columns, values);
            command.ExecuteNonQuery();
        }
    }
}
