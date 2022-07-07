using Microsoft.AspNetCore.Http;
using Ocelot.Infrastructure.Extensions;
using Ocelot.Logging;
using Ocelot.Middleware;
using Ocelot.Responder;
using System.Linq;
using System.Threading.Tasks;

namespace API_Gateway.Middleware
{
    public class MiddlewareClass : Ocelot.Middleware.OcelotMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpResponder _responder;
        private readonly IErrorsToHttpStatusCodeMapper _codeMapper;

        public MiddlewareClass(
            RequestDelegate next,
            IHttpResponder responder,
            IErrorsToHttpStatusCodeMapper codeMapper,
            IOcelotLoggerFactory loggerFactory)
            : base(loggerFactory.CreateLogger<MiddlewareClass>())
        {
            _next = next;
            _responder = responder;
            _codeMapper = codeMapper;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next.Invoke(httpContext);
            if (httpContext.Response.HasStarted)
                return;

            var errors = httpContext.Items.Errors();
            if (errors.Count > 0)
            {
                var x = httpContext.Request;
                Logger.LogWarning($"{errors.ToErrorString()} errors found in {MiddlewareName}. Setting error response for request path:{httpContext.Request.Path}, request method: {httpContext.Request.Method}");

                var statusCode = _codeMapper.Map(errors);
                var error = string.Join(",", errors.Select(x => x.Message));
                httpContext.Response.StatusCode = statusCode;
                // output error
                await httpContext.Response.WriteAsync(error);
            }
            else
            {
                Logger.LogDebug("no pipeline errors, setting and returning completed response");

                var downstreamResponse = httpContext.Items.DownstreamResponse();

                await _responder.SetResponseOnHttpContext(httpContext, downstreamResponse);
            }
        }
    }
}
