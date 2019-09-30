using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ipadress = IPAddress.Parse("8.8.8.8");
            IPEndPoint iPEndPoint = new IPEndPoint(ipadress, 80);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(iPEndPoint);

            byte[] bytes = Encoding.UTF8.GetBytes(txtSend.Text + "<EndString>");
            
            socket.Send(bytes);

            byte[] recBytes = new byte[1024];
            int countBytes = socket.Receive(recBytes);

            txtReceive.Text = Encoding.UTF8.GetString(recBytes, 0, countBytes);
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
