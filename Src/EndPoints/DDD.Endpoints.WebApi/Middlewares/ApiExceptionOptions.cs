using Microsoft.AspNetCore.Http;

namespace DDD.Endpoints.WebApi.Middlewares;

public class ApiExceptionOptions
{
    public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; }
    public Func<Exception, LogLevel> DetermineLogLevel { get; set; }
}