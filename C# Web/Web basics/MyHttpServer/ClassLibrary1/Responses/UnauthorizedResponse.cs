using MyHttpServer.HTTP;

namespace MyHttpServer.Responses
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse()
            :base(StatusCode.Unauthorized)
        {

        }
    }
}
