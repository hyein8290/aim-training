using Lunch.Common;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Lunch.Manager
{
    internal class ConnectManager
    {
        //public void AddConnLog(string memberId, char type)
        //{
        //    DbUtil.Connect();
        //    OleDbCommand command = DbUtil.connection.CreateCommand();
        //    command.CommandText = $"insert into connlog values(seqConnLog.nextVal, '{memberId}', '{type}', sysdate)";
        //    command.ExecuteNonQuery();

        //    DbUtil.Close();
        //    command.Dispose();
        //}

        public void AddConnLog(string memberId, char type)
        {
            using (var connection = DbUtil.GetConnection())
            using (var command = new OleDbCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"insert into connlog values(seqConnLog.nextVal, '{memberId}', '{type}', sysdate)";
                command.ExecuteNonQuery();
            }
        }


    }
}
