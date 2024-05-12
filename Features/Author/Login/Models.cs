namespace Author.Login
{
    internal sealed class Request
    {
        public string Username { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            
        }
    }

    internal sealed class Response
    {
        public string Message => "This endpoint hasn't been implemented yet!";
    }
}
