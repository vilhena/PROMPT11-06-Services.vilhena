using System.Runtime.Serialization;

namespace GitHubSoap.Domain.DataContracts.Issues
{
    #region IssueRequest Post

    //    {
    //  "title": "Found a bug",
    //  "body": "I'm having a problem with this.",
    //  "assignee": "octocat",
    //  "milestone": 1,
    //  "labels": [
    //    "Label1",
    //    "Label2"
    //  ]
    //} 
    #endregion

    [DataContract]
    public class IssueRequest
    {
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string body { get; set; }
        [DataMember]
        public string assignee { get; set; }
        [DataMember]
        public int? milestone { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string[] labels { get; set; }
    }
}
