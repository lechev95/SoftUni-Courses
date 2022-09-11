using BasicHttpWebServer.Server;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicHttpWebServer.Demo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var server = new HttpServer("127.0.0.1", 8080);
            server.Start();
        }
    }
}