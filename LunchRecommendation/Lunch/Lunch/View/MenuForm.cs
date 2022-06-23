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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();

            btnRoulette.BackColorChanged += (s, e) => 
            { 
                btnRoulette.FlatAppearance.MouseOverBackColor = btnRoulette.BackColor;
                btnRoulette.FlatAppearance.MouseDownBackColor = btnRoulette.BackColor;
                
            };

            btnRestList.BackColorChanged += (s, e) => 
            { 
                btnRestList.FlatAppearance.MouseOverBackColor = btnRestList.BackColor;
                btnRestList.FlatAppearance.MouseDownBackColor = btnRestList.BackColor;
            };
        }

        private void btnRestList_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new RestListForm());
        }

        private void btnRoulette_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new RouletteForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ConnectManager connectManager = new ConnectManager();
            string memberId = Properties.Settings.Default.LoginId;
            connectManager.AddConnLog(memberId, 'O');

            FormUtil.SwitchForm(this, new LoginForm());
        }

        private void btnRoulette_MouseEnter(object sender, EventArgs e)
        {
            btnRoulette.BackColor = Color.AliceBlue;
        }

        private void btnRoulette_MouseLeave(object sender, EventArgs e)
        {
            btnRoulette.BackColor = Color.Transparent;
        }

        private void btnRestList_MouseEnter(object sender, EventArgs e)
        {
            btnRestList.BackColor = Color.AliceBlue;
        }

        private void btnRestList_MouseLeave(object sender, EventArgs e)
        {
            btnRestList.BackColor = Color.Transparent;
        }
    }
}
