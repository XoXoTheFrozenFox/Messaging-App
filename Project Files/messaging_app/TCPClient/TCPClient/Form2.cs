using System;
using System.Windows.Forms;

namespace TCPClient
{
    public partial class Form2 : Form
    {
        internal static Form1 form1; // for communication between form 1 and 2
        internal static Form2 form2; // for communication between form 1 and 2

        string ipRecipient;
        string ipSender;

        public Form2(string ipRec, string ipSen)
        {
            InitializeComponent();
            form2 = this;
            label1.Text = $"Recipient: {ipRec}";
            ipRecipient = ipRec;
            ipSender = ipSen;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // we put the text into a sending function in form1
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                Form1.form1.forward_PrivateMessage("%^" + ipRecipient + "%^" + "&*" + ipSender + "&*" + txtMessage.Text); // pass recipient IP along with message to form1 method
                txtInfo.Text += $"You: {txtMessage.Text}{Environment.NewLine}"; // adds to client's messages textbox
                txtMessage.Text = string.Empty;
            }
        }

        public void Events_Private_DataReceived(string privateMessage)
        {
            txtInfo.Text += $"{privateMessage}{Environment.NewLine}";
        }
    }
}
