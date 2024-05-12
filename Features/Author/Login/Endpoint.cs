namespace Author.Login
{
    internal sealed class Endpoint : Endpoint<Request, EmptyResponse, Mapper>
    {
        public override void Configure()
        {
            Post("/author/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await Task.CompletedTask;
        }
    }
}
