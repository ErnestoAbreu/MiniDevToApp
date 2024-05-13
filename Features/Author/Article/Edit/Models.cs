using FluentValidation;

namespace Author.Article.Edit
{
    internal sealed class Request
    {
        public int ArticleId { get; set; }

        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public string? Content { get; set; }
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
        public string Message => "Edited";
        public MiniDevToApp.Entities.Article Article { get; set; }
    }
}
