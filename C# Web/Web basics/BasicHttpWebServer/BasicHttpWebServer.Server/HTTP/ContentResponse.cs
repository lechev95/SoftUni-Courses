﻿using BasicHttpWebServer.Server.Common;
using System.Text;

namespace BasicHttpWebServer.Server.HTTP
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType)
            //,Action<Request, Response> preRenderAction = null) 
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(content);
            Guard.AgainstNull(contentType);

            //PreRenderAction = preRenderAction; 
            Headers.Add(Header.ContentType, contentType);
            Body = content;
        }

        public override string ToString()
        {
            if(Body != null)
            {
                var contentLength = Encoding.UTF8.GetByteCount(Body).ToString();
                Headers.Add(Header.ContentLength, contentLength);
            }

            return base.ToString();
        }
    }
}
