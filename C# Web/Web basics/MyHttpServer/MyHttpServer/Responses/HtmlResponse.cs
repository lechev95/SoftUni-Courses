using MyHttpServer.HTTP;

namespace MyHttpServer.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text)
            :base(text, ContentType.Html)
        {

        }
    }
}
