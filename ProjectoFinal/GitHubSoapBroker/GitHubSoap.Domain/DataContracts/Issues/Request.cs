using System.Runtime.Serialization;

namespace GitHubSoap.Domain.DataContracts.Issues
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public string html_url { get; set; }
        [DataMember]
        public string diff_url { get; set; }
        [DataMember]
        public string patch_url { get; set; }
    }
}
