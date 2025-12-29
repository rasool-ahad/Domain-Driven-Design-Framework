using Extensions.Serializers.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace DDD.Endpoints.WebApi.Middlewares;

public class ApiExceptionMiddleware(ApiExceptionOptions options, RequestDelegate next,
    ILogger<ApiExceptionMiddleware> logger, IJsonSerializer serializer
        )
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ApiExceptionMiddleware> _logger = logger;
    private readonly ApiExceptionOptions _options = options;
    private readonly IJsonSerializer _serializer = serializer;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var error = new ApiError
        {
            Id = Guid.NewGuid().ToString(),
            Status = (short)HttpStatusCode.InternalServerError,
            Title = "SOME_KIND_OF_ERROR_OCCURRED_IN_THE_API"
        };

        _options.AddResponseDetails?.Invoke(context, exception, error);

        var innerExMessage = GetInnermostExceptionMessage(exception);

        var level = _options.DetermineLogLevel?.Invoke(exception) ?? LogLevel.Error;
        _logger.Log(level, exception, "BADNESS!!! " + innerExMessage + " -- {ErrorId}.", error.Id);

        var result = _serializer.Serialize(error);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        return context.Response.WriteAsync(result);
    }
    private string GetInnermostExceptionMessage(Exception exception)
    {
        if (exception.InnerException != null)
            return GetInnermostExceptionMessage(exception.InnerException);

        return exception.Message;
    }
}