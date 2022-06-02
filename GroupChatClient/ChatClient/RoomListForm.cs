using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class RoomListForm : UserControl
    {
        public MainForm mainForm;
        private Client client;

        private const int TYPE_BYTE_COUNTS = 4;
        private const int LENGTH_BYTE_COUNTS = 4;
        private const int ROOMID_BYTE_COUNTS = 4;

        public RoomListForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            Task.Run(() => ReceiveList());
        }

        private void ReceiveList()
        {
            client = Client.getInstance();
            
            // 굳이 타입을 받아야 하나?
            while (GetMessageType() == 1)
            {
                // roomId도 넣어줘야겠지...?
                byte[] roomIdBytes = new byte[ROOMID_BYTE_COUNTS];
                client.Reader.Read(roomIdBytes, 0, roomIdBytes.Length);
                Array.Reverse(roomIdBytes);
                int roomId = BitConverter.ToInt32(roomIdBytes, 0);

                byte[] lengthBytes = new byte[LENGTH_BYTE_COUNTS];
                client.Reader.Read(lengthBytes, 0, lengthBytes.Length);
                Array.Reverse(lengthBytes);
                int bodyByteCounts = BitConverter.ToInt32(lengthBytes, 0);

                byte[] bodyBytes = new byte[bodyByteCounts];
                client.Reader.Read(bodyBytes, 0, bodyByteCounts);
                string roomName = Encoding.UTF8.GetString(bodyBytes, 0, bodyByteCounts);

                AddRoom(roomName);
            }
        }

        private int GetMessageType()
        {
            byte[] typeBytes = new byte[TYPE_BYTE_COUNTS];
            client.Reader.Read(typeBytes, 0, typeBytes.Length);
            Array.Reverse(typeBytes);
            return BitConverter.ToInt32(typeBytes, 0);
        }

        private void AddRoom(string roomName)
        {
            if (lstRoom.InvokeRequired)
            {
                Action<string> action = new Action<string>(AddRoom);
                lstRoom.Invoke(action, roomName);
            }
            else
            {
                lstRoom.Items.Add(roomName);
            }
        }

        private void lstRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            String roomName = "";

            if (lstRoom.SelectedItem != null)
            {
                roomName = lstRoom.SelectedItem.ToString();
            }

            enterRoom(roomName);
        }

        private void enterRoom(string roomName)
        {
            int nameByteCounts = Encoding.UTF8.GetByteCount(roomName);

            byte[] typeBytes = new byte[TYPE_BYTE_COUNTS];
            byte[] lengthBytes = new byte[LENGTH_BYTE_COUNTS];
            byte[] bodyBytes = new byte[nameByteCounts];
            byte[] outputBytes = new byte[typeBytes.Length + lengthBytes.Length + bodyBytes.Length];

            // enum으로 바꾸자
            typeBytes = BitConverter.GetBytes(3);
            Array.Reverse(typeBytes);

            lengthBytes = BitConverter.GetBytes(nameByteCounts);
            Array.Reverse(lengthBytes);

            bodyBytes = Encoding.UTF8.GetBytes(roomName);

            Array.Copy(typeBytes, 0, outputBytes, 0, typeBytes.Length);
            Array.Copy(lengthBytes, 0, outputBytes, typeBytes.Length, lengthBytes.Length);
            Array.Copy(bodyBytes, 0, outputBytes, typeBytes.Length + lengthBytes.Length, bodyBytes.Length);

            client.Writer.Write(outputBytes, 0, outputBytes.Length);

            client.Writer.Flush();
        }
    }
}
