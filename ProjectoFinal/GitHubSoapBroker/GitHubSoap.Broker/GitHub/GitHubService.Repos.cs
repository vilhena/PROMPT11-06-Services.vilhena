using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using GitHubSoap.Domain.DataContracts;
using GitHubSoap.Domain.DataContracts.Repos;

namespace GitHubSoap.Broker.GitHub
{
    partial class GitHubService
    {
        #region Repositories Git Hub

        //GET /user/repos
        public IEnumerable<Repository> ListYourRepositories()
        {
            Client.AddAuthentication();
            var response = Client.GetAsync(
                "https://api.github.com/user/repos").Result;

            return response.Content.ReadAsAsync<IEnumerable<Repository>>().Result;
        }

        //POST /user/repos
        public Repository CreateRepository(RepositoryRequest repositoryRequest)
        {
            Client.AddAuthentication();
            var response = Client.PostAsync(
                "https://api.github.com/user/repos"
                , new ObjectContent<RepositoryRequest>(repositoryRequest, "application/json")).Result;

            return response.Content.ReadAsAsync<Repository>().Result;
        }

        //GET /repos/:user/:repo
        public RepositoryDetail GetRepository(string user, string repo)
        {
            //Client.AddAuthentication();
            var response = Client.GetAsync(
                "https://api.github.com/repos/" + user + "/" + repo
                ).Result;

            return response.Content.ReadAsAsync<RepositoryDetail>().Result;
        }


        //PATCH /repos/:user/:repo
        public RepositoryDetail EditRepository(RepositoryRequest editRepository, string user, string repo)
        {
            Client.AddAuthentication();

            //var response = Client.
            var request = new HttpRequestMessage<RepositoryRequest>(editRepository
                                                               , new HttpMethod("PATCH")
                                                               ,
                                                               new Uri("https://api.github.com/repos/" + user + "/" +
                                                                       repo)
                                                               ,
                                                               new List<MediaTypeFormatter> { new JsonMediaTypeFormatter() });

            var response = Client.SendAsync(request).Result;

            return response.Content.ReadAsAsync<RepositoryDetail>().Result;
        }

        //GET /repos/:user/:repo/contributors

        public IEnumerable<User> ListRepositoryContributors(string user,string repo)
        {
            var response = Client.GetAsync(
                "https://api.github.com/repos/" + user + "/" + repo + "/contributors").Result;

            return response.Content.ReadAsAsync<IEnumerable<User>>().Result; 
        }


        //GET /repos/:user/:repo/languages

        public string ListRepositoryLanguages(string user, string repo)
        {
            var response = Client.GetAsync(
                "https://api.github.com/repos/" + user + "/" + repo + "/languages").Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        #endregion
    }
}
