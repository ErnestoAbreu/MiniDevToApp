using FluentValidation;

namespace Public.AddComment
{
    internal sealed class Request
    {
        public int ArticleId { get; set; }
        public string Message { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message is required");
        }
    }

    internal sealed class Response
    {
        public string Message => "Comment added!";
    }
}
