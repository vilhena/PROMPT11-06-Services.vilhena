using System.Runtime.Serialization;

namespace GitHubSoap.Domain.DataContracts
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string login { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string avatar_url { get; set; }
        [DataMember]
        public string gravatar_id { get; set; }
        [DataMember]
        public string url { get; set; }
    }
}
