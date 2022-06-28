using Lunch.Common;
using Lunch.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lunch.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void txtUserId_Enter(object sender, EventArgs e)
        {
            if (txtUserId.Text == "아이디")
            {
                txtUserId.Text = "";
                txtUserId.ForeColor = Color.Black;
            }
        }

        private void txtUserId_Leave(object sender, EventArgs e)
        {
            if (txtUserId.Text == "")
            {
                txtUserId.Text = "아이디";
                txtUserId.ForeColor = Color.Gray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string memberId = txtUserId.Text;
            
            if (!string.IsNullOrEmpty(memberId))
            {
                Login(memberId);
            }
        }

        private void Login(string memberId)
        {
            MemberManager memberManager = new MemberManager();
            ConnectManager connectManager = new ConnectManager();

            if (memberManager.isLoggedin(memberId))
            {
                MessageBox.Show("이미 접속 중인 아이디입니다.");
                return;
            }

            if (memberManager.ExistsMemberId(memberId))
            {
                connectManager.AddConnLog(memberId, 'I');
                Properties.Settings.Default.LoginId = memberId;
                FormUtil.SwitchForm(this, new MenuForm());
            }
            else
            {
                MessageBox.Show("존재하지 않는 회원입니다.");
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new JoinForm());
        }

        private void txtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string memberId = txtUserId.Text;

                if (!string.IsNullOrEmpty(memberId))
                {
                    Login(memberId);
                }
            }
        }


    }
}
