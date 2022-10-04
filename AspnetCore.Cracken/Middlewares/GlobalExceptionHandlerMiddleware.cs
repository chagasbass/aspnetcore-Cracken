namespace AspnetCore.Cracken.Middlewares;

public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    private readonly ProblemDetailConfigurationOptions _problemOptions;
    private readonly ILogger _logger;

    public GlobalExceptionHandlerMiddleware(IOptions<ProblemDetailConfigurationOptions> problemOptions,
                                            ILogger logger)
    {
        _problemOptions = problemOptions.Value;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private ProblemDetails ConfigureProblemDetails(int statusCode, Exception exception, HttpContext context)
    {
        var defaultTitle = "Um erro ocorreu ao processar o request.";
        var defaultDetail = $"Erro fatal na aplicação,entre em contato com um Desenvolvedor responsável. Causa: {exception.Message}";

        var title = _problemOptions.Title;
        var detail = _problemOptions.Detail;
        var instance = context.Request.HttpContext.Request.Path.ToString();

        var type = StatusCodeOperation.RetrieveStatusCode(statusCode);

        if (string.IsNullOrEmpty(title))
            title = defaultTitle;

        if (string.IsNullOrEmpty(detail))
            detail = defaultDetail;

        return new ProblemDetails()
        {
            Detail = detail,
            Instance = instance,
            Status = statusCode,
            Title = title,
            Type = type.Text
        };
    }

    /// <summary>
    /// Responsavel por tratar as exceções geradas na aplicação
    /// </summary>
    /// <param name="context"></param>
    /// <param name="exception"></param>
    /// <returns></returns>
    public async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        const int statusCode = StatusCodes.Status500InternalServerError;
        const string dataType = @"application/problem+json";

        _logger.LogError(exception, exception.Message);
        _logger.LogError(exception.StackTrace);

        var problemDetails = ConfigureProblemDetails(statusCode, exception, context);

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = dataType;

        await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails, JsonOptionsFactory.GetSerializerOptions()));
    }
}
