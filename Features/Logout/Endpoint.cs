using Microsoft.AspNetCore.Identity;

namespace Logout
{
    internal sealed class Endpoint : EndpointWithoutRequest<Response>
    {
        public SignInManager<IdentityUser> SignInManager { get; set; }
        public override void Configure()
        {
            Post("logout");
        }

        public override async Task HandleAsync( CancellationToken c)
        {
            await SignInManager.SignOutAsync();

            await SendAsync(new Response(), cancellation: c);
        }
    }
}