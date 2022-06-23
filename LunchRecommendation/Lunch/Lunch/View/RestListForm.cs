using Lunch.Common;
using Lunch.Data;
using Lunch.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lunch.View
{
    public partial class RestListForm : Form
    {
        public RestListForm()
        {
            InitializeComponent();
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ConnectManager connectManager = new ConnectManager();
            string memberId = Properties.Settings.Default.LoginId;
            connectManager.AddConnLog(memberId, 'O');

            FormUtil.SwitchForm(this, new LoginForm());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new MenuForm());
        }

        private void RestListForm_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'dsRestList.VWRESTLIST' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.vWRESTLISTTableAdapter.Fill(this.dsRestList.VWRESTLIST);

            CheckAll(cblCategory);
            this.dtpStart.Value = DateTime.Now.AddYears(-1);
            dgvRestList.CurrentCell = null;
            //dgvRestList.ClearSelection();
        }

        private void chkAll_Click(object sender, EventArgs e)
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

        private void cblCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblCategory.ClearSelected();
            if (cblCategory.CheckedItems.Count == 5)
            {
                chkAll.Checked = true;
            }
            else
            {
                chkAll.Checked = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRestListView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new RestAddForm());
        }

        private void LoadRestList()
        {
            RestaurantManager restManager = new RestaurantManager();
            DataSet ds = restManager.GetRestDataSet();
            dgvRestList.DataSource = ds.Tables[0].DefaultView;
        }

        private void LoadRestListView()
        {
            if (!ValidateCategoryCondition() || !ValidateUserCondition() || !ValidateDateCondition())
            {
                return;
            }

            List<string> categoryIdList = new List<string>();
            for (int i = 0; i < cblCategory.Items.Count; i++)
            {
                if (cblCategory.GetItemChecked(i) == true)
                {
                    categoryIdList.Add(cblCategory.Items[i].ToString());
                }
            }

            string joinedCategories = "'" + String.Join("', '", categoryIdList.ToArray()) + "'";

            string userName = txtUserName.Text;

            string startDate = dtpStart.Value.ToString("yyyy/MM/dd").Replace('-', '/');
            string endDate = dtpEnd.Value.ToString("yyyy/MM/dd").Replace('-', '/');

            RestaurantManager restManager = new RestaurantManager();
            DataSet ds = restManager.GetRestDataSet(joinedCategories, userName, startDate, endDate);
            dgvRestList.DataSource = ds.Tables[0].DefaultView;
        }

        private void dgvRestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                SelectCell(e);
                
                if (e.ColumnIndex == colEdit.Index)
                {
                    EditRestaurant(e);
                }
                else if (e.ColumnIndex == colDelete.Index)
                {
                    ShowDeleteMessage(e);
                }
            }
        }

        private void SelectCell(DataGridViewCellEventArgs e)
        {
            dgvRestList.Rows[e.RowIndex].Selected = true;
            dgvRestList.Rows[e.RowIndex].Cells[colEdit.Index].Selected = false;
            dgvRestList.Rows[e.RowIndex].Cells[colDelete.Index].Selected = false;
        }

        private void EditRestaurant(DataGridViewCellEventArgs e)
        {
            string restId = dgvRestList.Rows[e.RowIndex].Cells[0].Value.ToString();
            string restName = dgvRestList.Rows[e.RowIndex].Cells[1].Value.ToString();
            string signature = dgvRestList.Rows[e.RowIndex].Cells[2].Value.ToString();
            string category = dgvRestList.Rows[e.RowIndex].Cells[3].Value.ToString();

            Restaurant restaurant = new Restaurant();
            restaurant.RestId = Convert.ToInt32(restId);
            restaurant.RestName = restName;
            restaurant.Signature = signature;
            restaurant.Category = category;

            FormUtil.SwitchForm(this, new RestEditForm(restaurant));
        }

        private void ShowDeleteMessage(DataGridViewCellEventArgs e)
        {
            string restId = dgvRestList.Rows[e.RowIndex].Cells[0].Value.ToString();
            string restName = dgvRestList.Rows[e.RowIndex].Cells[1].Value.ToString();

            string message = $"'{restName}'을(를) 삭제하시겠습니까?";

            DialogResult result = MessageBox.Show(message, "삭제", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                RemoveRestaurant(restId, restName);
            }

            LoadRestList();
        }

        private void RemoveRestaurant(string restId, string restName)
        {
            RestaurantManager restManager = new RestaurantManager();

            if (restManager.DeleteRest(restId))
            {
                MessageBox.Show($"'{restName}'을(를) 삭제했습니다.");
            }
            else
            {
                MessageBox.Show("삭제를 실패했습니다.");
            }
        }

        private bool ValidateDateCondition()
        {
            DateTime startTime = dtpStart.Value;
            DateTime endTime = dtpEnd.Value;

            TimeSpan diff = endTime - startTime;

            if (diff.Ticks < 0)
            {
                MessageBox.Show("날짜를 다시 선택해주세요.");
                return false;
            }

            return true;
        }

        private bool ValidateCategoryCondition()
        {
            int count = 0;

            for (int i = 0; i < cblCategory.Items.Count; i++)
            {
                if (cblCategory.GetItemChecked(i) == false)
                    count++;
                else
                    return true;
            }

            if (count == cblCategory.Items.Count)
            {
                MessageBox.Show("카테고리를 하나 이상 선택해주세요");
            }
            return false;
        }

        private bool ValidateUserCondition()
        {
            string userName = txtUserName.Text;

            if (string.IsNullOrWhiteSpace(userName))
                return true;

            MemberManager userManager = new MemberManager();
            if (!userManager.ExistsUserName(userName))
            {
                MessageBox.Show("존재하지 않는 사용자입니다.");
                return false;
            }
            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetOptions();
            LoadRestList();
            dgvRestList.ClearSelection();
        }

        private void ResetOptions()
        {
            this.chkAll.Checked = true;
            CheckAll(cblCategory);
            this.txtUserName.ResetText();
            this.dtpStart.Value = DateTime.Now.AddYears(-1);
            this.dtpEnd.ResetText();
        }

    }
}
