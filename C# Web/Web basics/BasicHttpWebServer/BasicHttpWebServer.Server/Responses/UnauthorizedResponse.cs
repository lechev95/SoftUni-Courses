using BasicHttpWebServer.Server.HTTP;

namespace BasicHttpWebServer.Server.Responses
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse()
            :base(StatusCode.Unauthorized)
        {

        }
    }
}
