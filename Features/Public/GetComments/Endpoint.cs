using Microsoft.EntityFrameworkCore;
using MiniDevToApp.DataBases;
using MiniDevToApp.Entities;

namespace Public.GetComments
{
    internal sealed class Endpoint : Endpoint<Request, Response>
    {
        public ArticleDbContext Context { get; set; }
        public override void Configure()
        {
            Get("get-comments/{ArticleId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var article = Context.Articles.Include(article => article.Comments).FirstOrDefault(x => x.Id == r.ArticleId);

            if (article is not { Status: ArticleStatus.Approved })
            {
                ThrowError("Not found", StatusCodes.Status404NotFound);
            }

            var comments = article.Comments;

            await SendAsync(new Response()
            {
                Comments = comments
            }, cancellation: c);
        }
    }
}