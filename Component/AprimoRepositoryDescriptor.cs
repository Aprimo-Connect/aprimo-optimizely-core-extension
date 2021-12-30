using Aprimo.Opti.Core.Models;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aprimo.Opti.Core.Components
{
    [ServiceConfiguration(typeof(IContentRepositoryDescriptor))]
    public class AprimoRepositoryDescriptor : ContentRepositoryDescriptorBase
    {
        private readonly IContentProviderManager providerManager;

        public AprimoRepositoryDescriptor(IContentProviderManager providerManager)
        {
            this.providerManager = providerManager;
        }

        public override IEnumerable<ContentReference> Roots =>
            new ContentReference[] { this.providerManager.GetProvider(AprimoConstants.ProviderKey).EntryPoint };

        //public static string RepositoryKey =>
        //    AprimoConstants.ProviderKey;

        public override int SortOrder => 3;

        public override string Key =>
            AprimoConstants.ProviderKey;

        public override string Name =>
            AprimoConstants.ProviderName;

        public override IEnumerable<Type> ContainedTypes =>
            new[] { typeof(AprimoAssetData) };

        public override IEnumerable<Type> CreatableTypes =>
            Enumerable.Empty<Type>();

        public override IEnumerable<Type> MainNavigationTypes =>
            new[] { typeof(ContentFolder) };
    }
}