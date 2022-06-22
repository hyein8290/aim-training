using Lunch.Common;
using Lunch.Data;
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
    public partial class RestEditForm : Form
    {
        private int restId;
        private string orgRestName;
        private string orgCategory;
        private string orgSignature;

        public RestEditForm(Restaurant restaurant)
        {
            InitializeComponent();
            this.restId = restaurant.RestId;
            this.orgRestName = restaurant.RestName;
            this.orgCategory = restaurant.Category;
            this.orgSignature = restaurant.Signature;
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

        private void RestEditForm_Load(object sender, EventArgs e)
        {
            this.txtRestName.Text = orgRestName;

            foreach (RadioButton radio in pnlCategory.Controls)
            {
                if (radio.Text.Equals(orgCategory))
                {
                    radio.Checked = true;
                    break;
                }
            }

            this.txtSignature.Text = orgSignature;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new RestListForm());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            RestaurantManager restManager = new RestaurantManager();

            string modName = txtRestName.Text;
            string modSignature = txtSignature.Text;
            string modCategory = null;

            foreach (RadioButton radio in pnlCategory.Controls)
            {
                if (radio.Checked)
                {
                    modCategory = radio.Text;
                    break;
                }
            }

            if (restManager.UpdateRestaurant(restId, modName, modCategory, modSignature))
            {
                MessageBox.Show($"'{orgRestName}'을(를) 편집했습니다.");
                FormUtil.SwitchForm(this, new RestListForm());
            }
            else
            {
                MessageBox.Show($"'{orgRestName}'을(를) 편집하지 못했습니다.");
            }
        }

        private void RestEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectManager connectManager = new ConnectManager();
            string memberId = Properties.Settings.Default.LoginId;
            connectManager.AddConnLog(memberId, 'O');
        }
    }
}
