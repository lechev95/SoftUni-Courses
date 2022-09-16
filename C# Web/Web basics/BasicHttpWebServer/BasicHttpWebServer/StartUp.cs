using BasicHttpWebServer.Demo.Controllers;
using BasicHttpWebServer.Server;
using BasicHttpWebServer.Server.HTTP;
using BasicHttpWebServer.Server.Routing;
using System.Text;
using System.Web;

namespace BasicHttpWebServer.Demo
{
    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
            .MapGet<HomeController>("/", c => c.Index())
            .MapGet<HomeController>("/HTML", c => c.Html())
            .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
            .MapGet<HomeController>("/Redirect", c => c.Redirect())
            .MapGet<HomeController>("/Content", c => c.Content())
            .MapPost<HomeController>("/Content", c => c.DownloadContent())
            .MapGet<HomeController>("/Cookies", c => c.Cookies())
            .MapGet<HomeController>("/Session", c => c.Session())
            .MapGet<UserController>("/Login", c => c.Login())
            .MapPost<UserController>("/Login", c => c.LogInUser())
            .MapGet<UserController>("/Logout", c => c.Logout())
            .MapGet<UserController>("/UserProfile", c => c.GetUserData()))
            .Start();

        private static void AddFormDataAction(
            Request request, Response response)
        {
            response.Body = "";

            foreach (var (key, value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }
    }
}