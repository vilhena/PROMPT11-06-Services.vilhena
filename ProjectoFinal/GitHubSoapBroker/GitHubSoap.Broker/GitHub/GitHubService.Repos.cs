using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var response = Client.Get(GitHubUriProvider.ListYourRepositories);

            return GetResponse<IEnumerable<Repository>>(response);
        }

        //POST /user/repos
        public Repository CreateRepository(RepositoryRequest repositoryRequest)
        {
            Client.AddAuthentication();
            var response = Client.Post(GitHubUriProvider.CreateRepository, repositoryRequest);
            return GetResponse<Repository>(response);
        }

        //GET /repos/:user/:repo
        public RepositoryDetail GetRepository(string user, string repo)
        {
            var response = Client.Get(string.Format(GitHubUriProvider.GetRepository, user, repo));
            return GetResponse<RepositoryDetail>(response);
        }


        //PATCH /repos/:user/:repo
        public RepositoryDetail EditRepository(RepositoryRequest editRepository, string user, string repo)
        {
            Client.AddAuthentication();
            var response = Client.Patch(string.Format(GitHubUriProvider.EditRepository, user, repo), editRepository);
            return GetResponse<RepositoryDetail>(response);
        }

        //GET /repos/:user/:repo/contributors

        public IEnumerable<User> ListRepositoryContributors(string user,string repo)
        {
            var response = Client.Get(string.Format(GitHubUriProvider.ListRepositoryContributors, user, repo));
            return GetResponse<IEnumerable<User>>(response); 
        }


        //GET /repos/:user/:repo/languages

        public string ListRepositoryLanguages(string user, string repo)
        {
            var response = Client.Get(string.Format(GitHubUriProvider.ListRepositoryLanguages, user, repo));
            return GetResponse<string>(response);
        }

        #endregion
    }
}
