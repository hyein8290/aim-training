using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class ConnectForm : UserControl
    {
        public MainForm mainForm;

        public ConnectForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        // TODO 취소 버튼

        private void connectBtn_Click(object sender, EventArgs e)
        {
            string ip = ipTextBox.Text;
            int port = int.Parse(portTextBox.Text);

            // TODO 유효성 검사

            Client.getInstance(ip, port);
            mainForm.ShowPage(MainForm.TYPE_PAGE.INIT_PAGE);
            
        }
    }
}
