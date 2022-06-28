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
    public partial class RouletteForm : Form
    {
        public List<string> exceptRestNameList = new List<string>();
        private string currentRestId;
        private string currentRestName;
        private int rnum = 0;

        public RouletteForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ConnectManager connectManager = new ConnectManager();
            string memberId = Properties.Settings.Default.LoginId;
            connectManager.AddConnLog(memberId, 'O');
            Properties.Settings.Default.LoginId = null;

            FormUtil.SwitchForm(this, new LoginForm());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new MenuForm());
        }

        private void cblExcept_SelectedIndexChanged(object sender, EventArgs e)
        {
            rnum = 0;
            cblPrefer.SetItemChecked(cblExcept.SelectedIndex, false);

            if (cblExcept.CheckedItems.Count == 5)
            {
                MessageBox.Show("제외음식을 5개 미만으로 선택해주세요");
                cblExcept.SetItemChecked(cblExcept.SelectedIndex, false);
            }
        }

        private void cblPrefer_SelectedIndexChanged(object sender, EventArgs e)
        {
            rnum = 0;
            cblExcept.SetItemChecked(cblPrefer.SelectedIndex, false);
        }

        private void btnExceptRest_Click(object sender, EventArgs e)
        {
            rnum = 0;
            string restName = txtExceptRest.Text;
            if (!string.IsNullOrEmpty(restName))
            {
                AddExceptRest(restName);
            }
            else
            {
                MessageBox.Show("식당이름을 입력해주세요.");
            }
        }

        private void AddExceptRest(string restName)
        {
            RestaurantManager restManager = new RestaurantManager();
            if (restManager.ExistsRestName(restName))
            {
                txtExceptRest.Text = "";
                ExceptRestControl exceptRestControl = new ExceptRestControl(this, restName);
                tlpExceptRest.Controls.Add(exceptRestControl);

                exceptRestNameList.Add(restName);
            }
            else
            {
                MessageBox.Show("존재하지 않는 식당입니다.");
            }
        }

        private void btnRoulette_Click(object sender, EventArgs e)
        {
            picQuestion.Visible = false;
            GetOptions();
        }

        private void GetOptions()
        {
            List<int> preferCategory = new List<int>();
            List<int> exceptCategory = new List<int>();

            for (int i = 0; i < cblPrefer.Items.Count; i++)
            {
                if (cblPrefer.GetItemChecked(i) == true)
                {
                    preferCategory.Add(i + 101);
                }
            }

            for (int i = 0; i < cblExcept.Items.Count; i++)
            {
                if (cblExcept.GetItemChecked(i) == true)
                {
                    exceptCategory.Add(i + 101);
                }
            }

            string strPreferCategory = String.Join(", ", preferCategory.ToArray());
            string strExceptCategory = String.Join(", ", exceptCategory.ToArray());
            string strExceptRestName = "'" + String.Join("', '", exceptRestNameList.ToArray()) + "'";

            if (preferCategory.Count == 0)
            {
                strPreferCategory = "0";
            }

            if (exceptCategory.Count == 0)
            {
                strExceptCategory = "0";
            }

            if (exceptRestNameList.Count == 0)
            {
                strExceptRestName = "' '";
            }

            PlayRoulette(strPreferCategory, strExceptCategory, strExceptRestName);
        }

        private void PlayRoulette(string preferCategory, string exceptCategory, string exceptRestName)
        {
            RestaurantManager restManager = new RestaurantManager();
            Restaurant restaurant = restManager.GetRandomRestaurant(preferCategory, exceptCategory, exceptRestName, rnum++ % 5 + 1);

            if (restaurant == null || rnum > 5)
            {
                rnum = 0;
                MessageBox.Show("모든 추천이 끝났습니다");
            }
            else
            {
                currentRestId = restaurant.RestId.ToString();
                currentRestName = restaurant.RestName;

                lblRestName.Text = restaurant.RestName;
                lblSignature.Text = restaurant.Signature;

                lblRestName.Location = new Point((this.pnlRoulette.Width - lblRestName.Width) / 2, 30);
                lblSignature.Location = new Point((this.pnlRoulette.Width - lblSignature.Width) / 2, 80);
            }

            lblRestName.Visible = true;
            lblSignature.Visible = true;    

            btnReroulette.Visible = true;
            btnPick.Visible = true;

            btnRoulette.Visible = false;
        }

        private void btnReroulette_Click(object sender, EventArgs e)
        {
            GetOptions();
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            try
            {
                RestaurantManager restManager = new RestaurantManager();
                restManager.AddPickLog(currentRestId);
                FormUtil.SwitchForm(this, new PickForm(currentRestName));
            }
            catch
            {
                MessageBox.Show("식당을 선택할 수 없습니다.");
            }
        }
    }
}
