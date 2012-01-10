using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using GitHubSoap.Domain.DataContracts;
using GitHubSoap.Domain.DataContracts.Issues;
using GitHubSoap.Domain.ServiceContracts;

namespace GitHubSoap.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ChannelFactory<IGitHubService>(
                    new BasicHttpBinding(),
                    "http://localhost/github");

            var service = client.CreateChannel();

            //var issues = service.ListIssuesForRepository("NancyFx", "Nancy");

            var issueRequest = new IssueRequest
                                   {
                                       //assignee = "vilhena",
                                       body = "test body",
                                       //labels = new string[]{"label1","label2"},
                                       //milestone = 1,
                                       title = "My first Issue"
                                   };
            var newIssue = service.CreateIssue(issueRequest, "vilhena", "PROMPT11-06-Services.vilhena");

            var created = service.ListIssuesForRepository("vilhena", "PROMPT11-06-Services.vilhena");

            issueRequest.title = "test body updated " + newIssue.number;
            var editedissue = service.EditIssue(issueRequest, "vilhena" , "PROMPT11-06-Services.vilhena", newIssue.number);


            var findIssue = service.GetSingleIssue("vilhena", "PROMPT11-06-Services.vilhena", editedissue.number);

            var myIssues = service.ListYourIssues();

            var myRepositories = service.ListYourRepositories();
        }
    }
}
