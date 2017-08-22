namespace GithubServices
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Newtonsoft.Json;
    using RestSharp;
    #endregion

    public class GithubCardsProvider : BaseGithubProvider, ICardsProvider
    {
        #region ICardsProvider implementation
        public async Task<IEnumerable<Card>> Get(string columnId)
        {
            RestRequest request = new RestRequest(Constants.CardsFromColumnUrl, Method.GET);
            request.AddUrlSegment(Constants.ColumnIdSegmentName, columnId);
            this.AddNeededHeader(ref request);
            var response = await this.ProcessRequest(request);

            return response.StatusCode==HttpStatusCode.OK ?  JsonConvert.DeserializeObject<IEnumerable<Card>>(response.Content) : null;
                
        }
        
        public async Task<IEnumerable<Card>> Get(string columnId, string pattern)
        {
            var cards = await this.Get(columnId);
            return cards?.Where(c => c.note.Contains(pattern)).ToList();
        }

        public async Task<bool> Move(string id, string columnId)
        {
            RestRequest request = new RestRequest(Constants.MoveCardUrl, Method.POST);
            request.AddUrlSegment(Constants.IdSegmentName, id);
            request.RequestFormat = DataFormat.Json;
            int numberColumnId;
            try
            {
                numberColumnId = int.Parse(columnId);
            }
            catch
            {
                return false;
            }

            request.AddBody(new { position = Constants.BacklogPosition, column_id = numberColumnId });
            this.AddNeededHeader(ref request);

            var response = await this.ProcessRequest(request);
            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<Card> Edit(string id, string note)
        {
            RestRequest request = new RestRequest(Constants.EditCardUrl, Method.PATCH);
            request.AddUrlSegment(Constants.IdSegmentName, id);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { note=note });
            this.AddNeededHeader(ref request);
            
            var response = await this.ProcessRequest(request);
            return response.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<Card>(response.Content) : null;
        }

        public async Task<bool> Delete(string id)
        {
            RestRequest request = new RestRequest(Constants.DeleteCardUrl, Method.DELETE);
            request.AddUrlSegment(Constants.IdSegmentName, id);
            this.AddNeededHeader(ref request);

            var response = await this.ProcessRequest(request);
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<Card> Create(string columnId, string note)
        {
            RestRequest request = new RestRequest(Constants.CreateCardUrl, Method.POST);
            request.AddUrlSegment(Constants.ColumnIdSegmentName, columnId);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { note = note });
            this.AddNeededHeader(ref request);

            var response = await this.ProcessRequest(request);
            return response.StatusCode==HttpStatusCode.Created ? JsonConvert.DeserializeObject<Card>(response.Content):null;
        }
        #endregion
    }
}
