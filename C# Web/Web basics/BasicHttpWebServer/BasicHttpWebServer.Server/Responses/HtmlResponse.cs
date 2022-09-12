using BasicHttpWebServer.Server.HTTP;

namespace BasicHttpWebServer.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text)
            :base(text, ContentType.Html)
        {

        }
    }
}
