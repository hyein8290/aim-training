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
            menuForm = new MenuForm(this);
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
            else if(type == TYPE_PAGE.JOIN_PAGE)
            {
                joinForm.Visible = true;
                this.pnlMain.Controls.Add(joinForm);
            }
            else if(type == TYPE_PAGE.MENU_PAGE)
            {
                menuForm.Visible = true;
                this.pnlMain.Controls.Add(menuForm);
            }
            else if(type == TYPE_PAGE.REST_LIST_PAGE)
            {
                restListForm.Visible = true;
                this.pnlMain.Controls.Add(restListForm);
            }
            else if(type == TYPE_PAGE.REST_ADD_PAGE)
            {
                restAddForm.Visible = true;
                this.pnlMain.Controls.Add(restAddForm);
            }
            else if(type == TYPE_PAGE.REST_EDIT_PAGE)
            {
                restEditForm.Visible = true;
                this.pnlMain.Controls.Add(restEditForm);
            }
            else if(type == TYPE_PAGE.ROULETTE_PAGE)
            {
                rouletteForm.Visible = true;
                this.pnlMain.Controls.Add(rouletteForm);
            }
            else if(type == TYPE_PAGE.PICK_PAGE)
            {
                pickForm.Visible = true;
                this.pnlMain.Controls.Add(pickForm);
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
