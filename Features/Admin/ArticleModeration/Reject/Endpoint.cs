using MiniDevToApp.DataBases;
using MiniDevToApp.Entities;

namespace Admin.Reject
{
    internal sealed class Endpoint : Endpoint<Request, Response>
    {
        public ArticleDbContext Context { get; set; }
        public override void Configure()
        {
            Patch("admin/reject");
            Roles("Admin");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var article = Context.Articles.FirstOrDefault(x => x.Id == r.ArticleId);

            if (article == null)
            {
                ThrowError("ArticleId incorrect", StatusCodes.Status404NotFound);
            }

            article.Status = ArticleStatus.Rejected;
            await Context.SaveChangesAsync(c);

            await SendAsync(new Response(), cancellation: c);
        }
    }
}