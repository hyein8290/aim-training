using LunchRoulette.Common;
using LunchRoulette.Data;
using LunchRoulette.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunchRoulette.View
{
    public partial class RestListForm : UserControl
    {
        private MainForm mainForm;
        public RestListForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;   
        }
        private void RestListForm_Load(object sender, EventArgs e)
        {
            //Task task = new Task(delegate
            //{
            //    NewMethod();
            //});
            //task.Start();

            //Thread cThread = new Thread(NewMethod);
            //cThread.Start();

            LoadRestList();
            CheckAll(cblCategory);


        }

        public void LoadRestList()
        {
            RestManager restManager = new RestManager();
            DataSet ds = restManager.GetRestDataSet();
            dgvRestList.DataSource = ds.Tables[0].DefaultView;

            //NewMethod();

        }

        private void NewMethod()
        {
            string query = "select * from vwrestlist";
            OleDbDataAdapter da = new OleDbDataAdapter(query, DbUtil.connection);
            OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);

            da.Update(dsRestaurant.Tables[0]);
            this.dsRestaurant.Tables[0].Clear();
            da.Fill(dsRestaurant.Tables[0]);
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
            ValidateCondition();

            LoadRestListView();

        }

        private void LoadRestListView()
        {
            List<string> categories = new List<string>();
            for (int i = 0; i < cblCategory.Items.Count; i++)
            {
                if (cblCategory.GetItemChecked(i) == true)
                {
                    categories.Add(cblCategory.Items[i].ToString());
                }
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

        private void btnAddRest_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(TYPE_PAGE.REST_ADD_PAGE);   
        }

        private void dgvRestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colEdit.Index)
            {
                //string name = dgvRestList.Rows[e.RowIndex].Cells["식당이름"].Value.ToString();
                //string name = dgvRestList.Rows[e.RowIndex].Cells["RESTNAME"].Value.ToString();
                EditRestaurant(e);
            }
            else if (e.ColumnIndex == colDelete.Index)
            {
                ShowDeleteMessage(e);
            }
        }

        private void ShowDeleteMessage(DataGridViewCellEventArgs e)
        {
            string name = dgvRestList.Rows[e.RowIndex].Cells[0].Value.ToString();

            string message = String.Format("'{0}'을(를) 삭제하시겠습니까?", name);

            DialogResult result = MessageBox.Show(message, "삭제", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes)
            {
                RemoveRestaurant(name);
            }

            LoadRestList();
        }

        private void RemoveRestaurant(string name)
        {
            RestManager restManager = new RestManager();
            if(restManager.DeleteRest(name))
            {
                MessageBox.Show($"'{name}'을(를) 삭제했습니다.");
            }
            else
            {
                MessageBox.Show("삭제를 실패했습니다.");
            }
        }

        private void EditRestaurant(DataGridViewCellEventArgs e)
        {
            string name = dgvRestList.Rows[e.RowIndex].Cells[0].Value.ToString();
            string signature = dgvRestList.Rows[e.RowIndex].Cells[1].Value.ToString();
            string category = dgvRestList.Rows[e.RowIndex].Cells[2].Value.ToString();

            Restaurant restaurant = new Restaurant();
            restaurant.Name = name;
            restaurant.Signature = signature;
            restaurant.Category = category;

            LoadRestList();

            mainForm.RestEditForm.SetRestaurant(restaurant);
            mainForm.ShowPage(TYPE_PAGE.REST_EDIT_PAGE);

            //LoadRestList();

        }

    }
}
