using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class MainForm : Form
    {
        public enum TYPE_PAGE
        {
            INIT_PAGE = 0,          // 시작 페이지
            CONNECT_SERVER = 1,     // 서버 접속 페이지 
            SET_NAME = 2,           // 이름 설정 페이지 
            CHAT_PAGE = 3,          // 채팅 페이지 
            __MAX__                 // TODO max가 정확히 뭘까
        };

        public InitForm initForm = null;
        public ConnectForm connectServerForm = null;
        public SetNameForm setNameForm = null;
        public ChatForm chatForm = null;

        public MainForm()
        {
            InitializeComponent();

            initForm = new InitForm(this);
            connectServerForm = new ConnectForm(this);
            setNameForm = new SetNameForm(this);
            chatForm = new ChatForm(this);
            
            ShowPage(TYPE_PAGE.INIT_PAGE);

        }

        public void ShowPage(TYPE_PAGE eIndex)
        {
            initForm.Visible = false;
            connectServerForm.Visible = false;
            setNameForm.Visible = false;
            chatForm.Visible = false;

            if (TYPE_PAGE.INIT_PAGE == eIndex)
            {
                initForm.LoadConnectState();
                initForm.Visible = true;
                this.mainPanel.Controls.Add(initForm);
            }
            else if (TYPE_PAGE.CONNECT_SERVER == eIndex)
            {
                connectServerForm.Visible = true;
                this.mainPanel.Controls.Add(connectServerForm);
            }
            else if (TYPE_PAGE.SET_NAME == eIndex)
            {
                setNameForm.Visible = true;
                this.mainPanel.Controls.Add(setNameForm);
            }
            else if (TYPE_PAGE.CHAT_PAGE == eIndex)
            {
                chatForm.Visible = true;
                this.mainPanel.Controls.Add(chatForm);
            }
        }
    }
}
