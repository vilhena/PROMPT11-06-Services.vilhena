using System.ServiceModel;
using GitHubSoap.Domain.ServiceContracts;

namespace GitHubSoap.Broker.GitHub
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    partial class GitHubService : IGitHubService
    {
        private GitHubHttpClient Client { get; set; }

        public GitHubService(GitHubHttpClient httpClient)
        {
            Client = httpClient;
        }
    }
}
