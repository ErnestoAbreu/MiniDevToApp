using Microsoft.EntityFrameworkCore;
using MiniDevToApp.Entities;

namespace MiniDevToApp.DataBases
{
    internal class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions<ArticleDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
