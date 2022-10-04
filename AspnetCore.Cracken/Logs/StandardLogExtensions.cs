namespace AspnetCore.Cracken.Logs;

public static class StandardLogExtensions
{
    public static IServiceCollection AddStandardAspNetCoreHttpLogging(this IServiceCollection services,
                                                                      HttpLoggingFields loggingFields =
                                                                      HttpLoggingFields.RequestPropertiesAndHeaders |
                                                                      HttpLoggingFields.ResponseStatusCode |
                                                                      HttpLoggingFields.ResponseBody |
                                                                      HttpLoggingFields.RequestBody,
                                                                      int requestBodyLogLimit = 4096,
                                                                      int responseBodyLogLimit = 4096,
                                                                      List<string> mediaTypeOptions = default)
    {
        services.AddHttpLogging(options =>
        {
            options.LoggingFields = loggingFields;

            options.RequestBodyLogLimit = requestBodyLogLimit;
            options.ResponseBodyLogLimit = responseBodyLogLimit;

            if (mediaTypeOptions is null)
            {
                options.MediaTypeOptions.AddText("application/json");
            }
            else
            {
                mediaTypeOptions.ForEach(mediaTypeOption =>
                {
                    options.MediaTypeOptions.AddText(mediaTypeOption);
                });
            }
        });

        return services;
    }
}
