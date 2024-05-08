using Microsoft.EntityFrameworkCore;
using MiniDevToApp.DataBases.Models;

namespace MiniDevToApp.DataBases
{
    internal class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
