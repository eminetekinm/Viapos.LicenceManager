using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Viapos.LicenceManager.LicenceInformations.Enum;
using Viapos.LicenceManager.LicenceInformations.Maneger;
using Viapos.LicenceManager.LicenceInformations.Tables;
using WatsonTcp;

namespace Viapos.LicenceManager.LicenceServerx
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        WatsonTcpServer server;
        List<Client> clients = new List<Client>();
        LicenceConfirmation licenseConfirm = new LicenceConfirmation();
        private int licCount = 0;
        public Form1()
        {
            InitializeComponent();
            server = new WatsonTcpServer("192.168.1.127", 4345);
            server.ClientConnected += Client_Connected;
            server.ClientDisconnected += Client_Disconnected;
            server.MessageReceived += Message_Receiverd;
            gridControl1.DataSource = clients;
            GetLicenseInfo();
        }
        private void GetLicenseInfo()
        {
            var info = licenseConfirm.GetLicenseInfo();
            txtKullaniciAdi.Text = info.UserName;
            txtSirkeetAdi.Text = info.Company;
            txtLisansSayisi.Text = "0/" + info.LicenseCount.ToString();
            licCount = info.LicenseCount;
        }
        private void Message_Receiverd(object sender, MessageReceivedFromClientEventArgs e)
        {
            TcpMessage msg = JsonConvert.DeserializeObject<TcpMessage>(Encoding.UTF8.GetString(e.Data));
            Client clientName = clients.FirstOrDefault(c => c.IpAddress == e.IpPort);
            switch (msg.MessageType)
            {
                case MessageType.Message:

                    memoEdit1.Invoke((MethodInvoker)delegate
                    {
                        memoEdit1.Text += clientName.UserName + ":" + msg.Message + System.Environment.NewLine;
                    });
                    break;

                case MessageType.SendUserName:
                    var client = clients.SingleOrDefault(c => c.IpAddress == e.IpPort);

                    if (client != null)
                    {
                        client.UserName = msg.Message;
                    }


                    break;
            }


        }

        private void Client_Disconnected(object sender, ClientDisconnectedEventArgs e)
        {
            var disconnectedClients = clients.SingleOrDefault(c => c.IpAddress == e.IpPort);
            clients.Remove(disconnectedClients);
            txtLisansSayisi.Invoke((MethodInvoker)delegate
            {
                txtLisansSayisi.Text = gridView1.RowCount + "/" + licCount;
            });
        }

        private void Client_Connected(object sender, ClientConnectedEventArgs e)
        {
            if (gridView1.RowCount >= licCount)
            {
                SendMessage(e.IpPort, MessageType.ServerRejection, "MAX KULLANICI SAYISI AŞILDI");
                return;
            }

            clients.Add(new Client
            {

                IpAddress = e.IpPort,
                Time = DateTime.Now
            });
            txtLisansSayisi.Invoke((MethodInvoker)delegate
            {
                txtLisansSayisi.Text = gridView1.RowCount + "/" + licCount;
            });


        }




        private void baslat_Click(object sender, EventArgs e)
        {
            server.Start();
            txtServerDurum.Text = "Server Başlatıldı";
            txtServerDurum.Appearance.ForeColor = Color.Green;

        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var client in clients)
            {
                SendMessage(client.IpAddress, MessageType.ServerClosed, "SERVER KAPALI 444 29 14 ARAYIN");
            }
            System.Threading.Thread.Sleep(1000);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            var row = (Client)gridView1.GetFocusedRow();
            if (row != null)
            {
                memoEdit1.Text += "SERVER:" + textEdit1.Text + System.Environment.NewLine;
                SendMessage(row.IpAddress, MessageType.Message, textEdit1.Text);
                textEdit1.Text = "";
            }
            else
            {
                MessageBox.Show("SEÇİLİ BİR KULLANICI YOK");
            }

        }
        private void SendMessage(string ipAdress, MessageType messageType, string message)
        {
            TcpMessage msg = new TcpMessage
            {
                MessageType = messageType,
                Message = message
            };
            server.Send(ipAdress, JsonConvert.SerializeObject(msg));
        }


    }
}
