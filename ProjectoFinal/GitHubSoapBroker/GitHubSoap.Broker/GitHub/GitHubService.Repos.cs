using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        #endregion
    }
}
