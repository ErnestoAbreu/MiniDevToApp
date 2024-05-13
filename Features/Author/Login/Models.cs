namespace Author.Login
{
    internal sealed class Request
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            
        }
    }

    internal sealed class Response
    {
        public string Message { get; set; }

    }
}
