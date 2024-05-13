namespace Author.Article.Delete
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
        public string Message => "Deleted";
    }
}
