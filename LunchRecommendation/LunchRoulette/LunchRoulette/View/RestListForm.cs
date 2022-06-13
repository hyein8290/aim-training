using LunchRoulette.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LunchRoulette.View
{
    public partial class RestListForm : UserControl
    {
        public RestListForm()
        {
            InitializeComponent();
            
        }
        private void RestListForm_Load(object sender, EventArgs e)
        {
            LoadRestList();
            CheckAll(cblCategory);
        }

        private void LoadRestList()
        {
            RestManager restManager = new RestManager();
            DataSet ds = restManager.GetRestDataSet();
            //DsRestList ds = (DsRestList)restManager.GetRestDataSet();
            dgvRestList.DataSource = ds.Tables[0].DefaultView;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true) CheckAll(cblCategory);
            else UnCheckAll(cblCategory);
        }

        private void CheckAll(CheckedListBox checkedListBox)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
            }
        }

        private void UnCheckAll(CheckedListBox checkedListBox)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, false);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //ValidateCondition();

            List<string> categories = new List<string>();
            for(int i = 0; i < cblCategory.Items.Count; i++)
            {
                categories.Add(cblCategory.Items[i].ToString());
            }

            string userName = txtUserName.Text;

            string startDate = dtpStart.Value.ToString("yyyy/MM/dd").Replace('-', '/');
            string endDate = dtpEnd.Value.ToString("yyyy/MM/dd").Replace('-', '/');

            RestManager restManager = new RestManager();
            DataSet ds = restManager.GetRestDataSet(categories, userName, startDate, endDate);
            dgvRestList.DataSource = ds.Tables[0].DefaultView;

        }

        private void ValidateCondition()
        {
            // TODO boolean으로 바꾸자
            ValidateCategoryCondition();
            ValidateUserCondition();
            ValidateDateCondition();
        }

        private void ValidateCategoryCondition()
        {
            int count = 0;

            for (int i = 0; i < cblCategory.Items.Count; i++)
            {
                if (cblCategory.GetItemChecked(i) == false)
                    count++;
                else
                    break;
            }

            if (count == cblCategory.Items.Count)
            {
                MessageBox.Show("카테고리를 하나 이상 선택해주세요");
            }
        }

        private void ValidateUserCondition()
        {
            // TODO 변수명 고민
            string userName = txtUserName.Text;
            UserManager userManager = new UserManager();
            if (!userManager.ExistsUserName(userName))
            {
                MessageBox.Show("존재하지 않는 사용자입니다.");
            }
        }

        private void ValidateDateCondition()
        {
            DateTime startTime = dtpStart.Value;
            DateTime endTime = dtpEnd.Value;

            TimeSpan diff = endTime - startTime;

            if (diff.Ticks < 0)
            {
                MessageBox.Show("날짜를 다시 선택해주세요.");
            }
        }

        private void dgvRestList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //dgvRestList;
            }
        }

        private void btnAddRest_Click(object sender, EventArgs e)
        {

        }
    }
}
