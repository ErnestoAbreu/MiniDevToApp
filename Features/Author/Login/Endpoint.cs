using Microsoft.AspNetCore.Identity;

namespace Author.Login
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public SignInManager<IdentityUser> SignInManager { get; set; }
        public UserManager<IdentityUser> UserManager { get; set; }
        public override void Configure()
        {
            Post("/author/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var user = UserManager.Users.FirstOrDefault(x => x.Email == req.Email);

            if (user == null)
            {
                ThrowError("Email incorrect.");
            }

            var result = await SignInManager.PasswordSignInAsync(user, req.Password, true, false);

            if (!result.Succeeded)
            {
                AddError("Password or email incorrect");
                ThrowIfAnyErrors();
            }

            var response = new Response()
            {
                Message = "You are sign in."
            };

            await SendAsync(response);
        }
    }
}
