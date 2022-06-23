using Lunch.Common;
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
    public partial class JoinForm : Form
    {
        private MemberManager memberManager;
        private EnumManager enumManager;
        public JoinForm()
        {
            InitializeComponent();
            memberManager = new MemberManager();
            enumManager = new EnumManager();
        }

        private void txtUserId_Enter(object sender, EventArgs e)
        {
            if (txtUserId.Text == "아이디")
            {
                txtUserId.Text = "";
                txtUserId.ForeColor = Color.Black;
            }
        }

        private void txtUserId_Leave(object sender, EventArgs e)
        {
            if (txtUserId.Text == "")
            {
                txtUserId.Text = "아이디";
                txtUserId.ForeColor = Color.Gray;
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "이름")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.Black;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "이름";
                txtUserName.ForeColor = Color.Gray;
            }
        }

        // TODO 콤보박스에서 데이터 바인딩하고 선택할 때, 사원이 사라짐..
        private void JoinForm_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'dsPosition.ENUM' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            //this.eNUMTableAdapter.Fill(this.dsPosition.ENUM);
            this.cboPosition.SelectedIndex = 0;
        }

        private void cboPosition_Enter(object sender, EventArgs e)
        {
            cboPosition.ForeColor = Color.Black;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormUtil.SwitchForm(this, new LoginForm());
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            string memberId = txtUserId.Text;
            string memberName = txtUserName.Text;
            string position = cboPosition.SelectedItem.ToString();

            string positionId = enumManager.GetEnumId("position", position);

            if (ValidateUserId(memberId) && ValidateUserName(memberName) && ValidatePosition(positionId))
            {
                JoinUser(memberId, memberName, positionId);
            }
        }
        private void JoinUser(string memberId, string memberName, string positionId)
        {
            if (memberManager.AddMember(memberId, memberName, positionId) > 0)
            {
                MessageBox.Show("회원가입에 성공했습니다");
                FormUtil.SwitchForm(this, new LoginForm());
            }
            else
            {
                MessageBox.Show("회원가입에 실패했습니다.");
            }
        }

        private bool ValidatePosition(string position)
        {
            if(position == null)
            {
                MessageBox.Show("직급을 선택해주세요");
                return false;
            }

            return true;
        }

        private bool ValidateUserName(string memberName)
        {
            if (memberName.Equals("이름"))
            {
                MessageBox.Show("이름을 입력해주세요");
                return false;
            }

            return true;
        }

        private bool ValidateUserId(string memberId)
        {
            if (memberId.Equals("아이디"))
            {
                MessageBox.Show("아이디를 입력해주세요");
                return false;
            }

            if (memberManager.ExistsMemberId(memberId))
            {
                MessageBox.Show("이미 존재하는 아이디입니다.");
                return false;
            }

            return true;
        }
        
    }
}
