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
    public partial class RestEditForm : UserControl
    {
        private MainForm miainForm;

        private string restName = null;
        private string category = null;
        private string signature = null;

        public RestEditForm(MainForm mainForm)
        {
            InitializeComponent();
            this.miainForm = mainForm;
        }

        public RestEditForm(MainForm mainForm, Restaurant restaurant)
        {
            InitializeComponent();

            this.miainForm = mainForm;

            this.restName = restaurant.Name;
            this.category = restaurant.Category;
            this.signature = restaurant.Signature;
        }

        public void SetRestaurant(Restaurant restaurant)
        {
            this.restName = restaurant.Name;
            this.category = restaurant.Category;
            this.signature = restaurant.Signature;
        }

        private void RestEditForm_Load(object sender, EventArgs e)
        {
            if(restName != null)
            {
                this.txtRestName.Text = restName;
                
                foreach(RadioButton radio in pnlCategory.Controls)
                {
                    if (radio.Text.Equals(category))
                    {
                        radio.Checked = true;
                        break;
                    }
                }

                this.txtSignature.Text = signature;
            }
        }


    }
}
