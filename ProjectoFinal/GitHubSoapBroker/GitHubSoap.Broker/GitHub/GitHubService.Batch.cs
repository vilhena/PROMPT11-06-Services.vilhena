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
        // Create a list from requested repositories
        public IEnumerable<Repository> CreateRepositoriesBatch(IEnumerable<RepositoryRequest> repositoriesRequests)
        {
            return repositoriesRequests
                .Select(this.CreateRepository);
        }

        public IEnumerable<RepositoryDetail> GetRepositoriesBatch(IEnumerable<KeyValuePair<string ,string>> usersAndRepos)
        {
            return usersAndRepos
                .Select(ur => this.GetRepository(ur.Key, ur.Value));
        }
    }
}
