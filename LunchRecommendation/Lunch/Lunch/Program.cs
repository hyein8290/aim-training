using Lunch.Common;
using Lunch.Manager;
using Lunch.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lunch
{
    internal static class Program
    {
        public static ApplicationContext ac = new ApplicationContext();
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            DbUtil.Connect();
            //new LoginForm().Show();
            //Application.Run();

            ac.MainForm = new LoginForm();
            Application.Run(ac);

        }
    }
}
