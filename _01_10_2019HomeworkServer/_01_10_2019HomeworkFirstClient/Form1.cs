using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_10_2019HomeworkFirstClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(txtMessage.Text))
            {
                IPAddress iPAddress = IPAddress.Parse("127.0.0.57");
                IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 1098);

                TcpClient client = new TcpClient();
                client.Connect(iPEndPoint);

                using (NetworkStream stream = client.GetStream())
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        if (!String.IsNullOrWhiteSpace(reader.ReadString()))
                            lbConversation.Items.Add(reader.ReadString());
                    }
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(txtMessage.Text);
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            lbConversation.Items.Add(reader.ReadString());
                        }
                    }
                }
                client.Close();
            }
        }
    }
}
