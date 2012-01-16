using System.Collections.Generic;
using System.ServiceModel;
using GitHubSoap.Domain.DataContracts;
using GitHubSoap.Domain.DataContracts.Issues;
using GitHubSoap.Domain.DataContracts.Repos;
using GitHubSoap.Domain.FaultContracts;

namespace GitHubSoap.Domain.ServiceContracts
{
    [ServiceContract]
    public interface IGitHubService
    {
        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        IEnumerable<Issue> ListIssuesForRepository(string user, string repo);

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        Issue GetSingleIssue(string user, string repo, int id);

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        Issue CreateIssue(IssueRequest issueRequest, string user, string repo);

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        Issue EditIssue(IssueRequest editIssue, string user, string repo, int id);

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        IEnumerable<Issue> ListYourIssues();

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        IEnumerable<Repository> ListYourRepositories();

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        Repository CreateRepository(RepositoryRequest repositoryRequest);

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        RepositoryDetail GetRepository(string user, string repo);

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        RepositoryDetail EditRepository(RepositoryRequest editRepository, string user, string repo);

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        IEnumerable<User> ListRepositoryContributors(string user, string repo);

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        string ListRepositoryLanguages(string user, string repo);

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        IEnumerable<Repository> CreateRepositoriesBatch(IEnumerable<RepositoryRequest> repositoriesRequests);

        [OperationContract]
        [FaultContract(typeof(InvalidRequestFault))]
        [FaultContract(typeof(MaxNumberOfRequestsExcededFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        IEnumerable<RepositoryDetail> GetRepositoriesBatch(IEnumerable<KeyValuePair<string, string>> usersAndRepos);
    }
}
