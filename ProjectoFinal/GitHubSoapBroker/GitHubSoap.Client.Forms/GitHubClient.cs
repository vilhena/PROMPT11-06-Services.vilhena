using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using GitHubSoap.Domain.ServiceContracts;

namespace GitHubSoap.Client.Forms
{
    public partial class GitHubClient : Form
    {
        private IGitHubService _service;

        public GitHubClient()
        {
            InitializeComponent();
        }

        private void bttConnect_Click(object sender, EventArgs e)
        {
            var client = new ChannelFactory<IGitHubService>(
                    new BasicHttpBinding(),
                    "http://localhost/github");

            _service = client.CreateChannel();
            ckbConnected.Checked = true;
            tabControlForm.Enabled = true;
        }


    }
}
