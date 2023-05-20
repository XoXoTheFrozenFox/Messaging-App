using SuperSimpleTcp;
using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        SimpleTcpServer server; // supports client connected events, client disconected events, and data received events
        string serverIP;
        string ipFakeList = null; // used to concatenate ip addresses to send

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // allows us to use the above events (all events that "sends" some sort of data, whether its a message or just "connected"/"disconected" updates)
        {
            btnSend.Enabled = false;
            // find the curren device IP address
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    serverIP += address.ToString(); // this is the IP of the device you started the server application on
                }
            }
            textBox2.Text += serverIP; // print the IP address on the server UI
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string servString = "0.0.0.0:" + textBox1.Text; // "0.0.0.0" lets any foreign IP connect? The rest is just the port number
            server = new SimpleTcpServer(servString);
            server.Events.ClientConnected += Events_ClientConnected; // adds our functions to the ClientConnected class?
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
            server.Start(); // starts the server
            // txtInfo is the name of the messages textbox on the server
            txtInfo.Text += $"Server online.{Environment.NewLine}"; // adds "Server online." in the messaging textbox on the server
            btnStart.Enabled = false; // btnStart is now greyed out and cannot be used anymore
            btnSend.Enabled = true;
        }

        private void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate // means the following code is run on the UI thread
            {
                // e.IpPort holds the complete addres of the new client that is connected
                txtInfo.Text += $"{e.IpPort} connected.{Environment.NewLine}";
                lstClientIP.Items.Add(e.IpPort); // adds the connected client's IP to the server's "Connected User IP" textbox
                // code for ipFakeList
                ipFakeList += e.IpPort + "/"; // output = ip/ip/ip/
                foreach (string it1 in lstClientIP.Items) // sends data to each client connected
                {
                    server.Send(it1, "!@" + it1 + "!@" + "#$" + ipFakeList + "#$"); // sends all user all IPs
                    server.Send(it1, $"{e.IpPort} connected.");
                }
            });
        }

        private void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort} disconnected.{Environment.NewLine}"; // adds the client ip and "disconected" to the server's messages textbox
                lstClientIP.Items.Remove(e.IpPort); // removes the disconnected client's IP from the server's "Connected User IP" textbox
                // code for ipFakeList
                ipFakeList = ipFakeList.Replace(e.IpPort + "/", "");
                foreach (string it1 in lstClientIP.Items)
                {
                    //server.Send(it1, "#$" + ipFakeList + "#$");
                    server.Send(it1, "!@" + it1 + "!@" + "#$" + ipFakeList + "#$");
                    server.Send(it1, $"{e.IpPort} disconnected.");
                }
            });
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string recData = Encoding.UTF8.GetString(e.Data);
                if (recData.IndexOf("%^") != -1) // runs if it is a private message
                {
                    // here we remove and use the recipient IP
                    int ipStart = recData.IndexOf("%^") + 2;
                    int ipEnd = recData.LastIndexOf("%^") - recData.IndexOf("%^") - 2;
                    string ipOnly = recData.Substring(ipStart, ipEnd); // length still sometimes less than zero
                    string textOnly = recData.Substring(ipEnd + 4, (recData.Length - ipEnd) - 4);
                    server.Send(ipOnly, textOnly);
                }
                else // executes when it is a normal group message
                {
                    foreach (string ip in lstClientIP.Items) // iterates trough the IPs in the "Users" 
                    {
                        server.Send(ip, $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}"); // sends message in message to the specified IP each time the loop executes
                    }
                    txtInfo.Text += $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}"; // adds the data it receives from client with IP: e.IpPort, to the server's messages textbox
                }
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening) // checks if server has started before attempting anything
            {
                // txtMessage is the name of the textbox used to enter a message on the server side
                if (!string.IsNullOrEmpty(txtMesssage.Text) && lstClientIP.SelectedItems != null) // the message that the server want to send may not be empty && there must be at least one cliet connected to the server
                {
                    // lstClientIP is the name of the listbox containing the "Connected User IP"
                    foreach (string s in lstClientIP.Items) // iterates trough the IPs in the "Connected User IP" 
                    {
                        server.Send(s, $"Server: {txtMesssage.Text}"); // sends message in message entry textbox to the specified IP
                    }
                    txtInfo.Text += $"Server: {txtMesssage.Text}{Environment.NewLine}"; // adds to servers's messages textbox
                    txtMesssage.Text = string.Empty; // empties server's message entry textbox
                }
            }
        }

        private void lstClientIP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}