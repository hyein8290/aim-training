using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class Packet
    {
        public enum TYPE_PACKET
        {
            ROOM_LIST = 1,      // 방 목록
            MAKE_ROOM = 2,      // 방 만들기
            ENTER_ROOM = 3,     // 방 입장
            SET_NAME = 4,       // 이름 설정
            SEND_MESSAGE = 5,   // 메시지 보내기
            __MAX__
        }

        private NetworkStream stream;
        private byte[] typeBytes;
        private byte[] roomIdBytes;
        private byte[] lengthBytes;
        private byte[] bodyBytes;

        private const int HEADER_LENGTH = 4;

        public NetworkStream Stream { get => stream; set => stream = value; }
        public byte[] TypeBytes { get => typeBytes; set => typeBytes = value; }
        public byte[] RoomIdBytes { get => roomIdBytes; set => roomIdBytes = value; }
        public byte[] BodyBytes { get => bodyBytes; set => bodyBytes = value; }

        public Packet()
        {
            typeBytes = new byte[HEADER_LENGTH];
            roomIdBytes = new byte[HEADER_LENGTH];
            lengthBytes = new byte[HEADER_LENGTH];
        }

        // stream 넣는 것도 만들자,,,,,,,,,,
        // 그럼 client는 읽는 스트림이 필요없지 않을까?
        // 뭔가 잘못되어 가는 기분
        public Packet(NetworkStream stream)
        {
            typeBytes = new byte[HEADER_LENGTH];
            roomIdBytes = new byte[HEADER_LENGTH];
            lengthBytes = new byte[HEADER_LENGTH];
            this.stream = stream;
        }

        /*
            생성자
            1. type 받으면 byte array로 저장
            이게 필요한가..?
        */
        public Packet(int type)
        {
            typeBytes = IntToByteArray(type);

            // 나머지 null로 넣어주야 되겠지.....? 아니면 0?
            roomIdBytes = IntToByteArray(0);
            lengthBytes = IntToByteArray(0);

            // body도 건드려야 하나..?
            // 0으로 선언하면 어떻게 되는거지.....?
            bodyBytes = new byte[0];
        }

        public Packet(int type, int roomId)
        {
            typeBytes = IntToByteArray(type);
            roomIdBytes = IntToByteArray(roomId);
            lengthBytes = IntToByteArray(0);
            bodyBytes = new byte[0];
        }

        /*
            생성자
            1. type -> byte array로 저장
            2. roomId -> byte array
            3. body -> byte array
            4. bodyBytes.length -> byte array

            TODO body null 처리
        */
        public Packet(int type, int roomId, string body)
        {
            typeBytes = IntToByteArray(type);
            roomIdBytes = IntToByteArray(roomId);
            bodyBytes = Encoding.UTF8.GetBytes(body);
            lengthBytes = IntToByteArray(body.Length);
        }

        /*
            packet -> byte array
            byte array로 합치기
            보낼 때 byte array로 보내자

            bodyBytes가 byte[0]일 때 에러 안 날까....?
        */
        public byte[] ToByteArray()
        {
            byte[] tempBytes = new byte[typeBytes.Length + roomIdBytes.Length + lengthBytes.Length + bodyBytes.Length];

            Array.Copy(typeBytes, 0, tempBytes, 0, HEADER_LENGTH);
            Array.Copy(roomIdBytes, 0, tempBytes, HEADER_LENGTH, HEADER_LENGTH);
            Array.Copy(lengthBytes, 0, tempBytes, HEADER_LENGTH * 2, HEADER_LENGTH);
            Array.Copy(bodyBytes, 0, tempBytes, HEADER_LENGTH * 3, bodyBytes.Length);

            return tempBytes;
        }

        // 패킷을 받아와야 하는데,,, 서버에서 받은 byte array를 읽어서 packet에 저장
        // 이거를 패킷 클래스에서???
        // 그러면 stream이 필요하겠지
        // TODO 메소드 이름은 뭘로?? read save topacket
        public void Read()
        {
            stream.Read(typeBytes, 0, typeBytes.Length);
            Array.Reverse(typeBytes);

            stream.Read(roomIdBytes, 0, roomIdBytes.Length);
            Array.Reverse(roomIdBytes);

            stream.Read(lengthBytes, 0, lengthBytes.Length);
            Array.Reverse(lengthBytes);

            // 아니 바깥에서 또 읽어야 되네;;;;
            // 아니지 bodyBytes 길이 만큼만 읽으면 되지 바보야
            // 맞나?
            int length = BitConverter.ToInt32(lengthBytes, 0);

            bodyBytes = new byte[length];
            stream.Read(bodyBytes, 0, length);
        }

        /*
            int -> byte array로
        */
        private byte[] IntToByteArray(int num)
        {
            byte[] tempBytes = BitConverter.GetBytes(num);
            Array.Reverse(tempBytes);
            return tempBytes;
        }

    }
}
