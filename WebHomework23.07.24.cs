using System.Net;
using System.Net.Sockets;

namespace ConsoleApp118
{
    // ---------------------------
    class Server
    {
        static List<Socket> clients = new List<Socket>();
        static Socket server;

        public static void Start()
        {
            server = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );

            try
            {
                server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80));
                server.Listen(10);
                Console.WriteLine("Server started...");

                while (true)
                {
                    Socket newCLient = server.Accept();
                    newCLient.Send(System.Text.Encoding.ASCII.GetBytes("Hello! And welcome\n"));
                    clients.Add(newCLient);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Client {clients.IndexOf(newCLient)} connected!");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Task.Run(() => ManageClient(newCLient));
                    Task.Run(() => Sending());
                }
            }
            catch (SocketException e) { Console.WriteLine(e.Message); }
        }
        public static void Sending()
        {
            while (true) {
                foreach (var item in clients)
                {
                    item.Send(System.Text.Encoding.ASCII.GetBytes($"{DateTime.Now}\n"));

                }
                Thread.Sleep(1000);
            }
        }
        public static void ManageClient(Socket client)
        {
            byte[] buffer = new byte[1024];
            
            int bufferSize;

            try
            {
                while ((bufferSize = client.Receive(buffer)) > 0)
                {
                    string message = System.Text.Encoding.ASCII.GetString(buffer, 0, bufferSize);
                    Console.WriteLine($"Received from {clients.IndexOf(client)}: {message}");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Client disconnected.");
            }
            finally
            {
                client.Close();
                clients.Remove(client);
            }
        }
    }

    // ---------------------------
    internal class Program
    {
        static void Main(string[] args)
        {
            Server.Start();
        }
    }
}
