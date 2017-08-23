namespace Models
{
    public static class Constants
    {
        #region Urls
        public const string GithubApiUrl = "https://api.github.com";

        public const string CardsFromColumnUrl = "/projects/columns/{column}/cards";
        public const string MoveCardUrl = "/projects/columns/cards/{id}/moves";
        public const string EditCardUrl = "/projects/columns/cards/{id}";
        public const string DeleteCardUrl = "/projects/columns/cards/{id}";
        public const string CreateCardUrl = "/projects/columns/{column}/cards";

        public const string GetProjectsUrl = "/repos/{owner}/{repo}/projects";
        public const string CreateProjectUrl = "/repos/{owner}/{repo}/projects";

        public const string GetColumnsUrl = "/projects/{project_id}/columns";
        public const string CreateColumnUrl = "/projects/{project_id}/columns";
        #endregion

        #region GithubRestApiConstants

        public const string Owner = "exampleuser1234";
        public const string Repo = "test";

        public const string AcceptHeaderName = "Accept";
        public const string AuthorizationHeaderName = "Authorization";
        public const string UserAgentHeaderName = "User-Agent";

        public const string Accept = "application/vnd.github.inertia-preview+json";
        public const string UserAgentName = "DeluxeRestApp";
        public const string TokenFormat = "token {0}";
        
        public const string ProjectName = "Test";
        public const string ColumnIdSegmentName = "column";
        public const string IdSegmentName = "id";
        public const string ProjectIdSegmentName = "project_id";
        public const string RepoSegmentName = "repo";
        public const string OwnerSegmentName = "owner";
        public const string BacklogName = "Backlog";
        public const string BacklogPosition = "bottom";
        #endregion

        #region MongoDb

        public const string MongoClientAddress = "mongodb://0.0.0.0:27017";
        public const string DatabaseName = "logsDB";
        public const string CollectionName = "logs";

        #endregion
    }
}
