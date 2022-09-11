using MyHttpServer.HTTP;

namespace MyHttpServer.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(Method method, string path, Func<Request, Response>  responseFunction);
    }
}
