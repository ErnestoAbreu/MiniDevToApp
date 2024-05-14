using MiniDevToApp.DataBases;
using MiniDevToApp.Entities;

namespace Admin.GetPendingList
{
    internal sealed class Endpoint : EndpointWithoutRequest<Response>
    {
        public ArticleDbContext Context { get; set; }
        public override void Configure()
        {
            Get("admin/get-pending-list");
            Roles("Admin");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var pendingArticles = Context.Articles.Where(x => x.Status == ArticleStatus.Pending).ToList();

            await SendAsync(new Response()
            {
                Articles = pendingArticles
            }, cancellation: ct);
        }
    }
}