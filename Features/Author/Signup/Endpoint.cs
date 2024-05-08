namespace Author.Signup
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Post("/author/signup");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            await SendAsync(new Response()
            {
                Message = $"hello {r.FirstName} {r.LastName}! your request has been received!"
            });
        }
    }
}