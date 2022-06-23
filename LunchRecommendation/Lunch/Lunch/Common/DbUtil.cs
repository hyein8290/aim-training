using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lunch.Common
{
    public class DbUtil
    {
        private const string provider = "OraOLEDB.Oracle";
        private const string dataSource = "localhost"; 
        private const string userId = "roulette";
        private const string password = "java1234";

        public static OleDbConnection connection;

        public static void Connect()
        {
            string connectionString = String.Format("Provider={0}; DataSource={1}; User Id={2};Password={3};", provider, dataSource, userId, password);
            connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch
            {
                MessageBox.Show("[에러] DB에 연결할 수 없습니다.");
                Environment.Exit(0);
            }
        }

        public static OleDbConnection GetConnection()
        {
            string connectionString = String.Format("Provider={0}; DataSource={1}; User Id={2};Password={3};", provider, dataSource, userId, password);
            //OleDbConnection conn =  new OleDbConnection(connectionString);
            //conn.Open();
            //return conn;
            return new OleDbConnection(connectionString);
        }

        //public static OleDbConnection Connect()
        //{
        //    string connectionString = $"Provider={provider}; DataSource={dataSource}; User Id={userId};Password={password};";

        //    try
        //    {
        //        OleDbConnection connection = new OleDbConnection(connectionString);
        //        connection.Open();
        //        return connection;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("[에러] DB에 연결할 수 없습니다.");
        //        return null;
        //    }
        //}

        public static void Close()
        {
            connection.Close();
        }
    }
}
