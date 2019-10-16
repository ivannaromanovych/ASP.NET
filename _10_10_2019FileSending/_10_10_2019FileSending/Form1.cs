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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;

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
                this.Invoke(new Action(() =>
                {
                    listView1.Items.Add(f.Name);
                }));
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            listView1.Items.Add(openFileDialog1.FileName);
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem.Text.LastIndexOf('\\') > 0)
            {
                FileModel f = new FileModel();
                for (int i = listView1.FocusedItem.Text.LastIndexOf("\\") + 1; i < listView1.FocusedItem.Text.Length; i++)
                    f.Name += listView1.FocusedItem.Text[i];
                f.Body = new byte[6_000];
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    f.Body = System.IO.File.ReadAllBytes(listView1.FocusedItem.Text);
                    bf.Serialize(ms, f);
                    sck.Send(ms.ToArray());
                }
            }
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            FileModel f = files.FirstOrDefault(t => t.Name == listView1.FocusedItem.Text);
            if (f == null)
            {
                MessageBox.Show("this file is already on your computer");
            }
            else
            {
                saveFileDialog1.ShowDialog();
                using (FileStream fs = new FileStream(saveFileDialog1.FileName + Path.GetExtension(f.Name), FileMode.Create))
                {
                    fs.Write(f.Body, 0, f.Body.Length);
                    files.Remove(f);
                    listView1.FocusedItem.Text = saveFileDialog1.FileName + Path.GetExtension(f.Name);
                }
            }
        }
        static string[] Scopes = { DriveService.Scope.DriveReadonly };
        static string ApplicationName = "Drive API .NET Quickstart";
        private void btnSendOnDrive_Click(object sender, EventArgs e)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            //if (files.FirstOrDefault(t => t.Name == listView1.FocusedItem.Text) == null)
            //{
            //    var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            //    {
            //        Name = "My Report",
            //        MimeType = "application/vnd.google-apps.spreadsheet"
            //    };
            //    FilesResource.CreateMediaUpload request;
            //    using (var stream = new FileStream(listView1.FocusedItem.Text,
            //                            FileMode.Open))
            //    {
            //        request = service.Files.Create(
            //            fileMetadata, stream, "text/csv");
            //        request.Fields = "id";
            //        request.Upload();
            //    }
            //    var file = request.ResponseBody;
            //}
            //if (files.FirstOrDefault(t => t.Name == listView1.FocusedItem.Text) == null)
            //{
            //    var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            //    {
            //        Name = Path.GetFileName(listView1.FocusedItem.Text)
            //    };
            //    FilesResource request;
            //    using (var stream = new FileStream(listView1.FocusedItem.Text,
            //                            FileMode.Open))
            //    {
            //        request = service.Files.Create(fileMetadata);
            //        request.Fields = "id";
            //        request.Upload();
            //    }
            //    var file = request.ResponseBody;
            //}

            string _uploadFile = Path.GetFileName(listView1.FocusedItem.Text);

            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                body.Name = System.IO.Path.GetFileName(_uploadFile);
                body.MimeType = MimeMapping.GetMimeType(_uploadFile);
                // body.Parents = new List<string> { _parent };// UN comment if you want to upload to a folder(ID of parent folder need to be send as paramter in above method)
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.CreateMediaUpload request = service.Files.Create(body, stream, GetMimeType(_uploadFile));
                    request.SupportsTeamDrives = true;
                    request.Upload();
                    var res= request.ResponseBody;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Occured");
                }
            }
            else
            {
                MessageBox.Show("The file does not exist.", "404");
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
