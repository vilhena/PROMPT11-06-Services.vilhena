using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GitHubSoap.Domain.FaultContracts
{
    [DataContract]
    public class MaxNumberOfRequestsExcededFault
    {
        [DataMember]
        public DateTime RetryAt { get; set; }
    }
}
