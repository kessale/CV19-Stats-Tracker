using System.Collections.Generic;

// Extends PlaceInfo to include province-specific information for countries.
namespace CV19.Models
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; } // A collection of province-specific information.
    }
}
