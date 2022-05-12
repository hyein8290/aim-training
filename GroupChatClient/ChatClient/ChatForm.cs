using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class ChatForm : UserControl
    {
        public MainForm mainForm;
        private Client client;
        private int MAX_MESSAGE_LINES = int.MaxValue;

        public ChatForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // TODO 임시. 나중에 삭제
            client = Client.getInstance("127.0.0.1", 9000);
            client.Name = "test";
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            // TODO 메시지 유효성 검사
            SendMessage(messageTextBox.Text);
            messageTextBox.Clear();
        }

        // TODO 뒤로가기 버튼

        private void SendMessage(string message)
        {
            client = Client.getInstance();

            int messageByteCounts = Encoding.UTF8.GetByteCount(message);

            byte[] headerBytes = new byte[4];
            byte[] bodyBytes = new byte[messageByteCounts];
            byte[] messageBytes = new byte[headerBytes.Length + bodyBytes.Length];

            headerBytes = BitConverter.GetBytes(messageByteCounts);
            bodyBytes = Encoding.UTF8.GetBytes(message);

            Array.Copy(headerBytes, 0, messageBytes, 0, headerBytes.Length);
            Array.Copy(bodyBytes, 0, messageBytes, headerBytes.Length, bodyBytes.Length);

            client.Writer.Write(messageBytes, 0, messageBytes.Length);

            client.Writer.Flush();
        }

        private void ReceiveMessage()
        {
            client = Client.getInstance();

            while (true)
            {
                byte[] outbuf = new byte[1024];
                int size = client.Reader.Read(outbuf, 0, outbuf.Length);
                string output = Encoding.UTF8.GetString(outbuf, 0, size);

                AddMessage(output);
            }
        }

        private void AddMessage(string message)
        {
            if(txtMessage.InvokeRequired)
            {
                Action<string> action = new Action<string>(AddMessage);
                txtMessage.Invoke(action, message);
            }
            else
            {
                txtMessage.AppendText(message);
                txtMessage.AppendText(Environment.NewLine);

                CutMessageLines();
            }
        }

        private void CutMessageLines()
        {
            if (txtMessage.Lines.Length > MAX_MESSAGE_LINES + 1)
            {
                LinkedList<string> tempLines = new LinkedList<string>(txtMessage.Lines);
                while ((tempLines.Count - MAX_MESSAGE_LINES) > 1)
                {
                    tempLines.RemoveFirst();
                }
                txtMessage.Lines = tempLines.ToArray();
            }
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            Task.Run(() => ReceiveMessage());
        }

        private void cboMessageNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMessageNum.SelectedItem.Equals("All"))
            {
                MAX_MESSAGE_LINES = int.MaxValue;
            }
            else
            {
                MAX_MESSAGE_LINES = int.Parse(cboMessageNum.SelectedItem.ToString());
            }

            CutMessageLines();
        }
    }
}
