using Microsoft.Identity.Client;

namespace MiniDevToApp.DataBases.Models
{
    internal class Article
    {
        public int Id { get; set; }
        public string? AuthorId { get; set; }

        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public ArticleStatus Status { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }

}
