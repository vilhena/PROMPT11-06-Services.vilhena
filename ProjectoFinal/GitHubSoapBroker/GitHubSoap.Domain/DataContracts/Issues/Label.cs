using System.Runtime.Serialization;

namespace GitHubSoap.Domain.DataContracts.Issues
{
    [DataContract]
    public class Label
    {
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string color { get; set; }
    }
}
