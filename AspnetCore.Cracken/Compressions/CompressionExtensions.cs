namespace AspnetCore.Cracken.Compressions;

public static class CompressionExtensions
{
    #region privates
    private static IServiceCollection InsertGzipCompression(IServiceCollection services, CompressionLevel gZipCompresion)
    {
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<GzipCompressionProvider>();
        });

        services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = gZipCompresion;
        });

        return services;
    }

    private static IServiceCollection InsertBrotliCompression(IServiceCollection services, CompressionLevel brotliCompresionLevel)
    {
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
        });

        services.Configure<BrotliCompressionProviderOptions>(options =>
        {
            options.Level = brotliCompresionLevel;
        });

        return services;
    }
    private static IServiceCollection InsertBothCompressions(IServiceCollection services,
                                                             CompressionLevel gZipCompressionLevel,
                                                             CompressionLevel brotliCompressionLevel)
    {
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
        });

        services.Configure<BrotliCompressionProviderOptions>(options =>
        {
            options.Level = brotliCompressionLevel;
        });

        services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = gZipCompressionLevel;
        });

        return services;
    }
    #endregion

    public static IServiceCollection AddMinimalCompressions(this IServiceCollection services,
                                                            CompressionType compressionType,
                                                            CompressionLevel gZipCompressionLevel = CompressionLevel.SmallestSize,
                                                            CompressionLevel brotliCompressionLevel = CompressionLevel.Fastest)
    {

        switch (compressionType)
        {
            case var _ when compressionType == CompressionType.GZIP:
                return InsertGzipCompression(services, gZipCompressionLevel);
            case var _ when compressionType == CompressionType.BROTLI:
                return InsertBrotliCompression(services, brotliCompressionLevel);
            case var _ when compressionType == CompressionType.BOTH:
                return InsertBothCompressions(services, gZipCompressionLevel, brotliCompressionLevel);
            default:
                return services;
        }
    }
}