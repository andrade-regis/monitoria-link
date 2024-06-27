using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Servidor
    {
        private TcpListener server;
        private Dictionary<string, User> connectedUsers = new Dictionary<string, User>();

        public Servidor()
        {
            //System.Net.IPAddress Ip = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(System.Net.IPAddress.Any, 8000);
        }

        public void Start()
        {
            server.Start();
            Task.Run(() => ListenForClients());
        }

        private async void ListenForClients()
        {
            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                _ = Task.Run(() => AuthenticateClient(client));
            }
        }

        private async void AuthenticateClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string username = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

            if (!connectedUsers.ContainsKey(username))
            {
                var user = new User(username, client);
                connectedUsers.Add(username, user);
                Console.WriteLine($"User {username} connected.");
                HandleClient(user);
            }
            else
            {
                byte[] response = Encoding.UTF8.GetBytes("Username already taken.");
                await stream.WriteAsync(response, 0, response.Length);
                client.Close();
            }
        }

        private async void HandleClient(User user)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await user.Stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"{user.Username}: {message}");
                    BroadcastMessage(user.Username, message);
                }                
            }
            catch(Exception ex)
            {
                connectedUsers.Remove(user.Username);
                Console.WriteLine($"User {user.Username} disconnected.");
            }

            
        }

        private void BroadcastMessage(string senderUsername, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes($"{senderUsername}: {message}");

            foreach (var user in connectedUsers.Values)
            {
                if (user.Username != senderUsername)
                {
                    user.Stream.Write(data, 0, data.Length);
                }
            }
        }
    }
}
