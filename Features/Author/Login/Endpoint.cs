using Microsoft.AspNetCore.Identity.Data;

namespace Author.Login
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Post("/api/author/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            if (await authService.CredentialsAreValid(req.Username, req.Password, ct))
            {
                var jwtToken = JwtBearer.CreateToken(
                    o =>
                    {
                        o.SigningKey = "A secret token signing key";
                        o.ExpireAt = DateTime.UtcNow.AddDays(1);
                        o.User.Roles.Add("Manager", "Auditor");
                        o.User.Claims.Add(("UserName", req.Username));
                        o.User[ "UserId" ] = "001"; //indexer based claim setting
                    });

                await SendAsync(
                    new
                    {
                        req.Username,
                        Token = jwtToken
                    });
            }
            else
                ThrowError("The supplied credentials are invalid!");
        }
    }
}
}