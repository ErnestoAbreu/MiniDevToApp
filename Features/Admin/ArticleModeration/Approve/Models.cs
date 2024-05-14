namespace Admin.Approve
{
    internal sealed class Request
    {
        public int ArticleId { get; set; }
    }
    internal sealed class Response
    {
        public string Message => "Approved!";
    }
}
