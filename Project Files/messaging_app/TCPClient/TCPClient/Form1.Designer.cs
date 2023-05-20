namespace TCPClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConnect = new System.Windows.Forms.Button();
            btnSend = new System.Windows.Forms.Button();
            txtMessage = new System.Windows.Forms.TextBox();
            lstClientIP = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtInfo = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            panel1 = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.BackColor = System.Drawing.Color.Teal;
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnConnect.ForeColor = System.Drawing.SystemColors.Window;
            btnConnect.Location = new System.Drawing.Point(512, 301);
            btnConnect.Margin = new System.Windows.Forms.Padding(4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new System.Drawing.Size(160, 50);
            btnConnect.TabIndex = 13;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.BackColor = System.Drawing.Color.Teal;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSend.ForeColor = System.Drawing.SystemColors.Window;
            btnSend.Location = new System.Drawing.Point(351, 301);
            btnSend.Margin = new System.Windows.Forms.Padding(4);
            btnSend.Name = "btnSend";
            btnSend.Size = new System.Drawing.Size(160, 50);
            btnSend.TabIndex = 12;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtMessage.Location = new System.Drawing.Point(0, 301);
            txtMessage.Margin = new System.Windows.Forms.Padding(4);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Type your group message here...";
            txtMessage.Size = new System.Drawing.Size(351, 50);
            txtMessage.TabIndex = 9;
            // 
            // lstClientIP
            // 
            lstClientIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstClientIP.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lstClientIP.FormattingEnabled = true;
            lstClientIP.ItemHeight = 25;
            lstClientIP.Location = new System.Drawing.Point(512, 52);
            lstClientIP.Margin = new System.Windows.Forms.Padding(4);
            lstClientIP.Name = "lstClientIP";
            lstClientIP.Size = new System.Drawing.Size(160, 250);
            lstClientIP.TabIndex = 17;
            lstClientIP.SelectedIndexChanged += lstClientIP_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Teal;
            label1.ForeColor = System.Drawing.SystemColors.Window;
            label1.Location = new System.Drawing.Point(509, 26);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(109, 25);
            label1.TabIndex = 18;
            label1.Text = "Other Users:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Teal;
            label2.ForeColor = System.Drawing.SystemColors.Window;
            label2.Location = new System.Drawing.Point(509, 1);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(71, 25);
            label2.TabIndex = 19;
            label2.Text = "User IP:";
            // 
            // txtInfo
            // 
            txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInfo.Location = new System.Drawing.Point(0, 52);
            txtInfo.Margin = new System.Windows.Forms.Padding(4);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtInfo.Size = new System.Drawing.Size(511, 250);
            txtInfo.TabIndex = 8;
            txtInfo.TextChanged += txtInfo_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            textBox1.Location = new System.Drawing.Point(257, 1);
            textBox1.Margin = new System.Windows.Forms.Padding(4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Enter port number...";
            textBox1.Size = new System.Drawing.Size(254, 50);
            textBox1.TabIndex = 21;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            textBox2.Location = new System.Drawing.Point(0, 1);
            textBox2.Margin = new System.Windows.Forms.Padding(4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Enter server IP...";
            textBox2.Size = new System.Drawing.Size(254, 50);
            textBox2.TabIndex = 22;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Teal;
            panel1.Location = new System.Drawing.Point(512, 1);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(160, 50);
            panel1.TabIndex = 23;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(670, 351);
            Controls.Add(textBox1);
            Controls.Add(btnConnect);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lstClientIP);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(txtInfo);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            Name = "Form1";
            Text = "Client/User";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox lstClientIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
    }
}
