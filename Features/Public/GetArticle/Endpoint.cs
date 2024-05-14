using MiniDevToApp.DataBases;
using MiniDevToApp.Entities;

namespace Public.GetArticle
{
    internal sealed class Endpoint : Endpoint<Request, Response>
    {
        public ArticleDbContext Context { get; set; }
        public override void Configure()
        {
            Get("get-article/{ArticleId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var article = Context.Articles.FirstOrDefault(x => x.Id == r.ArticleId);

            if (article == null || article.Status != ArticleStatus.Approved)
            {
                ThrowError("Not found", StatusCodes.Status404NotFound);
            }

            await SendAsync(new Response()
            {
                Article = article
            }, cancellation: c);
        }
    }
}