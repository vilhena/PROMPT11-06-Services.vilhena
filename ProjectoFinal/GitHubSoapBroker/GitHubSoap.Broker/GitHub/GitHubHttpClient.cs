using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using GitHubSoap.Domain.DataContracts.Repos;
using GitHubSoap.Domain.FaultContracts;

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


        public HttpResponseMessage Get(string request)
        {
            try
            {
                return this.GetAsync(request).Result;
            }
            catch (Exception e)
            {
                throw new FaultException<ServiceUnavailableFault>(
                    new ServiceUnavailableFault() { Reason = e.Message });
            }
        }

        public HttpResponseMessage Post<T>(string request, T content)
        {
            try
            {
                return this.PostAsync(request
                                      , new ObjectContent<T>(content, "application/json")).Result;
            }
            catch (Exception e)
            {
                throw new FaultException<ServiceUnavailableFault>(
                    new ServiceUnavailableFault() { Reason = e.Message });
            }
        }

        public HttpResponseMessage Patch<T>(string request, T content)
        {
            try
            {
                var patchrequest = new HttpRequestMessage<T>(content
                                                             , new HttpMethod("PATCH")
                                                             , new Uri(request)
                                                             , new List<MediaTypeFormatter> { new JsonMediaTypeFormatter() });

                return this.SendAsync(patchrequest).Result;

            }
            catch (Exception e)
            {
                throw new FaultException<ServiceUnavailableFault>(
                    new ServiceUnavailableFault() {Reason = e.Message});
            }
        }


    }
}
