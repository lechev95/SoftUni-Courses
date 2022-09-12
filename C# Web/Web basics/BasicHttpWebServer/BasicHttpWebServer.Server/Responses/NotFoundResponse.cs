using BasicHttpWebServer.Server.HTTP;

namespace BasicHttpWebServer.Server.Responses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse()
            :base(StatusCode.NotFound)
        {

        }
    }
}
