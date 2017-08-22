namespace GithubServices
{
    #region Usings
    using System.Threading.Tasks;
    using Models;
    using RestSharp;
    #endregion

    public class BaseGithubProvider
    {
        #region Protected methods
        protected void AddNeededHeader(ref RestRequest request)
        {
            request.AddHeader(Constants.AcceptHeaderName, Constants.Accept);
            request.AddHeader(Constants.AuthorizationHeaderName, string.Format("token {0}", Environment.AuthToken));
            request.AddHeader(Constants.UserAgentHeaderName, Constants.UserAgentName);
        }

        protected async Task<RestResponse> ProcessRequest(RestRequest request)
        {
            RestClient restClient = new RestClient(Constants.GithubApiUrl);
            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
            restClient.ExecuteAsync(request, r => taskCompletion.SetResult(r));
            return (RestResponse)(await taskCompletion.Task);
        }
        #endregion

    }
}
