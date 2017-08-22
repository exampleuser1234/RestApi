using System.Net;

namespace GithubServices
{
    #region Usings
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Models.GithubApiModels;
    using Newtonsoft.Json;
    using RestSharp;
    #endregion

    public class GithubProjectsProvider : BaseGithubProvider, IProjectsProvider
    {
        #region Implementation of IProjectsProvider
        public async Task<IEnumerable<Project>> Get()
        {
            RestRequest request = new RestRequest(Constants.GetProjectsUrl, Method.GET);
            request.AddUrlSegment(Constants.RepoSegmentName, Constants.Repo);
            request.AddUrlSegment(Constants.OwnerSegmentName, Constants.Owner);
            this.AddNeededHeader(ref request);
            var response = await this.ProcessRequest(request);

            return response.StatusCode==HttpStatusCode.OK ? JsonConvert.DeserializeObject<IEnumerable<Project>>(response.Content):null;
        }

        public async Task<Project> Create(string name)
        {
            RestRequest request = new RestRequest(Constants.CreateProjectUrl, Method.POST);
            request.AddUrlSegment(Constants.RepoSegmentName, Constants.Repo);
            request.AddUrlSegment(Constants.OwnerSegmentName, Constants.Owner);
            this.AddNeededHeader(ref request);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name = name });
            var response = await this.ProcessRequest(request);

            return response.StatusCode == HttpStatusCode.Created ? JsonConvert.DeserializeObject<Project>(response.Content) : null;
        }

        #endregion
    }
}
