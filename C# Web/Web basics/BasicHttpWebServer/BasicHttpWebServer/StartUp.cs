﻿using BasicHttpWebServer.Server;
using BasicHttpWebServer.Server.HTTP;
using BasicHttpWebServer.Server.Responses;

namespace BasicHttpWebServer.Demo
{
    public class StartUp
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
            Name: <input type='text' name='Name'/>
            Age: <input type='number' name ='Age'/>
            <input type='submit' value ='Save' />
        </form>";

        public static void Main()
            => new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from the server!"))
            .MapGet("/HTML", new HtmlResponse(HtmlForm))
            .MapPost("/HTML", new TextResponse("", AddFormDataAction))
            .MapGet("/Redirect", new RedirectResponse("https://softuni.org")))
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