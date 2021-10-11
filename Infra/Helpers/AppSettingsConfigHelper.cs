using Microsoft.Extensions.Configuration;

namespace SouJunior.Infra.Helpers
{
    public static class AppSettingsConfigHelper
    {
        public static IConfigurationRoot Config { get; private set; }

        public static void FeedConfig(IConfigurationRoot generatedConfig)
        {
            Config = generatedConfig;
        }
    }
}
