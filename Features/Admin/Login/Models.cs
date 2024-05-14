using FluentValidation;

namespace Admin.Login
{
    internal sealed class Request
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UserName).Equal("Admin").WithMessage("Username incorrect");
            RuleFor(x => x.Password).Equal("Admin").WithMessage("Password incorrect");
        }
    }

    internal sealed class Response
    {
        public string Message => "You are login as admin.";
    }
}
