using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using ChatContract;

namespace ChatServiceClient
{
    public partial class Chat : Form,IChatContractClient
    {

        public void ReceiveMessage(string msg, string from)
        {
            ChatText.Text +=
                string.Format("{0} : {1}{2}", from, msg, Environment.NewLine);
        }


        private static IChatContractServer _server = null;

        public Chat()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            _server = DuplexChannelFactory<IChatContractServer>.CreateChannel(
                this,
                new NetTcpBinding(SecurityMode.None),
                new EndpointAddress("net.tcp://localhost:8080")
                );
            _server.Login(Nickname.Text);
        }

        private void Send_Click(object sender, EventArgs e)
        {
            _server.SendMessage(Msg.Text);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            _server.Logout();
        }

    }
}
