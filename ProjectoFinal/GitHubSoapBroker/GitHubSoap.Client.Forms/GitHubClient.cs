using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using GitHubSoap.Domain.DataContracts.Issues;
using GitHubSoap.Domain.DataContracts.Repos;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var issues = _service.ListIssuesForRepository(textBoxUser.Text, textBoxRepo.Text).Select(i => new ListViewItem(new string[]
                                                                                    {
                                                                                        i.title,
                                                                                        i.comments.ToString(),
                                                                                        i.body
                                                                                    })).ToArray();
            
            listViewIssues.Items.Clear();
            listViewIssues.Items.AddRange(issues);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var issue = new IssueRequest()
                            {
                                title = textBoxTitle.Text,
                                body = textBoxBody.Text
                            };
            var newIssue = _service.CreateIssue(issue, textBoxUser.Text, textBoxRepo.Text);

            listViewIssues.Items.Add(new ListViewItem(new string[]
                                                          {
                                                              newIssue.title,
                                                              newIssue.comments.ToString(),
                                                              newIssue.body
                                                          }));
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            var repos = _service.ListYourRepositories().Select(i => new ListViewItem(new string[]
                                                                                    {
                                                                                        i.name,
                                                                                        i.description,
                                                                                    })).ToArray();
            listViewRepos.Items.Clear();
            listViewRepos.Items.AddRange(repos);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var newRepository = new RepositoryRequest()
                                    {
                                        name = textBoxName.Text,
                                        description = textBoxDesc.Text,
                                        homepage = textBoxPage.Text,
                                        @private = false,
                                        has_downloads = true,
                                        has_issues = true,
                                        has_wiki = true

                                    };

            var createdRepository = _service.CreateRepository(newRepository);

            listViewRepos.Items.Add(new ListViewItem(new string[]
                                                         {
                                                             createdRepository.name,
                                                             createdRepository.description,
                                                         }));
        }


    }
}
