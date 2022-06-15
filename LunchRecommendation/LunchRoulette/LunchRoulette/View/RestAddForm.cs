using LunchRoulette.Common;
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
    public partial class RestAddForm : UserControl
    {
        private MainForm mainForm;
        public RestAddForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(TYPE_PAGE.REST_LIST_PAGE);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string restName = txtRestName.Text;
            string category = GetCategory();
            string signature = txtSignature.Text;

            if(ValidateRestName(restName) && ValidateSignature(signature))
            {
                AddRest(restName, category, signature);
            }
        }

        private void AddRest(string restName, string category, string signature)
        {
            RestManager restManager = new RestManager();

            
            //if (restManager.AddRest(restName, category, signature) > 0)
            if (restManager.InsertRest(restName, category, signature))
            {
                MessageBox.Show(String.Format("'{0}'을(를) 추가했습니다.", restName));
                this.mainForm.ShowPage(TYPE_PAGE.REST_LIST_PAGE);
            }
            else
            {
                MessageBox.Show("식당을 추가에 실패했습니다.");
            }
        }

        // 메소드 이름 고민,,
        // GetCategory vs ValidateCategory
        private string GetCategory()
        {
            foreach(RadioButton radio in pnlCategory.Controls)
            {
                if (radio.Checked)
                {
                    return radio.Text;
                }
            }

            return null;
        }

        private Boolean ValidateRestName(string restName)
        {
            RestManager restManager = new RestManager();

            if (restName == null || restName.Length == 0)
            {
                MessageBox.Show("식당 이름을 입력해주세요");
                return false;
            }

            if (restManager.ExistsRest(restName))
            {
                MessageBox.Show("같은 이름의 식당이 존재합니다.");
                return false;
            }

            return true;
        }

        private Boolean ValidateSignature(string signature)
        {
            if (signature == null || signature.Length == 0)
            {
                MessageBox.Show("시그니처 메뉴를 입력해주세요");
                return false;
            }

            return true;
        }
    }
}
