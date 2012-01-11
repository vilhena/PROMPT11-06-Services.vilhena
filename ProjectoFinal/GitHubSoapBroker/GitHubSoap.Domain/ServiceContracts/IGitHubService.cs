using System.Collections.Generic;
using System.ServiceModel;
using GitHubSoap.Domain.DataContracts;
using GitHubSoap.Domain.DataContracts.Issues;
using GitHubSoap.Domain.DataContracts.Repos;

namespace GitHubSoap.Domain.ServiceContracts
{
    [ServiceContract]
    public interface IGitHubService
    {
        [OperationContract]
        IEnumerable<Issue> ListIssuesForRepository(string user, string repo);

        [OperationContract]
        Issue GetSingleIssue(string user, string repo, int id);

        [OperationContract]
        Issue CreateIssue(IssueRequest issueRequest, string user, string repo);

        [OperationContract]
        Issue EditIssue(IssueRequest editIssue, string user, string repo, int id);

        [OperationContract]
        IEnumerable<Issue> ListYourIssues();

        [OperationContract]
        IEnumerable<Repository> ListYourRepositories();

        [OperationContract]
        Repository CreateRepository(RepositoryRequest repositoryRequest);
    }
}
