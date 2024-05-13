using MiniDevToApp.Entities;

namespace Author.Article.Get
{
    internal sealed class Request
    {
        public int ArticleId { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }

    internal sealed class Response
    {
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public string? Content { get; set; }
        public ArticleStatus Status { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
