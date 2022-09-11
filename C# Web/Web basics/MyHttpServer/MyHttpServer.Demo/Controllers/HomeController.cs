using MyHttpServer.HTTP;
using MyHttpServer.Server.Controllers;

namespace MyHttpServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(Request request)
            :base(request)
        {

        }

        public Response Index() => Text("Hello from the server!");
    }
}
