using LunchRoulette.Common;
using LunchRoulette.Data;
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
    public partial class RouletteForm : UserControl
    {
        private MainForm mainForm;
        private int rnum = 1;

        public List<string> exceptRests = new List<string>();

        public RouletteForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void RouletteForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExceptRest_Click(object sender, EventArgs e)
        {
            string restName = txtExceptRest.Text;
            AddExceptRest(restName);
        }

        private void AddExceptRest(string restName)
        {
            RestManager restManager = new RestManager();
            if (restManager.ExistsRest(restName))
            {
                txtExceptRest.Text = "";
                ExceptRestControl exceptRestControl = new ExceptRestControl(this, restName);
                tlpExceptRest.Controls.Add(exceptRestControl);

                exceptRests.Add(restName);
            }
            else
            {
                MessageBox.Show("존재하지 않는 식당입니다.");
            }
        }


        private void btnRoulette_Click(object sender, EventArgs e)
        {
            //1. 물음표 없애기 O 
            //2. 식당 추천해주기 O
            //3. 추천 버튼 이름 재추천으로 변경
            //4. 선택 버튼 추가
            picQuestion.Hide();

            // TODO 수정!!
            GetOptions();
        }

        private void GetOptions()
        {
            List<string> preferCategory = new List<string>();
            List<string> exceptCategory = new List<string>();


            foreach (string c in cblPrefer.CheckedItems)
            {
                preferCategory.Add(c);
            }

            foreach (string c in cblExcept.CheckedItems)
            {
                exceptCategory.Add(c);
            }

            string strPreferCategory = "'" + String.Join("', '", preferCategory.ToArray()) + "'";
            string strExceptCategory = "'" + String.Join("', '", exceptCategory.ToArray()) + "'";
            string strExceptRestName = "'" + String.Join("', '", exceptRests.ToArray()) + "'";

            PlayRoulette(strPreferCategory, strExceptCategory, strExceptRestName);
        }

        private void PlayRoulette(string preferCategory, string exceptCategory, string exceptRestName)
        {
            RestManager restManager = new RestManager();
            Restaurant restaurant = restManager.GetRecomRestaurant(preferCategory, exceptCategory, exceptRestName, rnum++%5);
            if(restaurant != null)
            {
                lblRestName.Text = restaurant.Name;
                lblSignature.Text = restaurant.Signature;
            }

            lblRestName.Visible = true;
            lblSignature.Visible = true;

            btnReroulette.Visible = true;
            btnPick.Visible = true;

            btnRoulette.Visible = false;
        }

        private void cblExcept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cblExcept.CheckedItems.Count == 5)
            {
                MessageBox.Show("제외음식을 5개 미만으로 선택해주세요");
                cblExcept.SetItemChecked(cblExcept.SelectedIndex, false);
            }
        }

        private void btnReroulette_Click(object sender, EventArgs e)
        {
            GetOptions();
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            string restName = lblRestName.Text;

            RestManager restManager = new RestManager();
            restManager.AddPickLog(restName);
            mainForm.PickForm.SetPickRest(restName);
            mainForm.ShowPage(TYPE_PAGE.PICK_PAGE);
        }
    }
}
