using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GitHubSoap.Domain.DataContracts.Repos
{

    #region Repository Detail Git Hub
//    {
//  "url": "https://api.github.com/repos/octocat/Hello-World",
//  "html_url": "https://github.com/octocat/Hello-World",
//  "clone_url": "https://github.com/octocat/Hello-World.git",
//  "git_url": "git://github.com/octocat/Hello-World.git",
//  "ssh_url": "git@github.com:octocat/Hello-World.git",
//  "svn_url": "https://svn.github.com/octocat/Hello-World",
//  "owner": {
//    "login": "octocat",
//    "id": 1,
//    "avatar_url": "https://github.com/images/error/octocat_happy.gif",
//    "gravatar_id": "somehexcode",
//    "url": "https://api.github.com/users/octocat"
//  },
//  "name": "Hello-World",
//  "description": "This your first repo!",
//  "homepage": "https://github.com",
//  "language": null,
//  "private": false,
//  "fork": false,
//  "forks": 9,
//  "watchers": 80,
//  "size": 108,
//  "master_branch": "master",
//  "open_issues": 0,
//  "pushed_at": "2011-01-26T19:06:43Z",
//  "created_at": "2011-01-26T19:01:12Z",
//  "organization": {
//    "login": "octocat",
//    "id": 1,
//    "avatar_url": "https://github.com/images/error/octocat_happy.gif",
//    "gravatar_id": "somehexcode",
//    "url": "https://api.github.com/users/octocat",
//    "type": "Organization"
//  },
//  "parent": {
//    "url": "https://api.github.com/repos/octocat/Hello-World",
//    "html_url": "https://github.com/octocat/Hello-World",
//    "clone_url": "https://github.com/octocat/Hello-World.git",
//    "git_url": "git://github.com/octocat/Hello-World.git",
//    "ssh_url": "git@github.com:octocat/Hello-World.git",
//    "svn_url": "https://svn.github.com/octocat/Hello-World",
//    "owner": {
//      "login": "octocat",
//      "id": 1,
//      "avatar_url": "https://github.com/images/error/octocat_happy.gif",
//      "gravatar_id": "somehexcode",
//      "url": "https://api.github.com/users/octocat"
//    },
//    "name": "Hello-World",
//    "description": "This your first repo!",
//    "homepage": "https://github.com",
//    "language": null,
//    "private": false,
//    "fork": false,
//    "forks": 9,
//    "watchers": 80,
//    "size": 108,
//    "master_branch": "master",
//    "open_issues": 0,
//    "pushed_at": "2011-01-26T19:06:43Z",
//    "created_at": "2011-01-26T19:01:12Z"
//  },
//  "source": {
//    "url": "https://api.github.com/repos/octocat/Hello-World",
//    "html_url": "https://github.com/octocat/Hello-World",
//    "clone_url": "https://github.com/octocat/Hello-World.git",
//    "git_url": "git://github.com/octocat/Hello-World.git",
//    "ssh_url": "git@github.com:octocat/Hello-World.git",
//    "svn_url": "https://svn.github.com/octocat/Hello-World",
//    "owner": {
//      "login": "octocat",
//      "id": 1,
//      "avatar_url": "https://github.com/images/error/octocat_happy.gif",
//      "gravatar_id": "somehexcode",
//      "url": "https://api.github.com/users/octocat"
//    },
//    "name": "Hello-World",
//    "description": "This your first repo!",
//    "homepage": "https://github.com",
//    "language": null,
//    "private": false,
//    "fork": false,
//    "forks": 9,
//    "watchers": 80,
//    "size": 108,
//    "master_branch": "master",
//    "open_issues": 0,
//    "pushed_at": "2011-01-26T19:06:43Z",
//    "created_at": "2011-01-26T19:01:12Z"
//  },
//  "has_issues": true,
//  "has_wiki": true,
//  "has_downloads": true
//}

    #endregion

    [DataContract]
    public class RepositoryDetail
    {
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string html_url { get; set; }
        [DataMember]
        public string clone_url { get; set; }
        [DataMember]
        public string git_url { get; set; }
        [DataMember]
        public string ssh_url { get; set; }
        [DataMember]
        public string svn_url { get; set; }
        [DataMember]
        public User owner { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string homepage { get; set; }
        [DataMember]
        public string language { get; set; }
        [DataMember]
        public bool Private { get; set; } //TODO:changethis
        [DataMember]
        public bool fork { get; set; }
        [DataMember]
        public int forks { get; set; }
        [DataMember]
        public int watchers { get; set; }
        [DataMember]
        public int size { get; set; }
        [DataMember]
        public string master_branch { get; set; }
        [DataMember]
        public int open_issues { get; set; }
        [DataMember]
        public string created_at { get; set; }
        [DataMember]
        public string updated_at { get; set; }

        //TODO: fillthis
        //public string orgatization { get; set; }
        [DataMember]
        public Repository parent { get; set; }

        [DataMember]
        public Repository source { get; set; }

        [DataMember]
        public bool has_issues { get; set; }
        [DataMember]
        public bool has_wiki { get; set; }
        [DataMember]
        public bool has_downloads { get; set; }
    }
}
