using Microsoft.Identity.Client;

namespace MiniDevToApp.DataBases.Models
{
    internal class Comment
    {
        public int Id { get; set; }
        public string? Message { get; set; }
    }
}