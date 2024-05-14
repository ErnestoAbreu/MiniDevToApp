using MiniDevToApp.Entities;

namespace Public.GetArticle
{
    internal sealed class Request
    {
        public int ArticleId { get; set; }
    }
    internal sealed class Response
    {
        public Article Article { get; set; }
    }
}
