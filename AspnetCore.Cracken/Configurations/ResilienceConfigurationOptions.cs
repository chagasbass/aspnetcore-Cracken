namespace AspnetCore.Cracken.Configurations;

public class ResilienceConfigurationOptions
{
    public const string? ResilienceConfig = "ResilienceConfiguration";
    public int MaxRetries { get; set; }
    public string? ClientName { get; set; }

    public ResilienceConfigurationOptions() { }
}
