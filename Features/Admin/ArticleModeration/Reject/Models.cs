﻿namespace Admin.Reject
{
    internal sealed class Request
    {
        public int ArticleId { get; set; }
    }
    internal sealed class Response
    {
        public string Message => "Reject!";
    }
}