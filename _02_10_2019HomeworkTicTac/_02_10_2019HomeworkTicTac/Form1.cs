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
        private List<List<Button>> buttons = new List<List<Button>>();
        string current;
        public Form1()
        {
            InitializeComponent();

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            txtMyIP.Text = GetLocalIP();
            txtFriendIP.Text = GetLocalIP();

            buttons.Add(new List<Button>() { but00, but01, but02 });
            buttons.Add(new List<Button>() { but10, but11, but12 });
            buttons.Add(new List<Button>() { but20, but21, but22 });

        }
        public bool equals3(string a, string b, string c)
        {
            return a == b && b == c;
        }
        public void ChangeButtonState(bool state)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    buttons[i][j].Enabled = state;
        }
        public string Won()
        {
            for (int i = 0; i < 3; i++)
                if ((equals3(buttons[i][0].Text, buttons[i][1].Text, buttons[i][2].Text) && buttons[1][i].Text != "") || (equals3(buttons[0][i].Text, buttons[1][i].Text, buttons[2][i].Text) && buttons[1][i].Text != ""))
                    return buttons[i][0].Text;
            if (equals3(buttons[0][0].Text, buttons[1][1].Text, buttons[2][2].Text)||equals3(buttons[0][2].Text, buttons[1][1].Text, buttons[2][0].Text))
                return buttons[1][1].Text;

            return "";
        }
        private void Move_Click(object sender, EventArgs e)
        {
            try
            {
                if (((Button)sender).Enabled == true && current != "X") 
                {
                    int p = ((Button)sender).Name.Length - 2;
                    byte[] move = new byte[20];
                    move = Encoding.UTF8.GetBytes(((Button)sender).Name[p].ToString()+ ((Button)sender).Name[p+1].ToString());

                    sck.Send(move);
                    current = ((Button)sender).Text = "X";
                    ((Button)sender).Enabled = false;
                    if (Won() != "")
                    {
                        lblWinner.Text = "Player \'" + Won() + "\' win";
                        ChangeButtonState(false);
                    }
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
                    int x = int.Parse(receivedString[0].ToString());
                    int y = int.Parse(receivedString[1].ToString());
                    current = buttons[x][y].Text = "O";
                    buttons[x][y].Enabled = false;
                    if (Won() != "")
                    {
                        lblWinner.Text = "Player \'" + Won() + "\' win";
                        ChangeButtonState(false);
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
