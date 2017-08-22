namespace Models
{
    public static class Constants
    {
        public const string Accept = "application/vnd.github.inertia-preview+json";
        public const string CardsFromColumnUrl = "/projects/columns/{column}/cards";
        public const string MoveCardUrl = "/projects/columns/cards/{id}/moves";
        public const string EditCardUrl = "/projects/columns/cards/{id}";
        public const string DeleteCardUrl = "/projects/columns/cards/{id}";
        public const string CreateCardUrl = "/projects/columns/{column}/cards";


        public const string GetProjectsUrl = "/repos/{owner}/{repo}/projects";
        public const string CreateProjectUrl = "/repos/{owner}/{repo}/projects";
        public const string Owner = "exampleuser1234";
        public const string Repo = "test";

        public const string ProjectName = "Test";

        public const string GetColumnsUrl = "/projects/{project_id}/columns";
        public const string CreateColumnUrl = "/projects/{project_id}/columns";


        public const string ColumnIdSegmentName = "column";
        public const string IdSegmentName = "id";
        public const string ProjectIdSegmentName = "project_id";
        public const string RepoSegmentName = "repo";
        public const string OwnerSegmentName = "owner";
        public const string BacklogName = "Backlog";

        public const string UserAgentName = "DeluxeRestApp";


        public const string AcceptHeaderName = "Accept";
        public const string AuthorizationHeaderName = "Authorization";
        public const string UserAgentHeaderName = "User-Agent";


        public const string BacklogPosition = "bottom";

        public const string GithubApiUrl = "https://api.github.com";
    }
}
