﻿namespace Aprimo.Opti.Core.Models
{
    public interface IAprimoAsset
    {
        string AssetId { get; set; }

        string AssetType { get; set; }

        string FileExtension { get; set; }
    }
}