using System.Net;

namespace GithubServices
{
    #region Usings
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Newtonsoft.Json;
    using RestSharp;
    #endregion

    public class GithubColumnsProvider : BaseGithubProvider, IColumnsProvider
    {
        #region Implementation of IColumnsProvider
        public async Task<IEnumerable<Column>> Get(string projectId)
        {
            RestRequest request = new RestRequest(Constants.GetColumnsUrl, Method.GET);
            request.AddUrlSegment(Constants.ProjectIdSegmentName, projectId);
            this.AddNeededHeader(ref request);
            var response = await this.ProcessRequest(request);

            return response.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<IEnumerable<Column>>(response.Content): null;
        }

        public async Task<Column> Create(string projectId, string columnName)
        {
            RestRequest request = new RestRequest(Constants.CreateColumnUrl, Method.POST);
            request.AddUrlSegment(Constants.ProjectIdSegmentName, projectId);
            this.AddNeededHeader(ref request);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name = columnName });
            var response = await this.ProcessRequest(request);

            return response.StatusCode == HttpStatusCode.Created ? JsonConvert.DeserializeObject<Column>(response.Content) : null;
        }

        #endregion
    }
}
