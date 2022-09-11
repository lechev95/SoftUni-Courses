using MyHttpServer.HTTP;

namespace MyHttpServer.Responses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse()
            :base(StatusCode.NotFound)
        {

        }
    }
}
