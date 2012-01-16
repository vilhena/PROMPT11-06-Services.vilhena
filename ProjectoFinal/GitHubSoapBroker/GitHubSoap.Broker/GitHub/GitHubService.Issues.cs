using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.ServiceModel;
using System.Text;
using GitHubSoap.Domain.DataContracts.Issues;
using GitHubSoap.Domain.FaultContracts;

namespace GitHubSoap.Broker.GitHub
{
    partial class GitHubService
    {
        #region Issue Git Hub

        //GET /repos/:user/:repo/issues
        public IEnumerable<Issue> ListIssuesForRepository(string user, string repo)
        {
            var response = Client.Get(
                string.Format(GitHubUriProvider.ListIssuesForRepository, user, repo));
            return GetResponse<IEnumerable<Issue>>(response);
        }


        //POST /repos/:user/:repo/issues
        public Issue CreateIssue(IssueRequest issueRequest, string user, string repo)
        {
            Client.AddAuthentication();
            var response = Client.Post(string.Format(GitHubUriProvider.CreateIssue, user, repo), issueRequest);
            return GetResponse<Issue>(response);
        }

        //PATCH /repos/:user/:repo/issues/:id
        public Issue EditIssue(IssueRequest editIssue, string user, string repo, int id)
        {
            Client.AddAuthentication();
            var response = Client.Patch(string.Format(GitHubUriProvider.EditIssue, user, repo, id), editIssue);
            return GetResponse<Issue>(response);
        }

        //GET /repos/:user/:repo/issues/:number
        public Issue GetSingleIssue(string user, string repo, int id)
        {
            var response = Client.Get(string.Format(GitHubUriProvider.GetSingleIssue, user, repo, id));
            return GetResponse<Issue>(response);
        }

        //GET /issues
        public IEnumerable<Issue> ListYourIssues()
        {
            Client.AddAuthentication();
            var response = Client.Get(GitHubUriProvider.ListYourIssues);
            return GetResponse<IEnumerable<Issue>>(response);
        }

        #endregion
    }
}
