using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SuperSimpleTcp;

namespace TCPServer
{
    class Program
    {
        static SimpleTcpServer server; // supports client connected events, client disconected events, and data received events
        //static string serverIP = "";
        static string ipFakeList = null; // used to concatenate ip addresses to send

        static void Main(string[] args)
        {
            // find the current devices external IP address
            try
            {
                using (var client = new WebClient())
                {
                    string ip = client.DownloadString("https://api.ipify.org");
                    Console.WriteLine("Server IP: " + ip); // EXTERNAL IP. Due to the code being run on a cloud computer, the cloud computer's external IP needs to be entered into the TCPClient app to establish a connection.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get server IP address: " + ex.Message); 
            }

            Console.Write("Port: ");
            string port = Console.ReadLine();

            Console.Write("\nCommands:\nbroadcast - To allow for the entry of a broadcast message.\nexit      - To terminate the console application.\n\n");

            // start the server
            string servString = $"0.0.0.0:{port}";
            server = new SimpleTcpServer(servString);
            server.Events.ClientConnected += Events_ClientConnected; // adds our functions to the ClientConnected class?
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
            server.Start(); // starts the server

            Console.WriteLine("Server online.");

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    server.Stop();
                    break;
                }
                else if (input == "broadcast")
                {
                    Console.Write("Server: ");
                    string input2 = Console.ReadLine();
                    if (server.IsListening) // checks if server has started before attempting anything
                    {
                        // txtMessage is the name of the textbox used to enter a message on the server side
                        if (!string.IsNullOrEmpty(input) && server.GetClients() != null) // the message that the server want to send may not be empty && there must be at least one cliet connected to the server
                        {
                            try
                            {
                                // lstClientIP is the name of the listbox containing the "Connected User IP"
                                foreach (string s in server.GetClients()) // iterates trough the IPs in the "Connected User IP" 
                                {
                                    server.Send(s, $"Server: {input2}"); // sends message in message entry textbox to the specified IP
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Server: " + e.Message);
                            }
                        }
                    }
                }
            }
        }

        static void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            // e.IpPort holds the complete address of the new client that is connected
            Console.WriteLine($"{e.IpPort} connected.");
            ipFakeList += e.IpPort + "/";

            try
            {
                foreach (string it1 in server.GetClients())
                {
                    server.Send(it1, "!@" + it1 + "!@" + "#$" + ipFakeList + "#$");
                    server.Send(it1, $"{e.IpPort} connected.");
                }
            }
            catch (Exception e1)
            {
                // no need to print the exception, because "client connected" was printed out in the first line of this method; 
            }
        }

        static void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            Console.WriteLine($"{e.IpPort} disconnected.");
            ipFakeList = ipFakeList.Replace(e.IpPort + "/", "");

            try
            {
                foreach (string it1 in server.GetClients())
                {
                    server.Send(it1, "!@" + it1 + "!@" + "#$" + ipFakeList + "#$");
                    server.Send(it1, $"{e.IpPort} disconnected.");
                }
            }
            catch (Exception e2)
            {
                // no need to print the exception, because "client disconnected" was printed out in the first line of this method; 
            }
            
        }

        static void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string recData = Encoding.UTF8.GetString(e.Data);
            if (recData.IndexOf("%^") != -1)
            {
                int ipStart = recData.IndexOf("%^") + 2;
                int ipEnd = recData.LastIndexOf("%^") - recData.IndexOf("%^") - 2;
                string ipOnly = recData.Substring(ipStart, ipEnd);
                string textOnly = recData.Substring(ipEnd + 4, (recData.Length - ipEnd) - 4);
                server.Send(ipOnly, textOnly);
            }
            else
            {
                try
                {
                    foreach (string ip in server.GetClients())
                    {
                        server.Send(ip, $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}");
                    }
                    Console.WriteLine($"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}");
                }
                catch (Exception e3)
                {
                    Console.WriteLine("Server: " + e3.Message);
                }
            }
        }
    }
}