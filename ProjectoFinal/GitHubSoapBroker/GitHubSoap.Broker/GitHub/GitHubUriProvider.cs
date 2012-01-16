using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitHubSoap.Broker.GitHub
{
    static class GitHubUriProvider
    {
        public static string ListYourRepositories { get { return "https://api.github.com/user/repos"; } }
        public static string CreateRepository { get { return "https://api.github.com/user/repos"; } }
        public static string GetRepository { get { return "https://api.github.com/repos/{0}/{1}"; } }
        public static string EditRepository { get { return "https://api.github.com/repos/{0}/{1}"; } }
        public static string ListRepositoryContributors { get { return "https://api.github.com/repos/{0}/{1}/contributors"; } }
        public static string ListRepositoryLanguages { get { return "https://api.github.com/repos/{0}/{1}/languages"; } }
        public static string ListIssuesForRepository { get { return "https://api.github.com/repos/{0}/{1}/issues"; } }
        
        public static string CreateIssue { get { return "https://api.github.com/repos/{0}/{1}/issues"; } }
        public static string EditIssue { get { return "https://api.github.com/repos/{0}/{1}/issues/{2}"; } }
        public static string GetSingleIssue { get { return "https://api.github.com/repos/{0}/{1}/issues/{2}"; } }
        public static string ListYourIssues { get { return "https://api.github.com/issues"; } }
        
    }
}
