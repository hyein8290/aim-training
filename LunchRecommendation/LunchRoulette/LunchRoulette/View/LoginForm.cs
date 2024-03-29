﻿using LunchRoulette.Common;
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
            txtId.Text = "";

            //List<string> names = new List<string>() { "Ross", "Joey", "Chandler" };
            //string joinedNames = "'" + String.Join("', '", names.ToArray()) + "'";
            //MessageBox.Show(joinedNames);

            if (ValidateId(userId))
            {
                LoginById(userId);
            }
        }

        private void LoginById(string userId)
        {
            UserManager userManager = new UserManager();
            if (userManager.ExistsUserId(userId))
            {
                userManager.AddConnLog(userId, 'I');
                Properties.Settings.Default.LoginId = userId;
                //Properties.Settings.Default.Save();
                mainForm.ShowPage(TYPE_PAGE.MENU_PAGE);
            }
            else
            {
                MessageBox.Show("존재하지 않는 회원입니다.");
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(TYPE_PAGE.JOIN_PAGE);
        }

        private Boolean ValidateId(string txtId)
        {
            if (txtId == null)
            {
                MessageBox.Show("사번을 입력해주세요");
                return false;
            }

            try
            {
                int id = Convert.ToInt32(txtId);
                return true;
            }
            catch (FormatException e)
            {
                MessageBox.Show("숫자만 입력해주세요");
                return false;
            }
        }

    }
}
