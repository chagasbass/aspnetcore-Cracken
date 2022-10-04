namespace AspnetCore.Cracken.Configurations;

public class HealthchecksConfigurationOptions
{
    public const string? BaseConfig = "HealthchecksConfiguration";

    public int SetEvaluationTimeInSeconds { get; set; }
    public int MaximumHistoryEntriesPerEndpoint { get; set; }
    public string? HeaderText { get; set; }

    public HealthchecksConfigurationOptions() { }

}
