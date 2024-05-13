using Microsoft.AspNetCore.Identity;
using MiniDevToApp.DataBases;

namespace Author.Article.Get
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public SignInManager<IdentityUser> SignInManager { get; set; }
        public ArticleDbContext Context { get; set; }
        public override void Configure()
        {
            Get("author/article/{ArticleId}");
            Roles("Author", "Admin");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var user = await SignInManager.UserManager.GetUserAsync(HttpContext.User);

            var roles = await SignInManager.UserManager.GetRolesAsync(user);

            var article = Context.Articles.FirstOrDefault(x => x.Id == r.ArticleId);
            if (article == null)
            {
                ThrowError("This ArticleId no exists", StatusCodes.Status404NotFound);
            }

            if (roles.Contains("Author"))
            {
                if (user.Id != article!.AuthorId)
                {
                    ThrowError("Unauthorized", StatusCodes.Status401Unauthorized);
                }
            }

            await SendAsync(new Response()
            {
                AuthorName = article.AuthorName,
                Comments = article.Comments,
                Content = article.Content,
                Title = article.Title,
                Status = article.Status
            });
        }
    }
}