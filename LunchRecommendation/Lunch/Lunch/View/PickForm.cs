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
    public partial class PickForm : Form
    {
        private string restName;
        public PickForm(string restName)
        {
            InitializeComponent();
            this.restName = restName;
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ConnectManager connectManager = new ConnectManager();
            string memberId = Properties.Settings.Default.LoginId;
            connectManager.AddConnLog(memberId, 'O');

            FormUtil.SwitchForm(this, new LoginForm());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new MenuForm());
        }

        private void btnRestList_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new RestListForm());
        }

        private void btnRoulette_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new RouletteForm());
        }

        private void PickForm_Load(object sender, EventArgs e)
        {
            lblRestName.Text = $"{restName}을(를) 선택하셨습니다.";

            lblRestName.Location = new Point((this.pnlPickInfo.Width - lblRestName.Width) / 2, 37); 
        }

    }
}
