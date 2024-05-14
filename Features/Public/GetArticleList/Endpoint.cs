using MiniDevToApp.DataBases;
using MiniDevToApp.Entities;

namespace Public.GetArticleList
{
    internal sealed class Endpoint : EndpointWithoutRequest<Response>
    {
        public ArticleDbContext Context { get; set; }
        public override void Configure()
        {
            Get("get-articles");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken c)
        {
            var approveArticles = Context.Articles.Where(x => x.Status == ArticleStatus.Approved).ToList();

            SendAsync(new Response()
            {
                Articles = approveArticles
            }, cancellation: c);
        }
    }
}