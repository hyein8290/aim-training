using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ChatClient
{
    public class Client
    {
        private static Client socketClient = null;
        private TcpClient tcpClient;
        private readonly NetworkStream _stream;
        private string name;

        private Client(string ip, int port)
        {
            TcpClient = new TcpClient(ip, port);
            _stream = TcpClient.GetStream();
        }

        public TcpClient TcpClient { get => tcpClient; set => tcpClient = value; }
        public NetworkStream Writer { get => _stream; }
        public NetworkStream Reader { get => _stream; }
        public string Name { get => name; set => name = value; }

        public static Client getInstance(string ip, int port)
        {
            if (socketClient == null)
            {
                socketClient = new Client(ip, port);
            }
            return socketClient;
        }

        public static Client getInstance()
        {
            return socketClient;
        }
    }
}
