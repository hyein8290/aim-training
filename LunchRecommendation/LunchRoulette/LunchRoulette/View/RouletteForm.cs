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
        public List<string> exceptRests = new List<string>();

        public RouletteForm()
        {
            InitializeComponent();
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
            //1. 물음표 없애기
            //2. 식당 추천해주기
            //3. 추천 버튼 이름 재추천으로 변경
            //4. 선택 버튼 추가
            picQuestion.Hide();
            //Label lblRouletteRest = new Label();
            //lblRouletteRest.Text = "사카나";
            //pnlRoulette.Controls.Add(lblRouletteRest);
            lblRestName.Text = "사카나";
            lblSignature.Text = "만천원초밥";
            lblRestName.Visible = true;
            lblSignature.Visible = true;

        }

        private void PlayRoulette()
        {
            
        }

        private void cblExcept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cblExcept.CheckedItems.Count == 5)
            {
                MessageBox.Show("제외음식을 5개 미만으로 선택해주세요");
                cblExcept.SetItemChecked(cblExcept.SelectedIndex, false);
            }
        }
    }
}
