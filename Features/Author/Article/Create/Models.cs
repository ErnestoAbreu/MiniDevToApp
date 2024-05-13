using FluentValidation;

namespace Author.Article.Create;

internal sealed class Request
{
    public string AuthorName { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}

internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Content).NotEmpty().WithMessage("Title is required");
    }
}

internal sealed class Response
{
    public string Message => "Article created correctly";
    public MiniDevToApp.Entities.Article? Article { get; set; }

}
