using EAGetMail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_10_2019Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailServer mailServer = new MailServer("imap.gmail.com", "wladiktest420@gmail.com", "Qwertyu-1", ServerProtocol.Imap4);
            MailClient mailClient = new MailClient("TryIt");
            mailServer.SSLConnection = true;
            mailServer.Port = 993;
            try
            {
                mailClient.Connect(mailServer);
                var res = mailClient.GetMailInfos();
                dataGridView1.DataSource = res.Select(t=>new Message{
                    )
                //foreach (var item in res)
                //{
                //    Mail mail = mailClient.GetMail(item);
                //    MessageBox.Show(mail.From.Address);
                //    break;
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    public class Message
    {
        public string From { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
    }
}
