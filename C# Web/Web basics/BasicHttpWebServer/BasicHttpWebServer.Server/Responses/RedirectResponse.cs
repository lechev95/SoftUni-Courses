using BasicHttpWebServer.Server.HTTP;

namespace BasicHttpWebServer.Server.Responses
{
    public class RedirectResponse : Response
    {
        public RedirectResponse(string location)
            :base(StatusCode.Found)
        {
            Headers.Add(Header.Location, location);
        }
    }
}
