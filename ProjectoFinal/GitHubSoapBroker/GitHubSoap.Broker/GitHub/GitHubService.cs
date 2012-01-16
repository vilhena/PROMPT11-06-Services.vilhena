using System.Net.Http;
using System.ServiceModel;
using GitHubSoap.Domain.FaultContracts;
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

        private static T GetResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                if (((int)response.StatusCode) >= 500)
                {
                    throw new FaultException<ServiceUnavailableFault>(new ServiceUnavailableFault() { Reason = response.ReasonPhrase });
                }
                else
                {
                    throw new FaultException<InvalidRequestFault>(new InvalidRequestFault()
                    {
                        Reason = response.ReasonPhrase,
                        JsonRequest =
                            response.RequestMessage.ToString()
                    });
                }
            }
        }
    }
}
