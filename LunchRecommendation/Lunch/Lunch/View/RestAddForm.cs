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
    public partial class RestAddForm : Form
    {
        public RestAddForm()
        {
            InitializeComponent();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new RestListForm());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string restName = txtRestName.Text;
            string category = GetCategory();
            string signature = txtSignature.Text;

            if (ValidateRestName(restName) && ValidateSignature(signature) && ValidateCategory(category))
            {
                AddRest(restName, category, signature);
            }
        }

        private string GetCategory()
        {
            foreach (RadioButton radio in pnlCategory.Controls)
            {
                if (radio.Checked)
                {
                    return radio.Text;
                }
            }

            return null;
        }

        private bool ValidateRestName(string restName)
        {
            RestaurantManager restManager = new RestaurantManager();

            if (string.IsNullOrEmpty(restName))
            {
                MessageBox.Show("식당 이름을 입력해주세요");
                return false;
            }

            if (restManager.ExistsRestName(restName))
            {
                MessageBox.Show("같은 이름의 식당이 존재합니다.");
                return false;
            }

            return true;
        }

        private bool ValidateSignature(string signature)
        {
            if (string.IsNullOrEmpty(signature))
            {
                MessageBox.Show("시그니처 메뉴를 입력해주세요");
                return false;
            }

            return true;
        }

        private bool ValidateCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("카테고리를 선택해주세요");
                return false;
            }

            return true;
        }

        private void AddRest(string restName, string category, string signature)
        {
            RestaurantManager restManager = new RestaurantManager();

            if (restManager.InsertRest(restName, category, signature))
            {
                MessageBox.Show(String.Format("'{0}'을(를) 추가했습니다.", restName));
                FormUtil.SwitchForm(this, new RestListForm());
            }
            else
            {
                MessageBox.Show("식당을 추가에 실패했습니다.");
            }
        }

        private void RestAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectManager connectManager = new ConnectManager();
            string memberId = Properties.Settings.Default.LoginId;
            connectManager.AddConnLog(memberId, 'O');
        }
    }
}
