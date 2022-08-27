﻿using MyHttpServer.HTTP;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyHttpServer
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string _ipAddress, int _port)
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;

            serverListener = new TcpListener(ipAddress, port);
        }

        public void Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server is listening on port {port}");
            Console.WriteLine("Listening for request");

            while (true)
            {

                var connection = serverListener.AcceptTcpClient();
                var networkStream = connection.GetStream();
                string strRequest = ReadRequest(networkStream);
                Request request = Request.Parse(strRequest);
                Console.WriteLine(strRequest);

                WriteResponse(networkStream, "Hello World");
                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, string content)
        {
            int contentLength = Encoding.UTF8.GetByteCount(content);
            string response = $@"HTTP/1.1 200 OK
                    Content-Type: text/plain; charset = UTF-8
                    Content-Length: {contentLength}
    
                    {content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);
            networkStream.Write(responseBytes, 0, responseBytes.Length);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            byte[] buffer = new byte[1024];
            StringBuilder request = new StringBuilder();
            int totalBytes = 0;

            do
            {
                int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                totalBytes += bytesRead;

                if(totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large");
                }

                request.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (networkStream.DataAvailable);

            return request.ToString();
        }
    }
}
