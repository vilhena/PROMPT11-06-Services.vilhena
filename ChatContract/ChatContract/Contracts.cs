using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ChatContract
{
    [ServiceContract]
    public interface IChatContractClient
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string msg, string from);
    }

    [ServiceContract(CallbackContract = typeof(IChatContractClient)
        , SessionMode = SessionMode.Required)]
    public interface IChatContractServer
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string msg);

        [OperationContract]
        void Login(string nickname);

        [OperationContract(IsTerminating = true, IsOneWay = true)]
        void Logout();
    }
}
