using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Admin.Login
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public SignInManager<IdentityUser> SignInManager { get; set; }
        public override void Configure()
        {
            Post("admin/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var user = SignInManager.UserManager.Users.First(x => x.UserName == "Admin");
            
            await SignInManager.PasswordSignInAsync(user, r.Password, false, false);

            await SendAsync(new Response(), cancellation: c);
        }
    }
}