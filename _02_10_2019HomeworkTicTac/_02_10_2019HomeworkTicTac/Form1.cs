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

namespace _02_10_2019HomeworkTicTac
{
    public partial class Form1 : Form
    {
        Socket sck;
        EndPoint epLocal, epRemote;
        private Button[][] buttons;
        public Form1()
        {
            InitializeComponent();

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            txtMyIP.Text = GetLocalIP();
            txtFriendIP.Text = GetLocalIP();
           

        }

        private void Move_Click(object sender, EventArgs e)
        {
            try
            {
                if(((Button)sender).Enabled==true)
                {
                    int p = ((Button)sender).Name.Length - 2;
                    byte[] move = new byte[20];
                    move = Encoding.UTF8.GetBytes(((Button)sender).Name[p].ToString()+ ((Button)sender).Name[p+1].ToString());

                    sck.Send(move);

                    ((Button)sender).Text = "X";
                    ((Button)sender).Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MoveCallBack(IAsyncResult ar)
        {
            try
            {
                int size = sck.EndReceiveFrom(ar, ref epRemote);
                if (size > 0)
                {
                    byte[] receivedData = new byte[2000];
                    receivedData = (byte[])ar.AsyncState;
                    string receivedString = Encoding.UTF8.GetString(receivedData);
                    switch (int.Parse(receivedString[0].ToString()))
                    {
                        case 1:
                            switch (int.Parse(receivedString[1].ToString()))
                            {
                                case 1:
                                    but11.Text = "O";
                                    but11.Enabled = false;
                                    break;
                                case 2:
                                    but12.Text = "O";
                                    but12.Enabled = false;
                                    break;
                                case 3:
                                    but13.Text = "O";
                                    but13.Enabled = false;
                                    break;
                            }
                            
                            break;
                        case 2:
                            switch (int.Parse(receivedString[1].ToString()))
                            {
                                case 1:
                                    but21.Text = "O";
                                    but21.Enabled = false;
                                    break;
                                case 2:
                                    but22.Text = "O";
                                    but22.Enabled = false;
                                    break;
                                case 3:
                                    but23.Text = "O";
                                    but23.Enabled = false;
                                    break;
                            }
                            break;
                        case 3:
                            switch (int.Parse(receivedString[1].ToString()))
                            {
                                case 1:
                                    but31.Text = "O";
                                    but31.Enabled = false;
                                    break;
                                case 2:
                                    but32.Text = "O";
                                    but32.Enabled = false;
                                    break;
                                case 3:
                                    but33.Text = "O";
                                    but33.Enabled = false;
                                    break;
                            }
                            break;
                    }
                }
                byte[] buffer = new byte[2_000];
                sck.BeginReceiveFrom(
                    buffer, 0, buffer.Length,
                    SocketFlags.None,
                    ref epRemote,
                    new AsyncCallback(MoveCallBack),
                    buffer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            epLocal = new IPEndPoint(IPAddress.Parse(txtMyIP.Text), int.Parse(txtMyPort.Text));
            epRemote = new IPEndPoint(IPAddress.Parse(txtFriendIP.Text), int.Parse(txtFriendPort.Text));

            sck.Bind(epLocal);
            sck.Connect(epRemote);

            byte[] buffer = new byte[1098];
            sck.BeginReceiveFrom(
                buffer, 0, buffer.Length,
                SocketFlags.None,
                ref epRemote,
                new AsyncCallback(MoveCallBack),
                buffer);
            butConnect.Enabled = false;
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

    }
}
