using Microsoft.AspNetCore.Identity;
using MiniDevToApp.DataBases;

namespace Author.Article.Create;

internal sealed class Endpoint : Endpoint<Request, Response>
{
    public SignInManager<IdentityUser> SignInManager { get; set; }
    public ArticleDbContext Context { get; set; }
    public override void Configure()
    {
        Post("author/article");
        Roles("Author", "Admin");
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var userId = SignInManager.UserManager.GetUserId(HttpContext.User);

        var article = new MiniDevToApp.Entities.Article()
        {
            AuthorId = userId,
            AuthorName = r.AuthorName,
            Title = r.Title,
            Content = r.Content
        };

        var newArticle  = Context.Articles.Add(article);
        await Context.SaveChangesAsync();
        
        await SendAsync(new Response() { Article = newArticle.Entity }, StatusCodes.Status201Created);
    }
}