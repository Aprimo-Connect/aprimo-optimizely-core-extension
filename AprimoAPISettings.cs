using EPiServer.ServiceLocation;
using Microsoft.Extensions.Configuration;

namespace Aprimo.Opti.Core
{
    public class AprimoAPISettings
    {
        private static Injected<IConfiguration> configuration;

        static AprimoAPISettings()
        {
        }

        public static string ClientId { get; } = configuration.Service.GetValue<string>("aprimo-api-clientid");

        public static string ClientSecret { get; } = configuration.Service.GetValue<string>("aprimo-api-clientsecret");

        public static string AprimoTenantId { get; } = configuration.Service.GetValue<string>("aprimo-api-tenantid");

        public static string DialogMode { get; } = configuration.Service.GetValue<string>("aprimo-api-dialogmode");

        public static string LabelButton { get; } = configuration.Service.GetValue<string>("aprimo-api-dialogbuttontext");

        public static string Description { get; } = configuration.Service.GetValue<string>("aprimo-api-dialogdescription");

        public static string Title { get; } = configuration.Service.GetValue<string>("aprimo-api-dialogtitle");
    }
}