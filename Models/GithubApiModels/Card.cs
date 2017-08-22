namespace Models.GithubApiModels
{
    public class Card
    {
        public string url { get; set; }
        public string column_url { get; set; }
        public string content_url { get; set; }
        public int id { get; set; }
        public string note { get; set; }
        public Creator creator { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}