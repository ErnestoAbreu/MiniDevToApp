using Microsoft.Identity.Client;

namespace MiniDevToApp.Entities
{
    internal class Article
    {
        public int Id { get; set; }
        public string? AuthorId { get; set; }

        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public string? Content { get; set; }
        public ArticleStatus Status { get; set; } = ArticleStatus.Pending;

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }

}
