﻿namespace MyHttpServer.HTTP
{
    public class Response
    {
        public StatusCode StatusCode { get; init; }
        public HeaderCollection Headers { get; } = new HeaderCollection();
        public string Body { get; set; }

        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;
            Headers.Add("Server", "My Server");
            Headers.Add("Date", $"{DateTime.UtcNow:r}");
        }
    }
}
