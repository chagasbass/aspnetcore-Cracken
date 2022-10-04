namespace AspnetCore.Cracken.Configurations;

public class SwaggerConfigurationOptions
{
    public const string BaseConfig = "SwaggerConfiguration";

    public string? ApplicationName { get; set; }
    public string? ApplicationDescription { get; set; }
    public string? Developer { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyUrl { get; set; }
    public bool HasAuthentication { get; set; }

    public SwaggerConfigurationOptions() { }
}
