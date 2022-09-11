using MyHttpServer.HTTP;

namespace MyHttpServer.Responses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse()
            :base(StatusCode.BadRequest)
        {

        }
    }
}
