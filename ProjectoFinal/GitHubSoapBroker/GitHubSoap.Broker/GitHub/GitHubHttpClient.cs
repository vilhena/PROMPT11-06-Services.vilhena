using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;

namespace GitHubSoap.Broker.GitHub
{
    public class GitHubHttpClient : HttpClient
    {
        public GitHubIdentity Identity { get; set; }

        public GitHubHttpClient(GitHubIdentity identity):base()
        {
            Identity = identity;
        }

         
        public void AddAuthentication()
        {
            this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Identity.AuthenticationType,
                                                                                     Identity.AutenticationToken);
        }
    }
}
