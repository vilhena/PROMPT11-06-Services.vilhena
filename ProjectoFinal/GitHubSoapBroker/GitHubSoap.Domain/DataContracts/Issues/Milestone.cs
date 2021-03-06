﻿using System.Runtime.Serialization;

namespace GitHubSoap.Domain.DataContracts.Issues
{
    [DataContract]
    public class Milestone
    {
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public int number { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public User creator { get; set; }
        [DataMember]
        public int open_issues { get; set; }
        [DataMember]
        public int closed_issues { get; set; }
        [DataMember]
        public string created_at { get; set; }
        [DataMember]
        public string due_on { get; set; }
    }
}
