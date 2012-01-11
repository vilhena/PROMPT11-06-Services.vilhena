using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GitHubSoap.Domain.DataContracts.Repos
{

    #region Repository Request
//    {
//  "name": "Hello-World",
//  "description": "This is your first repo",
//  "homepage": "https://github.com",
//  "private": false,
//  "has_issues": true,
//  "has_wiki": true,
//  "has_downloads": true
//}
    #endregion

    [DataContract]
    public class RepositoryRequest
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string homepage { get; set; }
        [DataMember]
        public bool Private { get; set; } //TODO: resolve this
        [DataMember]
        public bool has_issues { get; set; }
        [DataMember]
        public bool has_wiki { get; set; }
        [DataMember]
        public bool has_downloads { get; set; }

    }
}
