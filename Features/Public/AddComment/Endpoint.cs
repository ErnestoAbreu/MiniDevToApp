using MiniDevToApp.DataBases;
using MiniDevToApp.Entities;

namespace Public.AddComment
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public ArticleDbContext Context { get; set; }
        public override void Configure()
        {
            Post("add-comment/{ArticleId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var article = Context.Articles.FirstOrDefault(x => x.Id == r.ArticleId);

            if (article is not { Status: ArticleStatus.Approved })
            {
                ThrowError("not found", StatusCodes.Status404NotFound);
            }

            var comment = new Comment() { Message = r.Message };

            article.Comments.Add(comment);
            await Context.SaveChangesAsync(c);

            await SendAsync(new Response(), cancellation: c);
        }
    }
}