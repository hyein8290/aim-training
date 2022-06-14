using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LunchRoulette.Common
{
    public class DbUtil
    {
        private static string provider = "OraOLEDB.Oracle";
        private static string dataSource = "localhost"; // 뭘로 해도 에러가 안 나네;
        private static string userId = "lunch";
        private static string password = "java1234";

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

        public static void Close()
        {
            connection.Close();
        }
    }
}
