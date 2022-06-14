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
    public partial class JoinForm : UserControl
    {
        private MainForm mainForm;
        private UserManager userManager;
        public JoinForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // 이 녀석 자꾸 디자이너에서 사라져서 열로 옮김
            this.cboRank.SelectedIndex = 0;
            userManager = new UserManager();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(TYPE_PAGE.LOGIN_PAGE);
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            string id = txtUserId.Text;
            string name = txtUserName.Text;
            string rank = cboRank.SelectedItem.ToString();

            if(ValidateUserId(id) && ValidateUserName(name) && ValidateRank(rank))
            {
                JoinUser(id, name, rank);
            }
        }

        private void JoinUser(string id, string name, string rank)
        {
            if (userManager.JoinUser(id, name, rank) > 0)
            {
                MessageBox.Show("회원가입에 성공했습니다");
                this.mainForm.ShowPage(TYPE_PAGE.LOGIN_PAGE);
            }
            else
            {
                MessageBox.Show("회원가입에 실패했습니다.");
            }
        }

        private Boolean ValidateUserId(string userId)
        {
            if(userId == null || userId.Length == 0)
            {
                MessageBox.Show("사번을 입력해주세요");
                return false;
            }

            if(!int.TryParse(userId, out int result))
            {
                MessageBox.Show("숫자만 입력해주세요");
                return false;
            }

            if (userManager.ExistsUserId(userId))
            {
                MessageBox.Show("이미 존재하는 사번입니다.");
                return false;
            }

            return true;
        }

        private Boolean ValidateUserName(string userName)
        {
            if (userName == null || userName.Length == 0)
            {
                MessageBox.Show("이름 입력해주세요");
                return false;
            }

            return true;
        }

        private Boolean ValidateRank(string rank)
        {
            if(cboRank.SelectedIndex == 0)
            {
                MessageBox.Show("직급을 선택해주세요");
                return false;
            }

            return true;
        }
    }
}
