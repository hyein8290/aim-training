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
            string signature = txtSignature.Text;

            if(ValidateRestName(restName) && ValidateSignature(signature))
            {
                AddRest();
            }
        }

        private void AddRest()
        {
            RestManager restManager = new RestManager();

            
            if (restManager.AddRest() > 0)
            {
                MessageBox.Show("회원가입에 성공했습니다");
                this.mainForm.ShowPage(TYPE_PAGE.LOGIN_PAGE);
            }
            else
            {
                MessageBox.Show("회원가입에 실패했습니다.");
            }
        }

        private Boolean ValidateCategory()
        {
            foreach(Control radio in pnlCategory.Controls)
            {
                
            }
            return true;
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
