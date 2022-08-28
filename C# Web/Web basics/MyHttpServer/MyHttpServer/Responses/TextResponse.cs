﻿using MyHttpServer.HTTP;

namespace MyHttpServer.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
            :base(text, ContentType.PlainText)
        {

        }
    }
}
