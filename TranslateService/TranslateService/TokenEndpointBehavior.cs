using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace TranslateService
{
    //[DataContract]
    public class Token
    {
        //[DataMember]
        public int Id { get; set; }
        //[DataMember]
        public string Key { get; set; }
    }

    public class TokenEndpointBehavior : IEndpointBehavior, IDispatchMessageInspector, IClientMessageInspector
    {
        public void Validate(ServiceEndpoint endpoint)
        {

        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);

        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(this);
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            Console.WriteLine("AfterReceiveRequest");
            var ix = request.Headers.FindHeader("token", "");
            var token = request.Headers.GetHeader<Token>(ix);
            Console.WriteLine("Messsage Token Server: {0}, {1}", token.Id, token.Key);
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            Console.WriteLine("BeforeSendReply");
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            Console.WriteLine("BeforeSendRequest");

            request.Headers.Add(MessageHeader.CreateHeader("token", "", new Token
            {
                Id = 123,
                Key = "abc"
            }));
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            Console.WriteLine("AfterReceiveReply");
        }
    }
}
