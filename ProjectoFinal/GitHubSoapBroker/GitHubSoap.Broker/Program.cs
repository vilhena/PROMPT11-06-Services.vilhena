﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using GitHubSoap.Broker.GitHub;
using System.ServiceModel.Description;
using GitHubSoap.Domain.ServiceContracts;

namespace GitHubSoap.Broker
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new GitHubHttpClient(
                new GitHubIdentity(
                    ConfigurationManager.AppSettings["GitHubUser"]
                    , ConfigurationManager.AppSettings["GitHubPassword"])
                );

            var service = new GitHubService(client);


            var host = new ServiceHost(service, new Uri("http://localhost"));

            host.AddServiceEndpoint(typeof (IGitHubService), new BasicHttpBinding()
                                                                 {
                                                                 }, "github");
            host.Description.Behaviors.Add(new ServiceMetadataBehavior()
                                               {
                                                   HttpGetEnabled = true,
                                                   HttpGetUrl = new Uri("http://localhost/github/wsdl")
                                               });
            host.Description.Behaviors.Add(new ServiceThrottlingBehavior()
                                               {
                                                   MaxConcurrentCalls = 1
                                               });


            host.Open();

            Console.WriteLine("Service is running...");
            Console.ReadKey();
        }
    }
}
