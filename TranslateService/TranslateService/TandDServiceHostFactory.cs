using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace TranslateService
{
    class TandDServiceHostFactory: ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var ret = base.CreateServiceHost(serviceType, baseAddresses);
            
            var endpoint = ret.Description.Endpoints.Find(typeof(ITandD));

            if (endpoint != null)
                endpoint.Behaviors.Add(new TokenEndpointBehavior());

            return ret;
        }
    }
}
