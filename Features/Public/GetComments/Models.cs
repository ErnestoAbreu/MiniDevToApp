using MiniDevToApp.Entities;

namespace Public.GetComments
{
    internal sealed class Request
    {
        public int ArticleId { get; set; }
    }
    internal sealed class Response
    {
        public List<Comment> Comments { get; set; }
    }
}
