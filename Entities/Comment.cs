using Microsoft.Identity.Client;

namespace MiniDevToApp.Entities
{
    internal class Comment
    {
        public int Id { get; set; }
        public string? Message { get; set; }
    }
}