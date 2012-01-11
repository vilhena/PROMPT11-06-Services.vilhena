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

        [OperationContract]
        RepositoryDetail GetRepository(string user, string repo);

        [OperationContract]
        RepositoryDetail EditRepository(RepositoryRequest editRepository, string user, string repo);

        [OperationContract]
        IEnumerable<User> ListRepositoryContributors(string user, string repo);

        [OperationContract]
        string ListRepositoryLanguages(string user, string repo);
    }
}
