using System;
using System.Runtime.Serialization;

namespace GitHubSoap.Domain.DataContracts.Issues
{

    #region IssueGitHub


    //    {
    //  "url": "https://api.github.com/repos/octocat/Hello-World/issues/1",
    //  "html_url": "https://github.com/octocat/Hello-World/issues/1",
    //  "number": 1347,
    //  "state": "open",
    //  "title": "Found a bug",
    //  "body": "I'm having a problem with this.",
    //  "user": {
    //    "login": "octocat",
    //    "id": 1,
    //    "avatar_url": "https://github.com/images/error/octocat_happy.gif",
    //    "gravatar_id": "somehexcode",
    //    "url": "https://api.github.com/users/octocat"
    //  },
    //  "labels": [
    //    {
    //      "url": "https://api.github.com/repos/octocat/Hello-World/labels/bug",
    //      "name": "bug",
    //      "color": "f29513"
    //    }
    //  ],
    //  "assignee": {
    //    "login": "octocat",
    //    "id": 1,
    //    "avatar_url": "https://github.com/images/error/octocat_happy.gif",
    //    "gravatar_id": "somehexcode",
    //    "url": "https://api.github.com/users/octocat"
    //  },
    //  "milestone": {
    //    "url": "https://api.github.com/repos/octocat/Hello-World/milestones/1",
    //    "number": 1,
    //    "state": "open",
    //    "title": "v1.0",
    //    "description": "",
    //    "creator": {
    //      "login": "octocat",
    //      "id": 1,
    //      "avatar_url": "https://github.com/images/error/octocat_happy.gif",
    //      "gravatar_id": "somehexcode",
    //      "url": "https://api.github.com/users/octocat"
    //    },
    //    "open_issues": 4,
    //    "closed_issues": 8,
    //    "created_at": "2011-04-10T20:09:31Z",
    //    "due_on": null
    //  },
    //  "comments": 0,
    //  "pull_request": {
    //    "html_url": "https://github.com/octocat/Hello-World/issues/1",
    //    "diff_url": "https://github.com/octocat/Hello-World/issues/1.diff",
    //    "patch_url": "https://github.com/octocat/Hello-World/issues/1.patch"
    //  },
    //  "closed_at": null,
    //  "created_at": "2011-04-22T13:33:48Z",
    //  "updated_at": "2011-04-22T13:33:48Z"
    //}

    #endregion

    [DataContract]
    public class Issue
    {
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string html_url { get; set; }
        [DataMember]
        public int number { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string body { get; set; }
        [DataMember]
        public User user { get; set; }
        [DataMember]
        public Label[] labels { get; set; }
        [DataMember]
        public User assignee { get; set; }
        [DataMember]
        public Milestone milestone { get; set; }
        [DataMember]
        public int comments { get; set; }
        [DataMember]
        public Request pull_request { get; set; }

        public string closed_at { get; set; }
        [DataMember]
        public DateTime? Closed_At
        {
            get
            {
                if( closed_at == null)
                {
                    return null;
                }
                else
                {
                   return DateTime.Parse(closed_at); 
                } 
            }
            set { closed_at = value.ToString(); }
        }
        [DataMember]
        public string created_at { get; set; }
        [DataMember]
        public string updated_at { get; set; }
    }
}
