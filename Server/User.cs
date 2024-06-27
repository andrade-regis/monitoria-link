using System.Net.Sockets;

namespace Server
{
    public class User
    {
        public string Username { get; set; }
        public TcpClient Client { get; set; }
        public NetworkStream Stream { get; set; }

        public User(string username, TcpClient client)
        {
            Username = username;
            Client = client;
            Stream = client.GetStream();
        }
    }
}
