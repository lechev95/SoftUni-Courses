﻿using MyHttpServer.HTTP;
using MyHttpServer.Responses;

namespace MyHttpServer.Server.Controllers
{
    public class Controller
    {
        protected Request Request { get; private init; }
        public Controller(Request request)
        {
            Request = request;
        }

        protected Response Text(string text) => new TextResponse(text);
        protected Response Html(string text) => new HtmlResponse(text);
        protected Response BadRequest() => new BadRequestResponse();
        protected Response Unauthorized() => new UnauthorizedResponse();
        protected Response NotFound() => new NotFoundResponse();
        protected Response Redirect(string location) => new RedirectResponse(location);
        protected Response File(string fileName) => new FileResponse(fileName);

    }
}
