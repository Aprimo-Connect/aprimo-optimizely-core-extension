using EPiServer.Core;
using EPiServer.Core.Internal;
using EPiServer.Shell.Modules;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Aprimo.Opti.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAprimo(this IServiceCollection services)
        {
            services.Configure<ContentOptions>(contentOptions =>
                contentOptions.AddProvider<AprimoContentProvider>(AprimoConstants.ProviderKey, config =>
                {
                    var aprimoRoot = AprimoContentProvider.GetRoot();
                    config[ContentProviderParameter.EntryPoint] = aprimoRoot.ToString();
                }))
            .Configure<ProtectedModuleOptions>(protectedModuleOptions =>
            {
                if (!protectedModuleOptions.Items.Any(modules => modules.Name.Equals(AprimoConstants.ModuleName, System.StringComparison.OrdinalIgnoreCase)))
                {
                    protectedModuleOptions.Items.Add(new ModuleDetails()
                    {
                        Name = AprimoConstants.ModuleName,
                        Assemblies = { AprimoConstants.ModuleName }
                    });
                }
            });
        }
    }
}