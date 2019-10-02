namespace _02_10_2019Udp
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMyPort = new System.Windows.Forms.TextBox();
            this.txtMyIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFriendPort = new System.Windows.Forms.TextBox();
            this.txtFriendIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbMessenger = new System.Windows.Forms.ListBox();
            this.butConnect = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.butSend = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMyPort);
            this.groupBox1.Controls.Add(this.txtMyIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MyInfo";
            // 
            // txtMyPort
            // 
            this.txtMyPort.Location = new System.Drawing.Point(46, 48);
            this.txtMyPort.Name = "txtMyPort";
            this.txtMyPort.Size = new System.Drawing.Size(224, 20);
            this.txtMyPort.TabIndex = 3;
            // 
            // txtMyIP
            // 
            this.txtMyIP.Location = new System.Drawing.Point(47, 15);
            this.txtMyIP.Name = "txtMyIP";
            this.txtMyIP.Size = new System.Drawing.Size(224, 20);
            this.txtMyIP.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFriendPort);
            this.groupBox2.Controls.Add(this.txtFriendIP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(297, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FriendInfo";
            // 
            // txtFriendPort
            // 
            this.txtFriendPort.Location = new System.Drawing.Point(49, 48);
            this.txtFriendPort.Name = "txtFriendPort";
            this.txtFriendPort.Size = new System.Drawing.Size(224, 20);
            this.txtFriendPort.TabIndex = 5;
            // 
            // txtFriendIP
            // 
            this.txtFriendIP.Location = new System.Drawing.Point(50, 15);
            this.txtFriendIP.Name = "txtFriendIP";
            this.txtFriendIP.Size = new System.Drawing.Size(224, 20);
            this.txtFriendIP.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "IP";
            // 
            // lbMessenger
            // 
            this.lbMessenger.FormattingEnabled = true;
            this.lbMessenger.Location = new System.Drawing.Point(20, 112);
            this.lbMessenger.Name = "lbMessenger";
            this.lbMessenger.Size = new System.Drawing.Size(559, 173);
            this.lbMessenger.TabIndex = 2;
            // 
            // butConnect
            // 
            this.butConnect.Location = new System.Drawing.Point(596, 39);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(58, 24);
            this.butConnect.TabIndex = 3;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(21, 294);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(561, 20);
            this.txtMessage.TabIndex = 4;
            // 
            // butSend
            // 
            this.butSend.Location = new System.Drawing.Point(596, 288);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(58, 24);
            this.butSend.TabIndex = 5;
            this.butSend.Text = "Send";
            this.butSend.UseVisualStyleBackColor = true;
            this.butSend.Click += new System.EventHandler(this.butSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 324);
            this.Controls.Add(this.butSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.butConnect);
            this.Controls.Add(this.lbMessenger);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "x";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMyPort;
        private System.Windows.Forms.TextBox txtMyIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFriendPort;
        private System.Windows.Forms.TextBox txtFriendIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbMessenger;
        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button butSend;
    }
}

