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

        //

        #endregion
    }
}
