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
    public partial class RestEditForm : UserControl
    {
        private MainForm mainForm;

        private string orgRestName = null;
        private string category = null;
        private string signature = null;

        public RestEditForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public RestEditForm(MainForm mainForm, Restaurant restaurant)
        {
            InitializeComponent();

            this.mainForm = mainForm;

            this.orgRestName = restaurant.Name;
            this.category = restaurant.Category;
            this.signature = restaurant.Signature;
        }

        public void SetRestaurant(Restaurant restaurant)
        {
            this.orgRestName = restaurant.Name;
            this.category = restaurant.Category;
            this.signature = restaurant.Signature;
        }

        private void RestEditForm_Load(object sender, EventArgs e)
        {
            if(orgRestName != null)
            {
                this.txtRestName.Text = orgRestName;
                
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(TYPE_PAGE.REST_LIST_PAGE);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            RestManager restManager = new RestManager();

            string modName = txtRestName.Text;
            string modSignature = txtSignature.Text;
            string modCategory = null;

            foreach(RadioButton radio in pnlCategory.Controls)
            {
                if (radio.Checked)
                {
                    modCategory = radio.Text;
                    break;
                }
            }

            if (restManager.UpdateRest(orgRestName, modName, modCategory, modSignature))
            {
                MessageBox.Show($"'{orgRestName}'을(를) 편집했습니다.");
                this.mainForm.ShowPage(TYPE_PAGE.REST_LIST_PAGE);
            }
            else
            {
                MessageBox.Show("식당을 추가에 실패했습니다.");
            }
        }
    }
}
