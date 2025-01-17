﻿using FluentValidation;

namespace Author.Signup
{
    internal sealed class Request
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("email address is required!")
                .EmailAddress().WithMessage("the format of your email address is wrong!");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("a username is required!")
                .MinimumLength(3).WithMessage("username is too short!")
                .MaximumLength(15).WithMessage("username is too long!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("a password is required!")
                .MinimumLength(4).WithMessage("password is too short!")
                .MaximumLength(25).WithMessage("password is too long!");
        }
    }
    internal sealed class Response
    {
        public string Message { get; set; } = string.Empty;
    }
}
