using LunchRoulette.Common;
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
    public partial class PickForm : UserControl
    {
        private string restName;
        private MainForm mainForm;
        public PickForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public void SetPickRest(string restName)
        {
            this.restName = restName;
            lblRestName.Text = $"{restName}을(를) 선택하셨습니다.";
        }

        private void btnRestList_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(TYPE_PAGE.REST_LIST_PAGE);
        }

        private void btnRoulette_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(TYPE_PAGE.ROULETTE_PAGE);
        }
    }
}
