using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ChatContract;

namespace ChatServiceServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
    class ChatServiceImpl : IChatContractServer
    {
        private static readonly IDictionary<string, Tuple<string,IChatContractClient>> Clients =
            new Dictionary<string, Tuple<string, IChatContractClient>>();

        public void SendMessage(string msg)
        {
            var sId = OperationContext.Current.Channel.SessionId;
            var from = Clients[sId].Item1;

            foreach (var chatContractClient in Clients.Values)
            {
                chatContractClient.Item2
                    .ReceiveMessage(msg, from);
            }

            Console.WriteLine("Message from {0} using sessionId {1}", from, sId);
        }

        public void Login(string nickname)
        {
            var sId = OperationContext.Current.Channel.SessionId;
            var ch = OperationContext.Current.GetCallbackChannel<IChatContractClient>();
            Clients[sId] =
                new Tuple<string, IChatContractClient>(nickname, ch);

            Console.WriteLine("Login for {0} using sessionId {1}", nickname, sId);
        }

        public void Logout()
        {
            if (Clients.ContainsKey(OperationContext.Current.Channel.SessionId))
            {
                Clients.Remove(OperationContext.Current.Channel.SessionId);
            }
        }
    }
}
