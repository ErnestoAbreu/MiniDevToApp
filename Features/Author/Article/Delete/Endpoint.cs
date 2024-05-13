using Microsoft.AspNetCore.Identity;
using MiniDevToApp.DataBases;

namespace Author.Article.Delete
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public SignInManager<IdentityUser> SignInManager { get; set; }
        public ArticleDbContext Context { get; set; }

        public override void Configure()
        {
            Delete("author/article/{ArticleId}");
            Roles("Author", "Admin");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var user = await SignInManager.UserManager.GetUserAsync(HttpContext.User);

            var article = Context.Articles.FirstOrDefault(x => x.Id == r.ArticleId);
            if (article == null)
            {
                ThrowError("This ArticleId no exists", StatusCodes.Status404NotFound);
            }

            var roles = await SignInManager.UserManager.GetRolesAsync(user);

            if (!roles.Contains("Admin"))
            {
                if (user.Id != article.AuthorId)
                {
                    ThrowError("Unauthorized", StatusCodes.Status401Unauthorized);
                }
            }

            Context.Articles.Remove(article);
            await Context.SaveChangesAsync(c);

            await SendAsync(new Response(), cancellation: c);
        }
    }
}