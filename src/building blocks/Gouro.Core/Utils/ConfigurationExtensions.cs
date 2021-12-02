using Microsoft.Extensions.Configuration;

namespace Gouro.Core.Utils
{
    public static class ConfigurationExtensions
    {
        public static string GetMessaQueueConnection(this IConfiguration configuration, string name)
        {
            return configuration?.GetSection("MessageQueueConnection")?[name];
        }
    }
}
