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
    public partial class ExceptRestControl : UserControl
    {
        private RouletteForm rouletteForm;
        public ExceptRestControl()
        {
            InitializeComponent();
        }
        public ExceptRestControl(RouletteForm rouletteForm, string restName)
        {
            InitializeComponent();
            this.rouletteForm = rouletteForm;
            lblExceptRest.Text = restName;
        }

        private void btnCancelExcept_Click(object sender, EventArgs e)
        {
            rouletteForm.exceptRests.Remove(lblExceptRest.Text);
            this.Dispose();
        }
    }
}
