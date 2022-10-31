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
using Viapos.LicenceManager.LicenceInformations.Tables;
using WatsonTcp;

namespace Viapos.LicenceManager.TCPClientx
{

    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private TCPClient client;
        public Form1()
        {

            InitializeComponent();
            client = new TCPClient();
            client.client.MessageReceived += Message_Received;
            client.client.ServerConnected += Server_Connected;
        }

        private void Server_Connected(object sender, EventArgs e)
        {
            client.SendMesssage(MessageType.SendUserName, "Emine");
        }

        private void Message_Received(object sender, MessageReceivedFromServerEventArgs e)
        {
            TcpMessage msg = JsonConvert.DeserializeObject<TcpMessage>(Encoding.UTF8.GetString(e.Data));

            switch (msg.MessageType)
            {
                case MessageType.Message:

                    memoEdit1.Invoke((MethodInvoker)delegate
                    {
                        memoEdit1.Text +="Server:"+ msg.Message + System.Environment.NewLine;
                    });
                    break;

                case MessageType.LicenseControl:
                    break;

                case MessageType.ServerRejection:
                    MessageBox.Show(msg.Message);
                    Application.Exit();
                    break;

                case MessageType.ServerClosed:
                    MessageBox.Show(msg.Message);
                    Application.Exit();
                    break;
            }


        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client.ClientStart();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            memoEdit1.Text += "BEN:" + textEdit1.Text + System.Environment.NewLine;
            client.SendMesssage(MessageType.Message, textEdit1.Text);
            textEdit1.Text = "";
        }
    }
}
