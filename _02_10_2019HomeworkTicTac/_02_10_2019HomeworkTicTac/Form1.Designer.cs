namespace _02_10_2019HomeworkTicTac
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
            this.butConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFriendPort = new System.Windows.Forms.TextBox();
            this.txtFriendIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMyPort = new System.Windows.Forms.TextBox();
            this.txtMyIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.but11 = new System.Windows.Forms.Button();
            this.but12 = new System.Windows.Forms.Button();
            this.but13 = new System.Windows.Forms.Button();
            this.but21 = new System.Windows.Forms.Button();
            this.but22 = new System.Windows.Forms.Button();
            this.but23 = new System.Windows.Forms.Button();
            this.but31 = new System.Windows.Forms.Button();
            this.but32 = new System.Windows.Forms.Button();
            this.but33 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butConnect
            // 
            this.butConnect.Location = new System.Drawing.Point(6, 196);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(58, 24);
            this.butConnect.TabIndex = 6;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFriendPort);
            this.groupBox2.Controls.Add(this.txtFriendIP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 86);
            this.groupBox2.TabIndex = 5;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMyPort);
            this.groupBox1.Controls.Add(this.txtMyIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 88);
            this.groupBox1.TabIndex = 4;
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
            // but11
            // 
            this.but11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.but11.Location = new System.Drawing.Point(312, 19);
            this.but11.Name = "but11";
            this.but11.Size = new System.Drawing.Size(48, 44);
            this.but11.TabIndex = 8;
            this.but11.UseVisualStyleBackColor = true;
            this.but11.Click += new System.EventHandler(this.Move_Click);
            // 
            // but12
            // 
            this.but12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.but12.Location = new System.Drawing.Point(366, 19);
            this.but12.Name = "but12";
            this.but12.Size = new System.Drawing.Size(48, 44);
            this.but12.TabIndex = 9;
            this.but12.UseVisualStyleBackColor = true;
            this.but12.Click += new System.EventHandler(this.Move_Click);
            // 
            // but13
            // 
            this.but13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.but13.Location = new System.Drawing.Point(420, 19);
            this.but13.Name = "but13";
            this.but13.Size = new System.Drawing.Size(48, 44);
            this.but13.TabIndex = 10;
            this.but13.UseVisualStyleBackColor = true;
            this.but13.Click += new System.EventHandler(this.Move_Click);
            // 
            // but21
            // 
            this.but21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.but21.Location = new System.Drawing.Point(312, 69);
            this.but21.Name = "but21";
            this.but21.Size = new System.Drawing.Size(48, 44);
            this.but21.TabIndex = 11;
            this.but21.UseVisualStyleBackColor = true;
            this.but21.Click += new System.EventHandler(this.Move_Click);
            // 
            // but22
            // 
            this.but22.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.but22.Location = new System.Drawing.Point(366, 69);
            this.but22.Name = "but22";
            this.but22.Size = new System.Drawing.Size(48, 44);
            this.but22.TabIndex = 12;
            this.but22.UseVisualStyleBackColor = true;
            this.but22.Click += new System.EventHandler(this.Move_Click);
            // 
            // but23
            // 
            this.but23.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.but23.Location = new System.Drawing.Point(420, 69);
            this.but23.Name = "but23";
            this.but23.Size = new System.Drawing.Size(48, 44);
            this.but23.TabIndex = 13;
            this.but23.UseVisualStyleBackColor = true;
            this.but23.Click += new System.EventHandler(this.Move_Click);
            // 
            // but31
            // 
            this.but31.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.but31.Location = new System.Drawing.Point(312, 120);
            this.but31.Name = "but31";
            this.but31.Size = new System.Drawing.Size(48, 44);
            this.but31.TabIndex = 14;
            this.but31.UseVisualStyleBackColor = true;
            this.but31.Click += new System.EventHandler(this.Move_Click);
            // 
            // but32
            // 
            this.but32.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.but32.Location = new System.Drawing.Point(366, 120);
            this.but32.Name = "but32";
            this.but32.Size = new System.Drawing.Size(48, 44);
            this.but32.TabIndex = 15;
            this.but32.UseVisualStyleBackColor = true;
            this.but32.Click += new System.EventHandler(this.Move_Click);
            // 
            // but33
            // 
            this.but33.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.but33.Location = new System.Drawing.Point(420, 120);
            this.but33.Name = "but33";
            this.but33.Size = new System.Drawing.Size(48, 44);
            this.but33.TabIndex = 16;
            this.but33.UseVisualStyleBackColor = true;
            this.but33.Click += new System.EventHandler(this.Move_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 231);
            this.Controls.Add(this.but33);
            this.Controls.Add(this.but32);
            this.Controls.Add(this.but31);
            this.Controls.Add(this.but23);
            this.Controls.Add(this.but22);
            this.Controls.Add(this.but21);
            this.Controls.Add(this.but13);
            this.Controls.Add(this.but12);
            this.Controls.Add(this.but11);
            this.Controls.Add(this.butConnect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFriendPort;
        private System.Windows.Forms.TextBox txtFriendIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMyPort;
        private System.Windows.Forms.TextBox txtMyIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but11;
        private System.Windows.Forms.Button but12;
        private System.Windows.Forms.Button but13;
        private System.Windows.Forms.Button but21;
        private System.Windows.Forms.Button but22;
        private System.Windows.Forms.Button but23;
        private System.Windows.Forms.Button but31;
        private System.Windows.Forms.Button but32;
        private System.Windows.Forms.Button but33;
    }
}

