using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Author.Signup
{
    internal sealed class Endpoint : Endpoint<Request, Response>
    {
        public UserManager<IdentityUser> UserManager { get; set; } = default!;

        public override void Configure()
        {
            Post("/author/signup");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var user = new IdentityUser()
            {
                UserName = r.UserName,
                Email = r.Email,
            };

            var result = await UserManager.CreateAsync(user, r.Password);
            
            if (!result.Succeeded)
            {
                foreach(var err in result.Errors)
                    AddError(err.Description, err.Code);                        
            }

            ThrowIfAnyErrors();

            result = await UserManager.AddToRoleAsync(user, "Author");

            if (!result.Succeeded)
            {
                foreach(var err in result.Errors)
                    AddError(err.Description, err.Code);
            }

            ThrowIfAnyErrors();

            await SendAsync(new Response()
            {
                Message = $"hello {r.UserName}, thank you for signing up as an author!"
            });
        }
    }
}