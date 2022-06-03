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

        // packet 전역변수로 빼줄까?

        // 따로 빼자
        // 어차피 다 4바이트로 쓸거면 통일하는 게 낫지 않을까...?
        //private const int TYPE_BYTE_COUNTS = 4;
        //private const int ROOMID_BYTE_COUNTS = 4;
        //private const int LENGTH_BYTE_COUNTS = 4;

        public RoomListForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        /*
            방을 만들겠다고 packet 보냄 (1, 0, 0, null)
            서버에서 방 아이디 보냄 -> 방 아이디 받음
            방 아이디 리스트박스에 저장
         */
        private void btnMakeRoom_Click(object sender, EventArgs e)
        {
            Packet sendPacket = new Packet((int)Packet.TYPE_PACKET.MAKE_ROOM);
            byte[] sendPacketBytes = sendPacket.ToByteArray();
            client.Writer.Write(sendPacketBytes, 0, sendPacketBytes.Length);

            // 방 목록 가져오기에서도 사용됨. TODO 추출하자
            AddRoom();
        }

        // 위에는 읽어오는 애고, 아래는 방목록 추가하는 앤데 이름을 이렇게 짓는 게 맞을까
        private void AddRoom()
        {
            Packet receivePacket = new Packet(client.Reader);
            receivePacket.Read();
            int roomId = BitConverter.ToInt32(receivePacket.RoomIdBytes, 0);

            lstRoom.Items.Add(roomId);
        }

        /*
            첨에 RoomListForm 들어오면 방 목록 보여줘야 함
            근데 이거를 스레드 따로 돌려서 하는 게 맞나?
            우선 모르겠으니까 새로고침 버튼을 만들까?
        */

        /*
         * 1. 서버가 방 번호를 List로 보내준다
         * 2. 아니야 for문으로 하나하나 보내주면 for문으로 하나하나 받자
         * 
         * for문을 어디까지 돌려야 돼? stream에서 읽을 게 없을 때까지
         * 나는 packet을 생성하고 거기서 읽는데,,,,
         * 끝을 알 수가 있나....?
         * 방 목록을 보내면 개수도 같이 알려줘야 하나...?
         * 나 바본가?
         * 바보다
         * 
         * 우선 처음 roomId에 방 개수를 보내자. body에 보낼까? TODO 나중에 고치자
         * 
         * 방 번호를 받으면 리스트박스에 저장
         * 
         */
        private void GetRoomList()
        {
            Packet receivePacket = new Packet(client.Reader);
            receivePacket.Read();
            int roomCount = BitConverter.ToInt32(receivePacket.RoomIdBytes, 0);

            for(int i=0; i<roomCount; i++)
            {
                AddRoom();
            }
        }
        
        /*
            방 아이디 가져와
            서버에 나 방 입장 하겠다고 보내 (3, 방번호, 0, null)
            창 바꿔
         */
        private void lstRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int roomId = 0;

            if (lstRoom.SelectedItem != null)
            {
                roomId = Int32.Parse(lstRoom.SelectedItem.ToString());
            }

            EnterRoom(roomId);
        }

        private void EnterRoom(int roomId)
        {
            // body에 null 넘기면 안 되니까 우선 인사나 하자
            // 아니야 생성자 하나 더 만들자
            // 패킷 보내는 거 메소드 따로 빼는 게 좋지 않을까?
            //Packet sendPacket = new Packet((int)Packet.TYPE_PACKET.ENTER_ROOM, roomId);
            //byte[] sendPacketBytes = sendPacket.ToByteArray();
            //client.Writer.Write(sendPacketBytes, 0, sendPacketBytes.Length);

            // 방 번호 넘겨야 되는데; 어떻게 넘기지,,,,,,,,,,,,,,
            // ShowPage에 매개변수로 넘기긴 싫은데,,,,
            // 망했다
            // 왜 괜히 컨트롤 붙였다 뗐다 했을까 
            // 바보다
            ChatForm chatForm = new ChatForm(mainForm, roomId);
            chatForm.Show();
            //mainForm.ShowPage(MainForm.TYPE_PAGE.CHAT_PAGE);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetRoomList();
        }

        private void btnEnterRoom_Click(object sender, EventArgs e)
        {
            //int roomId = 0;

            //if (lstRoom.SelectedItem != null)
            //{
            //    roomId = Int32.Parse(lstRoom.SelectedItem.ToString());
            //}

            EnterRoom(1);
        }

        // 여기서 돌리는 거 맞나........????
        //private void ChatForm_Load(object sender, EventArgs e)
        //{
        //    Task.Run(() => ReceiveList());
        //}

        //private void ReceiveList()
        //{
        //    client = Client.getInstance();

        //    // 굳이 타입을 받아야 하나?
        //    while (GetMessageType() == 1)
        //    {
        //        // roomId도 넣어줘야겠지...?
        //        // TODO 메소드로 따로 빼자
        //        byte[] roomIdBytes = new byte[ROOMID_BYTE_COUNTS];
        //        client.Reader.Read(roomIdBytes, 0, roomIdBytes.Length);
        //        Array.Reverse(roomIdBytes);
        //        int roomId = BitConverter.ToInt32(roomIdBytes, 0);

        //        byte[] lengthBytes = new byte[LENGTH_BYTE_COUNTS];
        //        client.Reader.Read(lengthBytes, 0, lengthBytes.Length);
        //        Array.Reverse(lengthBytes);
        //        int bodyByteCounts = BitConverter.ToInt32(lengthBytes, 0);

        //        byte[] bodyBytes = new byte[bodyByteCounts];
        //        client.Reader.Read(bodyBytes, 0, bodyByteCounts);
        //        string roomName = Encoding.UTF8.GetString(bodyBytes, 0, bodyByteCounts);

        //        AddRoom(roomName);
        //    }
        //}

        //private void btnMakeRoom_Click(object sender, EventArgs e)
        //{
        //    byte[] typeBytes = new byte[TYPE_BYTE_COUNTS];

        //    typeBytes = BitConverter.GetBytes(1);
        //    Array.Reverse(typeBytes);

        //    client.Writer.Write(typeBytes, 0, typeBytes.Length);
        //}

        //private int GetMessageType()
        //{
        //    byte[] typeBytes = new byte[TYPE_BYTE_COUNTS];
        //    client.Reader.Read(typeBytes, 0, typeBytes.Length);
        //    Array.Reverse(typeBytes);
        //    return BitConverter.ToInt32(typeBytes, 0);
        //}

        //private void AddRoom(string roomName)
        //{
        //    if (lstRoom.InvokeRequired)
        //    {
        //        Action<string> action = new Action<string>(AddRoom);
        //        lstRoom.Invoke(action, roomName);
        //    }
        //    else
        //    {
        //        lstRoom.Items.Add(roomName);
        //    }
        //}

        //private void lstRoom_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    String roomName = "";

        //    if (lstRoom.SelectedItem != null)
        //    {
        //        roomName = lstRoom.SelectedItem.ToString();
        //    }

        //    EnterRoom(roomName);
        //}

        //private void EnterRoom(string roomName)
        //{
        //    SendRoomName(roomName);
        //    mainForm.ShowPage(MainForm.TYPE_PAGE.CHAT_PAGE);
        //}

        //// 아니야,,,,, 이렇게 하면 안돼,,
        //private void SendRoomName(string roomName)
        //{
        //    int nameByteCounts = Encoding.UTF8.GetByteCount(roomName);

        //    byte[] typeBytes = new byte[TYPE_BYTE_COUNTS];
        //    byte[] lengthBytes = new byte[LENGTH_BYTE_COUNTS];
        //    byte[] bodyBytes = new byte[nameByteCounts];
        //    byte[] outputBytes = new byte[typeBytes.Length + lengthBytes.Length + bodyBytes.Length];

        //    // enum으로 바꾸자
        //    typeBytes = BitConverter.GetBytes(3);
        //    Array.Reverse(typeBytes);

        //    lengthBytes = BitConverter.GetBytes(nameByteCounts);
        //    Array.Reverse(lengthBytes);

        //    bodyBytes = Encoding.UTF8.GetBytes(roomName);

        //    Array.Copy(typeBytes, 0, outputBytes, 0, typeBytes.Length);
        //    Array.Copy(lengthBytes, 0, outputBytes, typeBytes.Length, lengthBytes.Length);
        //    Array.Copy(bodyBytes, 0, outputBytes, typeBytes.Length + lengthBytes.Length, bodyBytes.Length);

        //    client.Writer.Write(outputBytes, 0, outputBytes.Length);

        //    client.Writer.Flush();
        //}

        //// 다른 클래스로 빼자
        //private void SendPacket(int type, int roomId, int length, string body)
        //{
        //    int bodyByteCounts = Encoding.UTF8.GetByteCount(body);

        //    byte[] typeBytes = new byte[TYPE_BYTE_COUNTS];
        //    byte[] roomIdBytes = new byte[ROOMID_BYTE_COUNTS];
        //    byte[] lengthBytes = new byte[LENGTH_BYTE_COUNTS];
        //    byte[] bodyBytes = new byte[bodyByteCounts];
        //    byte[] outputBytes = new byte[typeBytes.Length + roomIdBytes.Length + lengthBytes.Length + bodyBytes.Length];

        //    typeBytes = IntToByteArray(type);
        //    roomIdBytes = IntToByteArray(roomId);
        //    lengthBytes = IntToByteArray(length);
        //    bodyBytes = Encoding.UTF8.GetBytes(body);

        //    Array.Copy(typeBytes, 0, outputBytes, 0, TYPE_BYTE_COUNTS);
        //    Array.Copy(roomIdBytes, 0, outputBytes, TYPE_BYTE_COUNTS, ROOMID_BYTE_COUNTS);
        //    Array.Copy(lengthBytes, 0, outputBytes, TYPE_BYTE_COUNTS + ROOMID_BYTE_COUNTS, LENGTH_BYTE_COUNTS);
        //    Array.Copy(bodyBytes, 0, outputBytes, TYPE_BYTE_COUNTS + ROOMID_BYTE_COUNTS + LENGTH_BYTE_COUNTS, bodyBytes.Length);

        //    client.Writer.Write(outputBytes, 0, outputBytes.Length);

        //    client.Writer.Flush();
        //}

        //private void ReceivePacket()
        //{
        //    int type = ReadInt();
        //    int roomId = ReadInt();
        //    int length = ReadInt();

        //    byte[] bodyBytes = new byte[length];
        //    client.Reader.Read(bodyBytes, 0, length);
        //    string body = Encoding.UTF8.GetString(bodyBytes, 0, length);

        //    // retrun packet;
        //}

        //// private int ByteArrayToInt()
        //// TODO 메소드 이름 고민
        //private int ReadInt()
        //{
        //    byte[] tempBytes = new byte[4];
        //    client.Reader.Read(tempBytes, 0, tempBytes.Length);
        //    Array.Reverse(tempBytes);
        //    return BitConverter.ToInt32(tempBytes, 0);
        //}

        //private byte[] IntToByteArray(int num)
        //{
        //    byte[] tempBytes = BitConverter.GetBytes(num);
        //    Array.Reverse(tempBytes);
        //    return tempBytes;
        //}
    }
}
