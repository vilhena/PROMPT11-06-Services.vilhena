using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using GitHubSoap.Domain.DataContracts;
using GitHubSoap.Domain.DataContracts.Issues;
using GitHubSoap.Domain.DataContracts.Repos;
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


            var issueRequest = new IssueRequest
                                   {
                                       body = "test body",
                                       title = "My first Issue"
                                   };
            var newIssue = service.CreateIssue(issueRequest, "vilhena-services", "fillwithstuff");

            var created = service.ListIssuesForRepository("vilhena-services", "fillwithstuff");

            issueRequest.title = "test body updated " + newIssue.number;
            var editedissue = service.EditIssue(issueRequest, "vilhena-services", "fillwithstuff", newIssue.number);


            var findIssue = service.GetSingleIssue("vilhena-services", "fillwithstuff", editedissue.number);

            var myIssues = service.ListYourIssues();

            var myRepositories = service.ListYourRepositories();

            var newRepository = new RepositoryRequest()
                                    {
                                        name = "First" + (new Random()).Next(1000),
                                        description = "My First",
                                        homepage = "",
                                        @private = false,
                                        has_downloads = true,
                                        has_issues = true,
                                        has_wiki = true

                                    };

            var createdRepository = service.CreateRepository(newRepository);


            var repositoryDetail = service.GetRepository("vilhena-services", "First");
        }

    }
}
