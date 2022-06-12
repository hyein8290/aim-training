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
    public partial class MenuForm : UserControl
    {
        private MainForm mainForm;
        public MenuForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void picRoulette_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(TYPE_PAGE.ROULETTE_PAGE);
        }

        private void picRestList_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(TYPE_PAGE.REST_LIST_PAGE);
        }
    }
}
