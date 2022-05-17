using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class SetNameForm : UserControl
    {
        public MainForm mainForm;

        public SetNameForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        // TODO 취소 버튼

        private void setNameBtn_Click(object sender, EventArgs e)
        {
            Client client = Client.getInstance();
            client.Name = nameTextBox.Text;
            mainForm.initForm.LoadConnectState();
            mainForm.ShowPage(MainForm.TYPE_PAGE.INIT_PAGE);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mainForm.ShowPage(MainForm.TYPE_PAGE.INIT_PAGE);
        }
    }
}
