using SuperSimpleTcp;
using System;
using System.Text;
using System.Windows.Forms;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        internal static Form1 form1; // for communication between form 1 and 2
        internal static Form2 form2; // for communication between form 1 and 2

        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        SimpleTcpClient client; // for all the different events such as server connected, server disconected, and data received events.

        string myIp;
        bool privChatOpen = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string serverIP = textBox2.Text + ":" + textBox1.Text;
            client = new(serverIP); // creates an insance of the client class in SuperSimpleTcp using the specified IP
            client.Events.Connected += Events_Connected;
            client.Events.DataReceived += Events_DataReceived; // DOUBLED THIS CAUSED DOUBLE MESSAGES ON CLIENT UI
            client.Events.Disconnected += Events_Disconnected;

            try
            {
                client.Connect(); // connects client to the server
                btnSend.Enabled = true; // turns on btnSend
                btnConnect.Enabled = false; // turns off btnConnect
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Events_Connected(object sender, EventArgs e) // this is triggered by btnConnect_Click (due to the code in Form1_Load)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Connected to server.{Environment.NewLine}"; // adds "Connected to server." to the client's messages textbox
            });
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string receivedString = Encoding.UTF8.GetString(e.Data); // gets message from the server

            Invoke((MethodInvoker)delegate
            {
                int myIpStart = receivedString.IndexOf("!@") + 2;
                int myIpEnd = receivedString.LastIndexOf("!@") - receivedString.IndexOf("!@") - 2;
                string myIpOnly;

                if (receivedString.IndexOf("!@") != -1) // runs if receivedString contains "!@"
                {
                    myIpOnly = receivedString.Substring(myIpStart, myIpEnd); // length cannot be zero
                    myIp = myIpOnly;
                    label2.Text = myIp;
                }
                else
                {
                    myIpOnly = "";
                }

                int ipStringStart = receivedString.IndexOf("#$") + 2;
                int ipStringEnd = receivedString.LastIndexOf("#$") - receivedString.IndexOf("#$") - 2;
                string ipString;

                if (receivedString.IndexOf("#$") != -1)
                {
                    ipString = receivedString.Substring(ipStringStart, ipStringEnd); // length cannot be zero
                    lstClientIP.Items.Clear();
                    string[] ipAddrs = ipString.Replace(myIp + "/", "").Split(new char[] { '/' });

                    foreach (string ipAddr in ipAddrs) //for updating IP Addresses
                    {
                        lstClientIP.Items.Add(ipAddr);
                    }
                }
                else
                {
                    ipString = "";
                }

                string textOnly = receivedString.Replace("!@" + myIpOnly + "!@" + "#$" + ipString + "#$", "");

                if (textOnly != "") // this is to avoid random open lines in message textbox AND do to ensure that it is not a private message
                {
                    if (textOnly.Contains(myIp) && (textOnly.IndexOf("&*") == -1)) // second part checks that it is not a private message
                    {
                        txtInfo.Text += $"{textOnly.Replace(myIp + ": ", "")}{Environment.NewLine}"; // adds message from server to the clients's messages textbox
                    }
                    else if (textOnly.IndexOf("&*") != -1)
                    {
                        if (privChatOpen == false)
                        {
                            int ipSenderStart = textOnly.IndexOf("&*") + 2;
                            int ipSenderEnd = textOnly.LastIndexOf("&*") - receivedString.IndexOf("&*") - 2;
                            string senderIp = textOnly.Substring(ipSenderStart, ipSenderEnd);
                            string onlyPrivText = textOnly.Replace("&*" + senderIp + "&*", "");
                            form2 = new Form2(senderIp, myIp); // creates instance of form 2?
                            // changes made by Ellen to fix private chat
                            form2.FormClosed += Form2_FormClosed; // subscribe to the FormClosed event
                            // change made by Ellen to fix private chat
                            form2.Show();
                            Form2.form2.Events_Private_DataReceived(senderIp + ": " + onlyPrivText);
                            privChatOpen = true;
                        }
                        else
                        {
                            int ipSenderStart = textOnly.IndexOf("&*") + 2;
                            int ipSenderEnd = textOnly.LastIndexOf("&*") - receivedString.IndexOf("&*") - 2;
                            string senderIp = textOnly.Substring(ipSenderStart, ipSenderEnd);
                            string onlyPrivText = textOnly.Replace("&*" + senderIp + "&*", "");
                            Form2.form2.Events_Private_DataReceived(senderIp + ": " + onlyPrivText);
                        }
                    }
                    else
                    {
                        txtInfo.Text += $"{textOnly}{Environment.NewLine}"; // adds message from server to the clients's messages textbox
                    }
                }
            });
        }

        // changes made by Ellen to Fix private chat
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            privChatOpen = false; // set the privChatOpen variable to false when Form2 is closed
        }
        // changes made by Ellen to fix private chat

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected) // client checks if it is connected to the server
            {
                if (!string.IsNullOrEmpty(txtMessage.Text))
                {
                    client.Send(txtMessage.Text);
                    txtInfo.Text += $"You: "; // adds to client's messages textbox (old code: {txtMessage.Text}{Environment.NewLine})
                    // no need to actually print the message because the server will forward it to you
                    txtMessage.Text = string.Empty; // empties client's message entry textbox
                }
            }
        }

        private void Events_Disconnected(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Server disconnected.{Environment.NewLine}"; // adds "Server disconected." to the client's messages textbox
            });
        }

        private void txtInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstClientIP_SelectedIndexChanged(object sender, EventArgs e) // opens private chat when you click on an IP
        {
            string recipient = lstClientIP.SelectedItem.ToString(); // item selected
            form2 = new Form2(recipient, myIp); // creates instance of form 2?
            form2.Show();
            privChatOpen = true;
        }

        public void forward_PrivateMessage(string privMsg)
        {
            if (client.IsConnected) // client checks if it is connected to the server before forwarding private message
            {
                if (!string.IsNullOrEmpty(privMsg))
                {
                    client.Send(privMsg);
                }
            }
        }
    }
}