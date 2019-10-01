using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _01_10_2019TcpClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IPAddress iPAddress = IPAddress.Parse("127.0.0.57");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 1098);

            TcpClient client = new TcpClient();
            client.Connect(iPEndPoint);

            using (NetworkStream stream = client.GetStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write("Hi, Telesyk!");
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        txtResponse.Text = reader.ReadString();
                    }
                }
            }
            client.Close();
        }
    }
}
