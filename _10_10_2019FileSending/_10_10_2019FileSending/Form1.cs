using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10_10_2019FileSending
{
    public partial class Form1 : Form
    {
        Socket sck;
        EndPoint epLocal, epRemote;
        List<FileModel> files = new List<FileModel>();
        public Form1()
        {
            InitializeComponent();

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            txtMyIP.Text = GetLocalIP();
            txtFriendIP.Text = GetLocalIP();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            epLocal = new IPEndPoint(IPAddress.Parse(txtMyIP.Text), int.Parse(txtMyPort.Text));
            epRemote = new IPEndPoint(IPAddress.Parse(txtFriendIP.Text), int.Parse(txtFriendPort.Text));
            sck.Bind(epLocal);
            sck.Connect(epRemote);
            byte[] buffer = new byte[600_000];
            sck.BeginReceiveFrom(
                buffer, 0, buffer.Length,
                SocketFlags.None,
                ref epRemote,
                new AsyncCallback(MoveCallBack),
                buffer);
            btnConnect.Enabled = false;
        }

        private void MoveCallBack(IAsyncResult ar)
        {
            try
            {
                int size = sck.EndReceiveFrom(ar, ref epRemote);
                if (size > 0) 
                {
                    byte[] receivedData = new byte[600_000];
                    receivedData = (byte[])ar.AsyncState;
                    FileModel f = new FileModel();
                    using (MemoryStream ms = new MemoryStream(receivedData))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        f = bf.Deserialize(ms) as FileModel;
                    }
                    files.Add(f);
                    listView1.Items.Add(f.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MoveCallBack " + ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            listView1.Items.Add(openFileDialog1.FileName);
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            //move = Encoding.UTF8.GetBytes()
            FileModel f = new FileModel();
            for (int i = listView1.FocusedItem.Text.LastIndexOf("\\") + 1; i < listView1.FocusedItem.Text.Length; i++)
                f.Name += listView1.FocusedItem.Text[i];
            f.Body = new byte[6_000];
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                f.Body = File.ReadAllBytes(listView1.FocusedItem.Text);
                bf.Serialize(ms, f);
                sck.Send(ms.ToArray());
            }
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
