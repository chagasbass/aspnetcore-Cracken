namespace AspnetCore.Cracken.Documentations;

public static class SwaggerExtensions
{
    const string defaultMessage = "My Company";
    const string defaultAppName = "My Company API";
    const string defaultDescription = "Company API";
    const string defaultUrl = @"https://opensource.org/licenses/MIT";

    static string? _applicationName;
    static string? _applicationDescription;
    static string? _developerName;
    static string? _companyName;
    static string? _companyUrl;
    static bool _hasAuthentication;

    private static void ValidateDocumentationData(IConfiguration configuration)
    {
        _applicationName = configuration["SwaggerConfiguration:ApplicationName"];
        _applicationDescription = configuration["SwaggerConfiguration:ApplicationDescription"];
        _developerName = configuration["SwaggerConfiguration:Developer"];
        _companyName = configuration["SwaggerConfiguration:CompanyName"];
        _companyUrl = configuration["SwaggerConfiguration:CompanyUrl"];
        _hasAuthentication = bool.Parse(configuration["SwaggerConfiguration:HasAuthentication"]);

        if (string.IsNullOrEmpty(_applicationName))
            _applicationName = defaultAppName;

        if (string.IsNullOrEmpty(_applicationDescription))
            _applicationDescription = defaultDescription;

        if (string.IsNullOrEmpty(_companyUrl))
            _companyUrl = defaultUrl;

        if (string.IsNullOrEmpty(_companyName))
            _companyName = defaultMessage;

        if (string.IsNullOrEmpty(_developerName))
            _developerName = defaultMessage;
    }

    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, IConfiguration configuration)
    {
        ValidateDocumentationData(configuration);

        var uri = new Uri(_companyUrl);

        var info = new OpenApiInfo
        {
            Title = _applicationName,
            Description = $"{_applicationDescription} Developed by {_developerName}",
            License = new OpenApiLicense { Name = _companyName, Url = uri }
        };

        services.AddSwaggerGen(delegate (SwaggerGenOptions c)
        {
            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            c.SwaggerDoc("v1", info);
            c.EnableAnnotations();

            if (_hasAuthentication)
            {
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "Authorization by JWT token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
            {
                { securitySchema, new[] { "Bearer" } }
            };

                c.AddSecurityRequirement(securityRequirement);
            }
        });

        return services;
    }
}
