namespace TCPServer
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
            label1 = new System.Windows.Forms.Label();
            lstClientIP = new System.Windows.Forms.ListBox();
            btnStart = new System.Windows.Forms.Button();
            btnSend = new System.Windows.Forms.Button();
            txtMesssage = new System.Windows.Forms.TextBox();
            txtInfo = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Teal;
            label1.Location = new System.Drawing.Point(-3, 0);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(59, 25);
            label1.TabIndex = 17;
            label1.Text = "Users:";
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
            lstClientIP.TabIndex = 16;
            lstClientIP.SelectedIndexChanged += lstClientIP_SelectedIndexChanged;
            // 
            // btnStart
            // 
            btnStart.BackColor = System.Drawing.Color.Teal;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnStart.ForeColor = System.Drawing.SystemColors.Window;
            btnStart.Location = new System.Drawing.Point(512, 301);
            btnStart.Margin = new System.Windows.Forms.Padding(4);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(160, 50);
            btnStart.TabIndex = 15;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
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
            btnSend.TabIndex = 14;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txtMesssage
            // 
            txtMesssage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtMesssage.Location = new System.Drawing.Point(0, 301);
            txtMesssage.Margin = new System.Windows.Forms.Padding(4);
            txtMesssage.Multiline = true;
            txtMesssage.Name = "txtMesssage";
            txtMesssage.PlaceholderText = "Type broadcast message here...";
            txtMesssage.Size = new System.Drawing.Size(351, 50);
            txtMesssage.TabIndex = 11;
            // 
            // txtInfo
            // 
            txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            txtInfo.Location = new System.Drawing.Point(0, 52);
            txtInfo.Margin = new System.Windows.Forms.Padding(4);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtInfo.Size = new System.Drawing.Size(511, 250);
            txtInfo.TabIndex = 10;
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
            textBox1.TabIndex = 19;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            textBox2.Location = new System.Drawing.Point(0, 1);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(254, 50);
            textBox2.TabIndex = 21;
            textBox2.Text = "Server IP: ";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Teal;
            panel1.Controls.Add(label1);
            panel1.ForeColor = System.Drawing.SystemColors.Window;
            panel1.Location = new System.Drawing.Point(512, 1);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(160, 50);
            panel1.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(670, 351);
            Controls.Add(btnStart);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lstClientIP);
            Controls.Add(btnSend);
            Controls.Add(txtMesssage);
            Controls.Add(txtInfo);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            Name = "Form1";
            Text = "Server";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstClientIP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMesssage;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
    }
}
