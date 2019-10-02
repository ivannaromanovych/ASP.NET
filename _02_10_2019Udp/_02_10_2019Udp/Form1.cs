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

namespace _02_10_2019Udp
{
    public partial class Form1 : Form
    {
        Socket sck;
        EndPoint epLocal, epRemote;
        public Form1()
        {
            InitializeComponent();

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //allow to use same socket
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            txtMyIP.Text = GetLocalIP();
            txtFriendIP.Text = GetLocalIP();

        }
        private string GetLocalIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var item in host.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    return item.ToString();
                }
            }
            return "127.0.0.1";
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            epLocal = new IPEndPoint(IPAddress.Parse(txtMyIP.Text), int.Parse(txtMyPort.Text));
            epRemote = new IPEndPoint(IPAddress.Parse(txtFriendIP.Text), int.Parse(txtFriendPort.Text));

            sck.Bind(epLocal);
            sck.Connect(epRemote);

            byte[] buffer = new byte[2_000];
            sck.BeginReceiveFrom(
                buffer, 0, buffer.Length,
                SocketFlags.None,
                ref epRemote,
                new AsyncCallback(MessageCallBack),
                buffer);
            butConnect.Enabled = false;
        }

        private void MessageCallBack(IAsyncResult ar)
        {
            try
            {
                int size = sck.EndReceiveFrom(ar, ref epRemote);
                if (size > 0)
                {
                    byte[] receivedData = new byte[1098];
                    receivedData = (byte[])ar.AsyncState;
                    string receivedString = Encoding.UTF8.GetString(receivedData);
                    lbMessenger.Items.Add("Mr. Blue: " + receivedString);
                }
                byte[] buffer = new byte[2_000];
                sck.BeginReceiveFrom(
                    buffer, 0, buffer.Length,
                    SocketFlags.None,
                    ref epRemote,
                    new AsyncCallback(MessageCallBack),
                    buffer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butSend_Click(object sender, EventArgs e)
        {
            try
            {
                UTF8Encoding uTF8Encoding = new UTF8Encoding();
                byte[] msg = new byte[1500];
                msg = uTF8Encoding.GetBytes(txtMessage.Text);
                //msg = Encoding.UTF8.GetBytes(txtMessage.Text);

                sck.Send(msg);
                lbMessenger.Items.Add("Mr. Green: " + txtMessage.Text);
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
