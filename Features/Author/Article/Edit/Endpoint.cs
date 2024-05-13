using Microsoft.AspNetCore.Identity;
using MiniDevToApp.DataBases;

namespace Author.Article.Edit
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public SignInManager<IdentityUser> SignInManager { get; set; }
        public ArticleDbContext Context { get; set; }
        public override void Configure()
        {
            Put("author/article/{ArticleId}");
            Roles("Author", "Admin");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var user = await SignInManager.UserManager.GetUserAsync(HttpContext.User);

            var article = Context.Articles.FirstOrDefault(x => x.Id == r.ArticleId);

            if (article == null)
            {
                ThrowError("Article not found", StatusCodes.Status404NotFound);
            }

            var roles = await SignInManager.UserManager.GetRolesAsync(user);
            if (!roles.Contains("Admin"))
            {
                if (user.Id != article.AuthorId)
                {
                    ThrowError("Unauthorized", StatusCodes.Status401Unauthorized);
                }
            }

            article.Title = r.Title;
            article.Content = r.Content;
            article.AuthorName = r.AuthorName;

            await Context.SaveChangesAsync(c);

            await SendAsync(new Response()
            {
                Article = article
            }, cancellation: c);
        }
    }
}