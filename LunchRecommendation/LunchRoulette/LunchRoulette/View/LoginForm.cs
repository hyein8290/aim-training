using LunchRoulette.Common;
using LunchRoulette.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LunchRoulette.View
{
    public partial class LoginForm : UserControl
    {
        private MainForm mainForm;
        public LoginForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtId.Text;

            UserManager userManager = new UserManager();
            if (userManager.ExistsUser(userId))
            {
                
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {

        }



    }
}
