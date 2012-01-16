using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GitHubSoap.Domain.FaultContracts
{
    [DataContract]
    public class InvalidRequestFault
    {
        [DataMember]
        public string Reason { get; set; }

        public string JsonRequest { get; set; } 
    }
}
