using IHelloBelkaContract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelkaClient
{
    public partial class Form1 : Form
    {
        IHelloBelkaContractService client;
        public Form1()
        {
            InitializeComponent();
            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel, false);
            client = (IHelloBelkaContractService)Activator.GetObject(
                typeof(IHelloBelkaContractService), "tcp://localhost:1488/AddUser");

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //client.GetMessage("Semen");
            //lblResult.Text = client.GetMessage(txtName.Text);
            dataGridView1.DataSource = client.AddUser(txtName.Text, txtLogin.Text, txtPassword.Text, rbMale.Checked == true);
        }
    }
}
