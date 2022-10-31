using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Viapos.LicenceManager.LicenceInformations.Enum;
using Viapos.LicenceManager.LicenceInformations.Tables;
using WatsonTcp;

namespace Viapos.LicenceManager.TCPClientx
{
    public class TCPClient
    {
       public WatsonTcpClient client;
        public TCPClient()
        {
            client = new WatsonTcpClient("192.168.1.127", 4345);
            //client.MessageReceived += Message_Received;
            
        }
        public void ClientStart()
        {
            try
            {
                client.Start();
            }
            catch (SocketException)
            {

                MessageBox.Show("SERVİS CEVAP VERMİYOR 444 29 14 ARAYIN");
                Application.Exit();
            }

        }

        //private void Message_Received(object sender, MessageReceivedFromServerEventArgs e)
        //{
        //    MessageBox.Show(Encoding.UTF8.GetString(e.Data));
        //}
        public void SendMesssage(MessageType messageType, string message)
        {
            TcpMessage msg = new TcpMessage
            {
                MessageType = messageType,
                Message = message
            };

            client.Send(JsonConvert.SerializeObject(msg));
        }
    }
}
