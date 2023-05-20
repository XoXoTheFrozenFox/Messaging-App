namespace TCPClient
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtInfo = new System.Windows.Forms.TextBox();
            txtMessage = new System.Windows.Forms.TextBox();
            btnSend = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // txtInfo
            // 
            txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInfo.Location = new System.Drawing.Point(1, 56);
            txtInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtInfo.Size = new System.Drawing.Size(513, 250);
            txtInfo.TabIndex = 9;
            // 
            // txtMessage
            // 
            txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtMessage.Location = new System.Drawing.Point(1, 302);
            txtMessage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Type your private message here...";
            txtMessage.Size = new System.Drawing.Size(351, 50);
            txtMessage.TabIndex = 10;
            // 
            // btnSend
            // 
            btnSend.BackColor = System.Drawing.Color.Teal;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSend.ForeColor = System.Drawing.SystemColors.Window;
            btnSend.Location = new System.Drawing.Point(354, 302);
            btnSend.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSend.Name = "btnSend";
            btnSend.Size = new System.Drawing.Size(160, 50);
            btnSend.TabIndex = 13;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Teal;
            label1.ForeColor = System.Drawing.SystemColors.Window;
            label1.Location = new System.Drawing.Point(14, 12);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 25);
            label1.TabIndex = 19;
            label1.Text = "User IP:";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Teal;
            panel1.Location = new System.Drawing.Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(513, 50);
            panel1.TabIndex = 20;
            // 
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(514, 352);
            Controls.Add(label1);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(txtInfo);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form2";
            Text = "Private Message";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}