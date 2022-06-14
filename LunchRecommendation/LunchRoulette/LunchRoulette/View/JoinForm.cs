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
    public partial class JoinForm : UserControl
    {
        public JoinForm()
        {
            InitializeComponent();

            // 이 녀석 자꾸 디자이너에서 사라져서 열로 옮김
            this.cboRank.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnJoin_Click(object sender, EventArgs e)
        {

        }
    }
}
