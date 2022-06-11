using LunchRoulette.Common;
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
    public partial class MainForm : Form
    {

        private LoginForm loginForm;
        private JoinForm joinForm;
        private MenuForm menuForm;
        private RestListForm restListForm;
        private RestAddForm restAddForm;
        private RestEditForm restEditForm;
        private RouletteForm rouletteForm;
        private PickForm pickForm;

        public MainForm()
        {
            InitializeComponent();

            InitForm();

            ShowPage(TYPE_PAGE.LOGIN_PAGE);
            DbUtil.ConnectDatabase();

        }

        public void InitForm()
        {
            loginForm = new LoginForm(this);
            joinForm = new JoinForm();
            menuForm = new MenuForm();
            restListForm = new RestListForm();
            restAddForm = new RestAddForm();
            restEditForm = new RestEditForm();
            rouletteForm = new RouletteForm();
            pickForm = new PickForm();
        }

        public void ShowPage(TYPE_PAGE type)
        {
            HideAllPages();

            if(type == TYPE_PAGE.LOGIN_PAGE)
            {
                loginForm.Visible = true;
                this.pnlMain.Controls.Add(loginForm);
            }
        }

        private void HideAllPages()
        {
            loginForm.Visible = false;
            joinForm.Visible = false;
            menuForm.Visible = false;
            restListForm.Visible = false;
            restAddForm.Visible = false;
            restEditForm.Visible = false;
            rouletteForm.Visible = false;
            pickForm.Visible = false;
        }



    }
}
