using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    internal class Cliente
    {
        private TcpClient client;
        private NetworkStream stream;

        public async Task ConnectAsync(string username)
        {
            client = new TcpClient("localhost", 8000);
            stream = client.GetStream();

            // Envia o nome de usuário
            byte[] usernameData = Encoding.UTF8.GetBytes(username);
            await stream.WriteAsync(usernameData, 0, usernameData.Length);

            _ = Task.Run(() => ListenForMessages());
        }

        public async Task SendMessageAsync(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(data, 0, data.Length);
        }

        private async void ListenForMessages()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine(message);
            }
        }
    }
}
