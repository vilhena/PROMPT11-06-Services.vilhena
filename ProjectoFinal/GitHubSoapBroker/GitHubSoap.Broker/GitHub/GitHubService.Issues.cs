using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using GitHubSoap.Domain.DataContracts.Issues;

namespace GitHubSoap.Broker.GitHub
{
    partial class GitHubService
    {
        #region Issue Git Hub

        //GET /repos/:user/:repo/issues
        public IEnumerable<Issue> ListIssuesForRepository(string user, string repo)
        {
            var response = Client.GetAsync(
                "https://api.github.com/repos/" + user + "/" + repo + "/issues").Result;

            return response.Content.ReadAsAsync<IEnumerable<Issue>>().Result;
        }


        //POST /repos/:user/:repo/issues
        public Issue CreateIssue(IssueRequest issueRequest, string user, string repo)
        {
            Client.AddAuthentication();
            var response = Client.PostAsync(
                "https://api.github.com/repos/" + user + "/" + repo + "/issues"
                , new ObjectContent<IssueRequest>(issueRequest, "application/json")
                ).Result;

            return response.Content.ReadAsAsync<Issue>().Result;
        }

        //PATCH /repos/:user/:repo/issues/:id
        public Issue EditIssue(IssueRequest editIssue, string user, string repo, int id)
        {
            Client.AddAuthentication();

            //var response = Client.
            var request = new HttpRequestMessage<IssueRequest>(editIssue
                                                               , new HttpMethod("PATCH")
                                                               ,
                                                               new Uri("https://api.github.com/repos/" + user + "/" +
                                                                       repo + "/issues/" + id)
                                                               ,
                                                               new List<MediaTypeFormatter> { new JsonMediaTypeFormatter() });

            var response = Client.SendAsync(request).Result;

            return response.Content.ReadAsAsync<Issue>().Result;
        }

        //GET /repos/:user/:repo/issues/:number
        public Issue GetSingleIssue(string user, string repo, int id)
        {
            var response = Client.GetAsync(
                "https://api.github.com/repos/" + user + "/" + repo + "/issues/" + id).Result;

            return response.Content.ReadAsAsync<Issue>().Result;
        }

        //GET /issues
        public IEnumerable<Issue> ListYourIssues()
        {
            Client.AddAuthentication();
            var response = Client.GetAsync(
                "https://api.github.com/issues").Result;

            return response.Content.ReadAsAsync<IEnumerable<Issue>>().Result;
        }

        #endregion
    }
}
